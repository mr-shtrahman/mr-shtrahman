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
            var shopsWithImgs = _context.Shop.Include(s => s.Img);
            return View(await shopsWithImgs.ToListAsync());
        }

        public async Task<IActionResult> Search(string query)
        {

            var shopsWithSearchContext = _context.Shop.Include(s => s.Img).
                                                     Where(s => s.Name.Contains(query) ||
                                                           query == null);

            return View("Index", await shopsWithSearchContext.ToListAsync());
        }

        // GET: Shops/Details/5
        public async Task<IActionResult> Details(string id)
        {
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

            return View(shop);
        }

        // GET: Shops/Create
        public IActionResult Create()
        {
            ViewData["trips"] = new SelectList(_context.Trip, nameof(Trip.Id), nameof(Trip.Name));
            ViewData["Product"] = new SelectList(_context.Product, nameof(Product.Id), nameof(Product.Name));
            ViewData["Images"] = new SelectList(_context.Img.Where(i => i.ShopId == null), nameof(Img.Id), nameof(Img.Src));
            return View();
        }

        // POST: Shops/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Id,Name,City,Street,StreetNum,PhoneNum,rating,OpeningSundayTilThursday,ClosingSundayTilThursday,OpeningFriday,ClosingFriday,OpeningSaturday,ClosingSaturday,ImgId")] Shop shop,
            string[] trips, string[] shops, string imgId)
        {
            if (ModelState.IsValid)
            {
                shop.Trips = new List<Trip>();
                shop.Products = new List<Product>();
                shop.Trips.AddRange(_context.Trip.Where(trip => trips.Contains(trip.Id)));
                shop.Products.AddRange(_context.Product.Where(product => shops.Contains(product.Id)));

                _context.Add(shop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shop);
        }

        // GET: Shops/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shop = await _context.Shop.FindAsync(id);
            if (shop == null)
            {
                return NotFound();
            }

            ViewData["trips"] = new SelectList(_context.Trip, nameof(Trip.Id), nameof(Trip.Name));
            ViewData["Product"] = new SelectList(_context.Product, nameof(Product.Id), nameof(Product.Name));
            ViewData["Img"] = new SelectList(_context.Img, nameof(Img.Id), nameof(Img.Src));

            return View(shop);
        }

        // POST: Shops/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id,
            [Bind("Id,Name,City,Street,StreetNum,PhoneNum,rating,OpeningSundayTilThursday,ClosingSundayTilThursday,OpeningFriday,ClosingFriday,OpeningSaturday,ClosingSaturday,ImgId")] Shop shop,
            string[] trips, string[] shops, string imgId)
        {
            if (id != shop.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    shop.Trips = new List<Trip>();
                    shop.Products = new List<Product>();
                    shop.Trips.AddRange(_context.Trip.Where(trip => trips.Contains(trip.Id)));
                    shop.Products.AddRange(_context.Product.Where(product => shops.Contains(product.Id)));

                    _context.Update(shop);
                    await _context.SaveChangesAsync();
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
        public async Task<IActionResult> Delete(string id)
        {
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

            return View(shop);
        }

        // POST: Shops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var shop = await _context.Shop.FindAsync(id);
            _context.Shop.Remove(shop);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShopExists(string id)
        {
            return _context.Shop.Any(e => e.Id == id);
        }
    }
}
