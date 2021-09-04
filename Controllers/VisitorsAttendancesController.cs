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
    public class VisitorsAttendancesController : Controller
    {
        private readonly Context _context;

        public VisitorsAttendancesController(Context context)
        {
            _context = context;
        }

        // GET: VisitorsAttendances
        public async Task<IActionResult> Index()
        {
            return View(await _context.VisitorsAttendance.ToListAsync());
        }

        // GET: VisitorsAttendances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitorsAttendance = await _context.VisitorsAttendance
                .FirstOrDefaultAsync(m => m.Id == id);
            if (visitorsAttendance == null)
            {
                return NotFound();
            }

            return View(visitorsAttendance);
        }

        // GET: VisitorsAttendances/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VisitorsAttendances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Attendance,TripId")] VisitorsAttendance visitorsAttendance)
        {
            if (ModelState.IsValid)
            {
                _context.Add(visitorsAttendance);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(visitorsAttendance);
        }

        // GET: VisitorsAttendances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitorsAttendance = await _context.VisitorsAttendance.FindAsync(id);
            if (visitorsAttendance == null)
            {
                return NotFound();
            }
            return View(visitorsAttendance);
        }

        // POST: VisitorsAttendances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Attendance,TripId")] VisitorsAttendance visitorsAttendance)
        {
            if (id != visitorsAttendance.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(visitorsAttendance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisitorsAttendanceExists(visitorsAttendance.Id))
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
            return View(visitorsAttendance);
        }

        // GET: VisitorsAttendances/Delete/5
        public async Task<IActionResult>  Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitorsAttendance = await _context.VisitorsAttendance
                .FirstOrDefaultAsync(m => m.Id == id);
            if (visitorsAttendance == null)
            {
                return NotFound();
            }

            return View(visitorsAttendance);
        }

        // POST: VisitorsAttendances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var visitorsAttendance = await _context.VisitorsAttendance.FindAsync(id);
            _context.VisitorsAttendance.Remove(visitorsAttendance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VisitorsAttendanceExists(int id)
        {
            return _context.VisitorsAttendance.Any(e => e.Id == id);
        }
    }
}
