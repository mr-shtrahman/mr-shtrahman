using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mr_shtrahman.Data;
using mr_shtrahman.Models;
using mr_shtrahman.enums;

namespace mr_shtrahman.Controllers
{
    public class TripsController : Controller
    {
        private readonly Context _context;

        public TripsController(Context context)
        {
            _context = context;
        }

        // GET: Trips
        public async Task<IActionResult> Index()
        {
            var currentUser = HttpContext.Session.Get<User>("User");

            ViewData["isAdmin"] = (currentUser != null) && (currentUser.isAdmin);
            ViewData["Images"] = new List<Img>(_context.Img.Where(i => i.TripId != null));
            return View(await _context.Trip.ToListAsync());
        }
        public async Task<IActionResult> Search(string query)
        {
            var currentUser = HttpContext.Session.Get<User>("User");

            ViewData["isAdmin"] = (currentUser != null) && (currentUser.isAdmin);
            var tripsWithSearchContext = _context.Trip.Where(t => t.Name.Contains(query) ||
                                                         query == null);

            return View("Index", await tripsWithSearchContext.ToListAsync());
        }

        // GET: Trips/Map
        public async Task<IActionResult> Map()
        {
            var markers = await _context.Trip.ToListAsync();

            var giftshops = _context.Trip
                .GroupJoin(
                    _context.Shop,
                    (trip) => new { trip.Lat, trip.Lon },
                    (shop) => new { shop.Lat, shop.Lon },
                    (trip, shop) => new { Trip = trip, Shop = shop }
               ).SelectMany(
                     (giftshop) => giftshop.Shop.DefaultIfEmpty(),
                     (x,y) => new {Trip = x.Trip, Shop = y}
                ).Select(giftshop => new {
                    tripName = giftshop.Trip.Name,
                    Lat = giftshop.Trip.Lat,
                    Lon = giftshop.Trip.Lon,
                    isGiftshop = (giftshop.Shop != null)
                }
            );
            return View(giftshops.ToList());
        }

        public async Task<IActionResult> Filter(string destination = null, string tripType = null, string difficulty = null)
        {
            var currentUser = HttpContext.Session.Get<User>("User");
            ViewData["isAdmin"] = (currentUser != null) && (currentUser.isAdmin);

            var tripsWithSearchContext = _context.Trip.Where(t =>
            (destination == null || ((int)t.Destination).ToString() == destination) &&
            (tripType == null || ((int)t.TripType).ToString() == tripType) &&
            (difficulty == null || ((int)t.Difficulty).ToString() == difficulty));

            return View("Index", await tripsWithSearchContext.ToListAsync());
        }
        // GET: TripImage
        public ActionResult TripImage(string id)
        {
            Img img = _context.Img.Where(i => i.TripId.ToString() == id).FirstOrDefault();
            string imageSrc = "";

            if (img != null)
            {
                imageSrc = img.Src.Substring(1);
            }

            return Json(imageSrc);
        }

        // GET: Trips/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = _context.Trip.Include(c => c.RelevantProducts).Where(t => t.Id == id).FirstOrDefault().RelevantProducts;
            var productImages = new Dictionary<Product, Img>();

            if (products != null)
            {
                foreach (Product p in products)
                {
                    productImages[p] = _context.Img.Where(i => i.ProductId == p.Id).FirstOrDefault();
                }
            }

            ViewData["Image"] = _context.Img.Where(i => i.ShopId == null && i.TripId == id && i.ProductId == null).FirstOrDefault();
            ViewData["ProductImages"] = productImages;

          var trip = await _context.Trip
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trip == null)
            {
                return NotFound();
            }

