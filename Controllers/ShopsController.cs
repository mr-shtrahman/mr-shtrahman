using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mr_shtrahman.Data;
using mr_shtrahman.Models;

namespace mr_shtrahman.Controllers
{
    public class ShopsController : Controller
    {
        private readonly Context _context;

        public ShopsController(Context context)
        {
            _context = context;
        }

        // GET: Shops
        public async Task<IActionResult> Index()
        {
            var currentUser = HttpContext.Session.Get<User>("User");
            ViewData["isAdmin"] = (currentUser != null) && (currentUser.isAdmin);

            return View(await _context.Shop.ToListAsync());
        }

        public async Task<IActionResult> Search(string query)
        {
            var currentUser = HttpContext.Session.Get<User>("User");
            ViewData["isAdmin"] = (currentUser != null) && (currentUser.isAdmin);

            var shopsWithSearchContext = _context.Shop.Where(s => s.Name.Contains(query) ||
                                                          query == null);

            return View("Index", await shopsWithSearchContext.ToListAsync());
        }

        public async Task<IActionResult> Filter(string city = null, string rating = null, string days = null)
        {
            var currentUser = HttpContext.Session.Get<User>("User");
            ViewData["isAdmin"] = (currentUser != null) && (currentUser.isAdmin);

            var productWithSearchContext = _context.Shop.Where(t =>
            (city == null || ((int)t.City).ToString() == city) &&
            (rating == null || (t.Rating).ToString() == rating) &&
            (days == null || 
            ((days == "1" && t.OpeningSundayTilThursday != null && t.OpeningFriday != null && t.OpeningSaturday != null) ||
             (days == "2" && t.OpeningSundayTilThursday != null && t.OpeningFriday != null && t.OpeningSaturday == null ) ||
             (days == "3" && t.OpeningSundayTilThursday != null && t.OpeningFriday == null && t.OpeningSaturday == null))));

            return View("Index", await productWithSearchContext.ToListAsync());
        }
        // GET: ShopImage
        public ActionResult ShopImage(string id)
        {
            Img img = _context.Img.Where(i => i.ShopId.ToString() == id).FirstOrDefault();
            string imageSrc = "";

            if (img != null)
            {
                imageSrc = img.Src.Substring(1);
            }
            
            return Json(imageSrc);
        }
        
        // GET: Shops/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = _context.Shop.Include(c => c.Products).Where(s => s.Id == id).FirstOrDefault().Products;
            var productImages = new Dictionary<Product, Img>();

            if (products != null)
            {
                foreach (Product p in products)
                {
                    productImages[p] = _context.Img.Where(i => i.ProductId == p.Id).FirstOrDefault();
                }
            }

            ViewData["ProductImages"] = productImages;
            ViewData["Image"] = _context.Img.Where(i => i.ShopId == id && i.TripId == null && i.ProductId == null).FirstOrDefault();

            var shop = await _context.Shop
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shop == null)
            {
                return NotFound();
            }

