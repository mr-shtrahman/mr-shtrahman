﻿using System;
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
    public class ProductsController : Controller
    {
        private readonly Context _context;

        public ProductsController(Context context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var productWithImgs = _context.Product.Include(p => p.Img);
            return View(await productWithImgs.ToListAsync());
        }
        public async Task<IActionResult> Search(string query)
        {
            var productWithImgs = _context.Product.Include(p => p.Img).
                                                  Where(p => p.Name.Contains(query) ||
                                                         query == null); ;
            return View(await productWithImgs.ToListAsync());
        }

        // GET: Products/Category/Shoes
        public async Task<IActionResult> Category(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.Id == id);

            var categoryProducts = _context.Product.Include(p => p.Img).
                                      Where(p => p.Category == product.Category);

            return View(await categoryProducts.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewData["Shops"] = _context.Shop.ToList(); // TODO get all shops where a product can be found

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["trips"] = new SelectList(_context.Trip, nameof(Trip.Id), nameof(Trip.Name));
            ViewData["Shops"] = new SelectList(_context.Shop, nameof(Shop.Id), nameof(Shop.Name));
            ViewData["Images"] = new SelectList(_context.Img.Where(i => i.ShopId == null && i.TripId == null && i.ProductId == null), nameof(Img.Id), nameof(Img.Src));
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Rating,Category,Size,Color,Details,Description,ImgId")] Product product, string[] trips, string[] shops,string imgId)
        {
            if (ModelState.IsValid)
            {
                product.Trips = new List<Trip>();
                product.Shops = new List<Shop>();
                product.Trips.AddRange(_context.Trip.Where(trip => trips.Contains(trip.Id)));
                product.Shops.AddRange(_context.Shop.Where(shop => shops.Contains(shop.Id)));
                

                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            ViewData["trips"] = new SelectList(_context.Trip, nameof(Trip.Id), nameof(Trip.Name));
            ViewData["Shops"] = new SelectList(_context.Shop, nameof(Shop.Id), nameof(Shop.Name));
            ViewData["Images"] = new SelectList(_context.Img.Where(i => i.ShopId == null && i.TripId == null && i.ProductId == null), nameof(Img.Id), nameof(Img.Src));

            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Price,Rating,Category,Size,Color,Details,Description,ImgId")] Product product, string[] trips, string[] shops, string imgId)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    product.Trips = new List<Trip>();
                    product.Shops = new List<Shop>();
                    product.Trips.AddRange(_context.Trip.Where(trip => trips.Contains(trip.Id)));
                    product.Shops.AddRange(_context.Shop.Where(shop => shops.Contains(shop.Id)));
                    

                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                await DeleteConfirmed(id);
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var product = await _context.Product.FindAsync(id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(string id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
    }
}
