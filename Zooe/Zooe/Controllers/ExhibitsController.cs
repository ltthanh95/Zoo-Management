﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Zooe.Team10;

namespace Zooe.Controllers
{
    public class ExhibitsController : Controller
    {
        private readonly Team10Context _context;

        public ExhibitsController(Team10Context context)
        {
            _context = context;
        }

        // GET: Exhibits
        
        public async Task<IActionResult> Index()
        {
            var team10Context = _context.Exhibit.Include(e => e.Department);
            return View(await team10Context.ToListAsync());
        }

        public async Task<IActionResult> Exhibits()
        {
            var team10Context = _context.Exhibit.Include(e => e.Department);
            return View(await team10Context.ToListAsync());
        }
        // GET: Exhibits/Details/5

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exhibit = await _context.Exhibit
                .Include(e => e.Department)
                .FirstOrDefaultAsync(m => m.ExhibitId == id);
            if (exhibit == null)
            {
                return NotFound();
            }

            return View(exhibit);
        }

        // GET: Exhibits/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "DepartmentName");
            return View();
        }

        // POST: Exhibits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExhibitId,DepartmentId,AnimalId,Name,ExhibitHabitat,Description,ImageUrl")] Exhibit exhibit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(exhibit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "DepartmentName", exhibit.DepartmentId);
            return View(exhibit);
        }

        // GET: Exhibits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exhibit = await _context.Exhibit.FindAsync(id);
            if (exhibit == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "DepartmentName", exhibit.DepartmentId);
            return View(exhibit);
        }

        // POST: Exhibits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExhibitId,DepartmentId,AnimalId,Name,ExhibitHabitat,Description,ImageUrl")] Exhibit exhibit)
        {
            if (id != exhibit.ExhibitId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Exhibit _exhibit = _context.Exhibit.Where(s => s.ExhibitId == exhibit.ExhibitId).First();
                    _exhibit.DepartmentId = exhibit.DepartmentId;
                    _exhibit.AnimalId = exhibit.AnimalId;
                    _exhibit.Name = exhibit.Name;
                    _exhibit.ExhibitHabitat = exhibit.ExhibitHabitat;
                    _exhibit.Description = exhibit.Description;
                    _exhibit.ImageUrl = exhibit.ImageUrl;
                    _context.Update(_exhibit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExhibitExists(exhibit.ExhibitId))
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
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "DepartmentName", exhibit.DepartmentId);
            return View(exhibit);
        }

        // GET: Exhibits/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exhibit = await _context.Exhibit
                .Include(e => e.Department)
                .FirstOrDefaultAsync(m => m.ExhibitId == id);
            if (exhibit == null)
            {
                return NotFound();
            }

            return View(exhibit);
        }

        // POST: Exhibits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var exhibit = await _context.Exhibit.FindAsync(id);
            _context.Exhibit.Remove(exhibit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExhibitExists(int id)
        {
            return _context.Exhibit.Any(e => e.ExhibitId == id);
        }
    }
}
