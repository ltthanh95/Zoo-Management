using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Zooe.Team10;

namespace Zooe.Controllers
{
    public class PrivateEventsController : Controller
    {
        private readonly Team10Context _context;

        public PrivateEventsController(Team10Context context)
        {
            _context = context;
        }

        // GET: PrivateEvents
        public async Task<IActionResult> Index()
        {
            var team10Context = _context.PrivateEvent.Include(p => p.Department);
            return View(await team10Context.ToListAsync());
        }
        public async Task<IActionResult> PrivateEvent()
        {
            var team10Context = _context.PrivateEvent.Include(p => p.Department);
            return View(await team10Context.ToListAsync());
        }
        // GET: PrivateEvents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var privateEvent = await _context.PrivateEvent
                .Include(p => p.Department)
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (privateEvent == null)
            {
                return NotFound();
            }

            return View(privateEvent);
        }

        // GET: PrivateEvents/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "DepartmentName");
            return View();
        }

        // POST: PrivateEvents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventId,DepartmentId,EventDate,Price,GuestCapacity,Location,EventType,ImageUrl,Description,IsBooked")] PrivateEvent privateEvent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(privateEvent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "DepartmentName", privateEvent.DepartmentId);
            return View(privateEvent);
        }

        // GET: PrivateEvents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var privateEvent = await _context.PrivateEvent.FindAsync(id);
            if (privateEvent == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "DepartmentName", privateEvent.DepartmentId);
            return View(privateEvent);
        }

        // POST: PrivateEvents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventId,DepartmentId,EventDate,Price,GuestCapacity,Location,EventType,ImageUrl,Description,IsBooked")] PrivateEvent privateEvent)
        {
            if (id != privateEvent.EventId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    PrivateEvent _privateEvent = _context.PrivateEvent.Where(s => s.EventId == privateEvent.EventId).First();
                    _privateEvent.DepartmentId = privateEvent.DepartmentId;
                    _privateEvent.EventDate = privateEvent.EventDate;
                    _privateEvent.Price = privateEvent.Price;
                    _privateEvent.GuestCapacity = privateEvent.GuestCapacity;
                    _privateEvent.Location = privateEvent.Location;
                    _privateEvent.EventType = privateEvent.EventType;
                    _privateEvent.ImageUrl = privateEvent.ImageUrl;
                    _privateEvent.Description = privateEvent.Description;
                    _privateEvent.IsBooked = privateEvent.IsBooked;
                    _context.Update(_privateEvent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrivateEventExists(privateEvent.EventId))
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
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "DepartmentName", privateEvent.DepartmentId);
            return View(privateEvent);
        }

        // GET: PrivateEvents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var privateEvent = await _context.PrivateEvent
                .Include(p => p.Department)
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (privateEvent == null)
            {
                return NotFound();
            }

            return View(privateEvent);
        }

        // POST: PrivateEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var privateEvent = await _context.PrivateEvent.FindAsync(id);
            _context.PrivateEvent.Remove(privateEvent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrivateEventExists(int id)
        {
            return _context.PrivateEvent.Any(e => e.EventId == id);
        }
    }
}
