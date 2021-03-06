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
    public class ImgsController : Controller
    {
        private readonly Context _context;

        public ImgsController(Context context)
        {

            _context = context;
        }

        // GET: Imgs
        public async Task<IActionResult> Index()
        {
            var currentUser = HttpContext.Session.Get<User>("User");

            if (currentUser == null || !currentUser.isAdmin)
            {
                return Redirect("/");
            }
            var context = _context.Img.Include(i => i.Trip);
            return View(await context.ToListAsync());
        }


        // GET: Imgs/Details/5
        public async Task<IActionResult> Details(int? id)
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

            var img = await _context.Img
                .Include(i => i.Trip)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (img == null)
            {
                return NotFound();
            }

            return View(img);
        }

        // GET: Imgs/Create
        public IActionResult Create()
        {
            var currentUser = HttpContext.Session.Get<User>("User");

            if (currentUser == null || !currentUser.isAdmin)
            {
                return Redirect("/");
            }
            return View();
        }

        // POST: Imgs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Src,Description")] Img img)
        {
            var currentUser = HttpContext.Session.Get<User>("User");

            if (currentUser == null || !currentUser.isAdmin)
            {
                return Redirect("/");
            }
            if (ModelState.IsValid)
            {
                _context.Add(img);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            return View(img);
        }

        // GET: Imgs/Edit/5
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

            var img = await _context.Img.FindAsync(id);
            if (img == null)
            {
                return NotFound();
            }
            return View(img);
        }

        // POST: Imgs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Src,Description")] Img img)
        {
            var currentUser = HttpContext.Session.Get<User>("User");

            if (currentUser == null || !currentUser.isAdmin)
            {
                return Redirect("/");
            }
            if (id != img.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(img);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImgExists(img.Id))
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
            return View(img);
        }

        // GET: Imgs/Delete/5
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

            var img = await _context.Img
                .FirstOrDefaultAsync(m => m.Id == id);
            if (img == null)
            {
                return NotFound();
            }

            return View(img);
        }

        // POST: Imgs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var currentUser = HttpContext.Session.Get<User>("User");

            if (currentUser == null || !currentUser.isAdmin)
            {
                return Redirect("/");
            }
            var img = await _context.Img.FindAsync(id);
            _context.Img.Remove(img);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImgExists(int id)
        {
            return _context.Img.Any(e => e.Id == id);
        }
    }
}