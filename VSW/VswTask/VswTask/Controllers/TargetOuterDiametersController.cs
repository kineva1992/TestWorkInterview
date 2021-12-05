using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VswTask.Models;

namespace VswTask.Controllers
{
    public class TargetOuterDiametersController : Controller
    {
        private readonly DbContextPipe _context;

        public TargetOuterDiametersController(DbContextPipe context)
        {
            _context = context;
        }

        // GET: TargetOuterDiameters
        public async Task<IActionResult> Index()
        {
            return View(await _context.TargetOuterDiameters.ToListAsync());
        }

        // GET: TargetOuterDiameters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var targetOuterDiameter = await _context.TargetOuterDiameters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (targetOuterDiameter == null)
            {
                return NotFound();
            }

            return View(targetOuterDiameter);
        }

        // GET: TargetOuterDiameters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TargetOuterDiameters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TargetOuterDiameters")] TargetOuterDiameter targetOuterDiameter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(targetOuterDiameter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(targetOuterDiameter);
        }

        // GET: TargetOuterDiameters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var targetOuterDiameter = await _context.TargetOuterDiameters.FindAsync(id);
            if (targetOuterDiameter == null)
            {
                return NotFound();
            }
            return View(targetOuterDiameter);
        }

        // POST: TargetOuterDiameters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TargetOuterDiameters")] TargetOuterDiameter targetOuterDiameter)
        {
            if (id != targetOuterDiameter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(targetOuterDiameter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TargetOuterDiameterExists(targetOuterDiameter.Id))
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
            return View(targetOuterDiameter);
        }

        // GET: TargetOuterDiameters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var targetOuterDiameter = await _context.TargetOuterDiameters
                .FirstOrDefaultAsync(m => m.Id == id);
            if (targetOuterDiameter == null)
            {
                return NotFound();
            }

            return View(targetOuterDiameter);
        }

        // POST: TargetOuterDiameters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var targetOuterDiameter = await _context.TargetOuterDiameters.FindAsync(id);
            _context.TargetOuterDiameters.Remove(targetOuterDiameter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TargetOuterDiameterExists(int id)
        {
            return _context.TargetOuterDiameters.Any(e => e.Id == id);
        }
    }
}
