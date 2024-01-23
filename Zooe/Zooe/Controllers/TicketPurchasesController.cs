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
    public class TicketPurchasesController : Controller
    {
        private readonly Team10Context _context;

        public TicketPurchasesController(Team10Context context)
        {
            _context = context;
        }

        // GET: TicketPurchases
        public async Task<IActionResult> Index()
        {
            var team10Context = _context.TicketPurchase.Include(t => t.Customer);
            return View(await team10Context.ToListAsync());
        }

        // GET: TicketPurchases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticketPurchase = await _context.TicketPurchase
                .Include(t => t.Customer)
                .FirstOrDefaultAsync(m => m.TicketId == id);
            if (ticketPurchase == null)
            {
                return NotFound();
            }

            return View(ticketPurchase);
        }

        // GET: TicketPurchases/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId");
            return View();
        }

        // POST: TicketPurchases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TransactionId,CustomerId,TicketId,Price,ExpirationDate,PurchaseDate,IsValid")] TicketPurchase ticketPurchase)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticketPurchase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId", ticketPurchase.CustomerId);
            return View(ticketPurchase);
        }

        // GET: TicketPurchases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticketPurchase = await _context.TicketPurchase.FindAsync(id);
            if (ticketPurchase == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId", ticketPurchase.CustomerId);
            return View(ticketPurchase);
        }

        // POST: TicketPurchases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TransactionId,CustomerId,TicketId,Price,ExpirationDate,PurchaseDate,IsValid")] TicketPurchase ticketPurchase)
        {
            if (id != ticketPurchase.TicketId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    TicketPurchase _ticketPurchase = _context.TicketPurchase.Where(s => s.TransactionId == ticketPurchase.TransactionId).First();
                    _ticketPurchase.TransactionId = ticketPurchase.TransactionId;
                    _ticketPurchase.CustomerId = ticketPurchase.CustomerId;
                    _ticketPurchase.TicketId = ticketPurchase.TicketId;
                    _ticketPurchase.Price = ticketPurchase.Price;
                    _ticketPurchase.ExpirationDate = ticketPurchase.ExpirationDate;
                    _ticketPurchase.PurchaseDate = ticketPurchase.PurchaseDate;
                    _ticketPurchase.IsValid = ticketPurchase.IsValid;

                    _context.Update(_ticketPurchase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketPurchaseExists(ticketPurchase.TicketId))
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
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId", ticketPurchase.CustomerId);
            return View(ticketPurchase);
        }

        // GET: TicketPurchases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticketPurchase = await _context.TicketPurchase
                .Include(t => t.Customer)
                .FirstOrDefaultAsync(m => m.TicketId == id);
            if (ticketPurchase == null)
            {
                return NotFound();
            }

            return View(ticketPurchase);
        }

        // POST: TicketPurchases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ticketPurchase = await _context.TicketPurchase.FindAsync(id);
            _context.TicketPurchase.Remove(ticketPurchase);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketPurchaseExists(int id)
        {
            return _context.TicketPurchase.Any(e => e.TicketId == id);
        }
    }
}