            return View(shop);
        }

        // GET: Shops/Create
        public IActionResult Create()
        {
            var currentUser = HttpContext.Session.Get<User>("User");

            if (currentUser == null || !currentUser.isAdmin)
            {
                return Redirect("/");
            }
            ViewData["Products"] = _context.Product.AsEnumerable().GroupBy(p => p.Category).ToDictionary(g => g.Key, g => g.ToList());
            ViewData["Images"] = new SelectList(_context.Img.Where(i => i.ShopId == null && i.TripId == null && i.ProductId == null), nameof(Img.Id), nameof(Img.Src));
            return View();
        }

        // POST: Shops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Id,Name,City,Street,StreetNum,Lon,Lat,PhoneNum,Rating,OpeningSundayTilThursday,ClosingSundayTilThursday,OpeningFriday,ClosingFriday,OpeningSaturday,ClosingSaturday,ImgId")] Shop shop,
             int[] Products)
        {
            var currentUser = HttpContext.Session.Get<User>("User");

            if (currentUser == null || !currentUser.isAdmin)
            {
                return Redirect("/");
            }
            if (ModelState.IsValid)
            {
                shop.Products = new List<Product>();
                shop.Products.AddRange(_context.Product.Where(product => Products.Contains(product.Id)));

                _context.Add(shop);
                await _context.SaveChangesAsync();
                await UpdateIMGAsync(shop);
                return RedirectToAction(nameof(Index));
            }
            return View(shop);
        }

        // GET: Shops/Edit/5
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

            var shop = await _context.Shop.FindAsync(id);
            if (shop == null)
            {
                return NotFound();
            }

            ViewData["Products"] = _context.Product.AsEnumerable().GroupBy(p => p.Category).ToDictionary(g => g.Key, g => g.ToList());
            ViewData["Image"] = _context.Img.Where(i => i.ShopId == id && i.TripId == null && i.ProductId == null).FirstOrDefault();
            ViewData["Product"] = new SelectList(_context.Product, nameof(Product.Id), nameof(Product.Name));
            ViewData["Images"] = new SelectList(_context.Img.Where(i => (i.ShopId == id || i.ShopId == null) && i.TripId == null && i.ProductId == null), nameof(Img.Id), nameof(Img.Src));
            _context.RemoveRange(_context.Shop.Include(s => s.Products).Where(s => s.Id == id).ToList());
            _context.Update(shop);
            await _context.SaveChangesAsync();
            return View(shop);
        }

        // POST: Shops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("Id,Name,City,Street,StreetNum,Lon,Lat,PhoneNum,Rating,OpeningSundayTilThursday,ClosingSundayTilThursday,OpeningFriday,ClosingFriday,OpeningSaturday,ClosingSaturday,ImgId")] Shop shop,
            int[] Products) 
        {
            var currentUser = HttpContext.Session.Get<User>("User");

            if (currentUser == null || !currentUser.isAdmin)
            {
                return Redirect("/");
            }
            if (id != shop.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    shop.Products = new List<Product>();
                    shop.Products.AddRange(_context.Product.Where(product => Products.Contains(product.Id)));
                    var productsInCategory = _context.Shop
                                .Where(c => c.Id == shop.Id)
                                .SelectMany(c => c.Products); // how to get data!

                    _context.Update(shop);
                    await _context.SaveChangesAsync();

                    await UpdateIMGAsync(shop);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShopExists(shop.Id))
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
            return View(shop);
        }

        // GET: Shops/Delete/5
        public async Task<IActionResult>  Delete(int? id)
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

            var shop = await _context.Shop
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shop == null)
            {
                return NotFound();
            }
               
            await DeleteConfirmed(id);
            
            return RedirectToAction(nameof(Index));
        }

        // POST: Shops/Delete/5
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
            var shop = await _context.Shop.FindAsync(id);
            _context.Shop.Remove(shop);
            await deleteShopFromImg(shop.Id);
            return RedirectToAction(nameof(Index));
        }

        private bool ShopExists(int id)
        {
            return _context.Shop.Any(e => e.Id == id);
        }


        private async Task<bool> UpdateIMGAsync(Shop shop)
        {
            var img = _context.Img.Where(i => i.Id == shop.ImgId).FirstOrDefault();

            if (img == null)
            {
                return false;
            }

            img.ShopId = shop.Id;
            _context.Update(img);
            await _context.SaveChangesAsync();
            return _context.Img.Where(i => i.Id == shop.ImgId).FirstOrDefault().ShopId == shop.Id;

        }

        private async Task<bool> deleteShopFromImg(int shopId)
        {
            var img = _context.Img.Where(i => i.ShopId == shopId).FirstOrDefault();

            if (img == null)
            {
                return false;
            }

            img.TripId = null;
            _context.Update(img);
            await _context.SaveChangesAsync();

            if (_context.Img.Where(i => i.ShopId == shopId).FirstOrDefault() == null)
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