            return View(trip);
        }

        // GET: Trips/Create
        public IActionResult Create()
        {
            var currentUser = HttpContext.Session.Get<User>("User");

            if (currentUser == null || !currentUser.isAdmin)
            {
                return Redirect("/");
            }
            ViewData["Products"] = _context.Product.AsEnumerable().GroupBy(p => p.Category).ToDictionary(g => g.Key, g => g.ToList());
            ViewData["VisitorsAttendance"] = new SelectList(_context.VisitorsAttendance, nameof(VisitorsAttendance.Id), nameof(VisitorsAttendance.Date));
            ViewData["Images"] = new SelectList(_context.Img.Where(i => i.ShopId == null && i.TripId == null && i.ProductId == null), nameof(Img.Id), nameof(Img.Src));
            return View();
        }

        // POST: Trips/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Rating,Destination,Lon,Lat,TripType,Difficulty,Location,Details,ImgId")] Trip trip, int[] RelevantProducts, int[] visitorsAttendances)
        {
            var currentUser = HttpContext.Session.Get<User>("User");

            if (currentUser == null || !currentUser.isAdmin)
            {
                return Redirect("/");
            }
            if (ModelState.IsValid)
            {
                trip.VisitorsAttendance = new List<VisitorsAttendance>();
                trip.RelevantProducts = new List<Product>();
                trip.VisitorsAttendance.AddRange(_context.VisitorsAttendance.Where(visitorsAttendance => visitorsAttendances.Contains(visitorsAttendance.Id)));
                trip.RelevantProducts.AddRange(_context.Product.Where(product => RelevantProducts.Contains(product.Id)));
                
                _context.Add(trip);
                await _context.SaveChangesAsync();
                await UpdateIMGAsync(trip);
                return RedirectToAction(nameof(Index));
            }
            return View(trip);
        }

        // GET: Trips/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var currentUser = HttpContext.Session.Get<User>("User");

            if (currentUser == null || !currentUser.isAdmin)
            {
                return Redirect("/");
            }
            if (id == null)
            {
                return NotFound();
            }

            var trip = await _context.Trip.FindAsync(id);
            if (trip == null)
            {
                return NotFound();
            }

            ViewData["Products"] = _context.Product.AsEnumerable().GroupBy(p => p.Category).ToDictionary(g => g.Key, g => g.ToList());
            ViewData["Image"] = _context.Img.Where(i => i.ShopId == null && i.TripId == id && i.ProductId == null).FirstOrDefault();
            ViewData["VisitorsAttendance"] = new SelectList(_context.VisitorsAttendance, nameof(VisitorsAttendance.Id), nameof(VisitorsAttendance.Date));
            ViewData["Images"] = new SelectList(_context.Img.Where(i => i.ShopId == null && (i.TripId == id || i.TripId == null) && i.ProductId == null), nameof(Img.Id), nameof(Img.Src));
            _context.RemoveRange(_context.Trip.Include(t => t.RelevantProducts).Where(t => t.Id == id).ToList());
            _context.Update(trip);
            await _context.SaveChangesAsync();
            return View(trip);
        }

        // POST: Trips/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Rating,Destination,Lon,Lat,TripType,Difficulty,Location,Details,ImgId")] Trip trip, int[] RelevantProducts, int[] visitorsAttendances)
        {
            var currentUser = HttpContext.Session.Get<User>("User");

            if (currentUser == null || !currentUser.isAdmin)
            {
                return Redirect("/");
            }
            if (id != trip.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {        
                    trip.VisitorsAttendance = new List<VisitorsAttendance>();
                    trip.RelevantProducts = new List<Product>();
                    trip.VisitorsAttendance.AddRange(_context.VisitorsAttendance.Where(visitorsAttendance => visitorsAttendances.Contains(visitorsAttendance.Id)));
                    trip.RelevantProducts.AddRange(_context.Product.Where(product => RelevantProducts.Contains(product.Id)));

                    _context.Update(trip);
                    await _context.SaveChangesAsync();
                    await UpdateIMGAsync(trip);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TripExists(trip.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(trip);
        }

        // GET: Trips/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var currentUser = HttpContext.Session.Get<User>("User");

            if (currentUser == null || !currentUser.isAdmin)
            {
                return Redirect("/");
            }
            if (id == null)
            {
                return NotFound();
            }

            var trip = await _context.Trip
                .FirstOrDefaultAsync(m => m.Id == id);
            if (trip == null)
            {
                return NotFound();
            }
            await DeleteConfirmed(id);


            return RedirectToAction(nameof(Index));
        }

        // POST: Trips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var currentUser = HttpContext.Session.Get<User>("User");

            if (currentUser == null || !currentUser.isAdmin)
            {
                return Redirect("/");
            }
            if (id == null)
            {
                return NotFound();
            }

            var trip = await _context.Trip.FindAsync(id);
            _context.Trip.Remove(trip);
            await deleteTripFromImg(trip.Id);

            return RedirectToAction(nameof(Index));
        }

        private bool TripExists(int id)
        {
            return _context.Trip.Any(e => e.Id == id);
        }

        private async Task<bool> UpdateIMGAsync(Trip trip)
        {
            var img = _context.Img.Where(i => i.Id == trip.ImgId).FirstOrDefault();

            if (img == null)
            {
                return false;
            }

            img.TripId = trip.Id;
            _context.Update(img);
            await _context.SaveChangesAsync();
            return _context.Img.Where(i => i.Id == trip.ImgId).FirstOrDefault().TripId == trip.Id;

        }

        private async Task<bool> deleteTripFromImg(int tripId)
        {
            var img = _context.Img.Where(i => i.TripId == tripId).FirstOrDefault();

            if (img == null)
            {
                return false;
            }

            img.TripId = null;
            _context.Update(img);
            await _context.SaveChangesAsync();

            if (_context.Img.Where(i => i.TripId == tripId).FirstOrDefault() == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}