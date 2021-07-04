using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mr_shtrahman.Data;
using mr_shtrahman.Models;

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
            return View(await _context.Trip.ToListAsync());
        }

        // GET: Trips/Details/5
        public async Task<IActionResult> Details(string id)
        {
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

            return View(trip);
        }

        // GET: Trips/Create
        public IActionResult Create()
        {
            ViewData["Products"] = new SelectList(_context.Product, nameof(Product.Id), nameof(Product.Name));
            ViewData["VisitorsAttendance"] = new SelectList(_context.VisitorsAttendance, nameof(VisitorsAttendance.Id), nameof(VisitorsAttendance.Date));
            ViewData["Img"] = new SelectList(_context.Img, nameof(Img.Id), nameof(Img.Src));
            return View();
        }

        // POST: Trips/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Rating,Destination,TripType,Difficulty,Location,Details,ClosestShopsId")] Trip trip, string[] products, string[] visitorsAttendances, string imgId)
        {
            if (ModelState.IsValid)
            {
                trip.VisitorsAttendance = new List<VisitorsAttendance>();
                trip.RelventProducts = new List<Product>();
                trip.VisitorsAttendance.AddRange(_context.VisitorsAttendance.Where(visitorsAttendance => visitorsAttendances.Contains(visitorsAttendance.Id)));
                trip.RelventProducts.AddRange(_context.Product.Where(product => products.Contains(product.Id)));
                _context.Add(trip);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(trip);
        }

        // GET: Trips/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip = await _context.Trip.FindAsync(id);
            if (trip == null)
            {
                return NotFound();
            }
            ViewData["Products"] = new SelectList(_context.Product, nameof(Product.Id), nameof(Product.Name));
            ViewData["VisitorsAttendance"] = new SelectList(_context.VisitorsAttendance, nameof(VisitorsAttendance.Id), nameof(VisitorsAttendance.Date));
            ViewData["Img"] = new SelectList(_context.Img, nameof(Img.Id), nameof(Img.Src));
            return View(trip);
        }

        // POST: Trips/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Price,Rating,Destination,TripType,Difficulty,Location,Details,ClosestShopsId")] Trip trip, string[] products, string[] visitorsAttendances, string imgId)
        {
            if (id != trip.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    trip.VisitorsAttendance = new List<VisitorsAttendance>();
                    trip.RelventProducts = new List<Product>();
                    trip.VisitorsAttendance.AddRange(_context.VisitorsAttendance.Where(visitorsAttendance => visitorsAttendances.Contains(visitorsAttendance.Id)));
                    trip.RelventProducts.AddRange(_context.Product.Where(product => products.Contains(product.Id)));
                    _context.Update(trip);
                    await _context.SaveChangesAsync();
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
        public async Task<IActionResult> Delete(string id)
        {
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

            return View(trip);
        }

        // POST: Trips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var trip = await _context.Trip.FindAsync(id);
            _context.Trip.Remove(trip);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TripExists(string id)
        {
            return _context.Trip.Any(e => e.Id == id);
        }
    }
}
