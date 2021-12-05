using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VswTask.Injection;
using VswTask.Models;


namespace VswTask.Controllers
{
    public class BasicModelsController : Controller
    {
        private readonly DbContextPipe _context;

        public BasicModelsController(DbContextPipe context)
        {
            _context = context;
        }

        // GET: BasicModels
        public async Task<IActionResult> Index(int? page)
        {
            //ViewData["DateSortParam"] = sortOrder == "Data" ? "Date" : "CreateDate";

            //var BasicModel = from s in _context.BasicModels join TargetOuterDiameter in _context.BasicModels on s.TargetOuterDiameter  
            //                 equals  select s;
            //return View(await _context.BasicModels.
            //    Include(c => c.TargetOuterDiameter).
            //    AsNoTracking().
            //    ToListAsync());

           var BasicModel = _context.BasicModels.Include(c => c.TargetOuterDiameter).AsNoTracking();
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(await PaginatedList<BasicModel>.CreateAsync(BasicModel.AsNoTracking(), pageNumber, pageSize));

        }

        // GET: BasicModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var basicModel = await _context.BasicModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (basicModel == null)
            {
                return NotFound();
            }

            return View(basicModel);
        }

        // GET: BasicModels/Create
        public IActionResult Create()
        {
            PopulateTargetDropDownList(1);
            return View();
        }

        // POST: BasicModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NumberTube,MeasuredDiameter1,MeasuredDiameter2," +
            "MeasuredDiameter3,MaxDeviation,Note,TargetDiameterId,BasicDateId")] BasicModel basicModel)
        {
            if (ModelState.IsValid)
            {
                basicModel.CreateDate = DateTime.Now;
                _context.Add(basicModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateTargetDropDownList(basicModel.TargetDiameterId);
            return View(basicModel);
        }

        // GET: BasicModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var basicModel = await _context.BasicModels.FindAsync(id);
            if (basicModel == null)
            {
                return NotFound();
            }

            PopulateTargetDropDownList(basicModel.TargetDiameterId);
            return View(basicModel);
        }

        // POST: BasicModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id, [Bind("Id,NumberTube,MeasuredDiameter1,MeasuredDiameter2,MeasuredDiameter3," +
            "MaxDeviation,Note,TargetDiameterId")] BasicModel basicModel)
        {
            if (id != basicModel.Id)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
                try
                {
                    basicModel.EditDate = DateTime.Now;
                    _context.Update(basicModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BasicModelExists(basicModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                //}
                return RedirectToAction(nameof(Index));
            }
            //PopulateTargetDropDownList(basicModel.TargetDiameterId);
            return View(basicModel);
        }

        // GET: BasicModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var basicModel = await _context.BasicModels
                .FirstOrDefaultAsync(m => m.Id == id);
            if (basicModel == null)
            {
                return NotFound();
            }

            return View(basicModel);
        }

        // POST: BasicModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var basicModel = await _context.BasicModels.FindAsync(id);
            _context.BasicModels.Remove(basicModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BasicModelExists(int id)
        {
            return _context.BasicModels.Any(e => e.Id == id);
        }
        private void PopulateTargetDropDownList(object selecterDiametrs)
        {
            var targerQuerty = from d in _context.TargetOuterDiameters
                               orderby d.TargetOuterDiameters
                               select d;

            ViewBag.TargetDiametersId = new SelectList(targerQuerty.AsNoTracking(), "Id", "TargetOuterDiameters", selecterDiametrs);
        }
    }
}
