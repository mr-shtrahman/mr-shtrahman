using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mr_shtrahman.Data;
using mr_shtrahman.enums;
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
            return View(await _context.Product.ToListAsync());

        }
        public async Task<IActionResult> Search(string query)
        {
            var productWithImgs = _context.Product.Where(p => p.Name.Contains(query) ||
                                                         query == null);
            return View(await productWithImgs.ToListAsync());
        }


        public async Task<IActionResult> Filter(string size = null, string rating = null, string color = null, string price = null)
        {
            ViewData["Category"] = category.ToString();
            var productWithSearchContext = _context.Product.Where(t =>
            (size == null || ((int)t.Size).ToString() == size) &&
            (rating == null || (t.Rating).ToString() == rating) &&
            (color == null || t.Color == color) &&
            (price == null || ((int)t.Price).ToString() == price));

            return View("Category",await productWithSearchContext.ToListAsync());
        }
        // GET: ProductImage
        public ActionResult ProductImage(string id)
        {
            string imageSrc = _context.Img.Where(i => i.ProductId.ToString() == id).FirstOrDefault().Src.Substring(1);
            return Json(imageSrc);

        }

        // GET: Products/Category/Shoes
        public async Task<IActionResult> Category(Category category)
        {                               
            ViewData["Category"] = category.ToString();
            var categoryProducts = _context.Product.Where(p => p.Category == category);
            
            return View(await categoryProducts.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewData["Shops"] = _context.Shop.ToList(); // TODO get all shops where a product can be found
            ViewData["Image"] = _context.Img.Where(i => i.ShopId == null && i.TripId == null && i.ProductId == id).FirstOrDefault();
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
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Rating,Category,Size,Color,Details,Description,ImgId")] Product product, int[] trips, int[] shops,int imgId)
        {
            if (ModelState.IsValid)
            {
                product.Trips = new List<Trip>();
                product.Shops = new List<Shop>();
                product.Trips.AddRange(_context.Trip.Where(trip => trips.Contains(trip.Id)));
                product.Shops.AddRange(_context.Shop.Where(shop => shops.Contains(shop.Id)));
                

                _context.Add(product);
                await _context.SaveChangesAsync();
                await UpdateIMGAsync(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
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

            ViewData["Image"] = _context.Img.Where(i => i.ShopId == null && i.TripId == null && i.ProductId == id).FirstOrDefault();
            ViewData["trips"] = new SelectList(_context.Trip, nameof(Trip.Id), nameof(Trip.Name));
            ViewData["Shops"] = new SelectList(_context.Shop, nameof(Shop.Id), nameof(Shop.Name));

            ViewData["Images"] = new SelectList(_context.Img.Where(i => i.ShopId == null && i.TripId == null && i.ProductId == id || i.ProductId == null), nameof(Img.Id), nameof(Img.Src));

            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Rating,Category,Size,Color,Details,Description,ImgId")] Product product, int[] trips, int[] shops)
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
                    await UpdateIMGAsync(product);
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
        public async Task<IActionResult>  Delete(int? id)
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
                await DeleteConfirmed(id);
            

            return RedirectToAction(nameof(Index));
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            _context.Product.Remove(product);
            deleteProductFromImg(product.Id);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }



        private async Task<bool> UpdateIMGAsync(Product product)
        {
            var img = _context.Img.Where(i => i.Id == product.ImgId).FirstOrDefault();

            if (img == null)
            {
                return false;
            }

            img.ProductId = product.Id;
            _context.Update(img);
            await _context.SaveChangesAsync();
            return _context.Img.Where(i => i.Id == product.ImgId).FirstOrDefault().ProductId == product.Id;

        }

        private async Task<bool> deleteProductFromImg(int productId)
        {
            var img = _context.Img.Where(i => i.ProductId == productId).FirstOrDefault();

            if (img == null)
            {
                return false;
            }

            img.TripId = null;
            _context.Update(img);
            await _context.SaveChangesAsync();

            if (_context.Img.Where(i => i.ProductId == productId).FirstOrDefault() == null)
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
