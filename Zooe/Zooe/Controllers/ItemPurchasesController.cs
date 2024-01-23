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
    public class ItemPurchasesController : Controller
    {
        private readonly Team10Context _context;

        public ItemPurchasesController(Team10Context context)
        {
            _context = context;
        }

        // GET: ItemPurchases
        public async Task<IActionResult> Index()
        {
            var team10Context = _context.ItemPurchase.Include(i => i.Customer).Include(i => i.Item);
            return View(await team10Context.ToListAsync());
        }

        // GET: ItemPurchases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemPurchase = await _context.ItemPurchase
                .Include(i => i.Customer)
                .Include(i => i.Item)
                .FirstOrDefaultAsync(m => m.TransactionId == id);
            if (itemPurchase == null)
            {
                return NotFound();
            }

            return View(itemPurchase);
        }

        // GET: ItemPurchases/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId");
            ViewData["ItemId"] = new SelectList(_context.Items, "ItemId", "Title");
            return View();
        }

        // POST: ItemPurchases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TransactionId,ItemId,CustomerId,TotalCost,PurchaseDate,Quantity")] ItemPurchase itemPurchase)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(itemPurchase);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemPurchaseExists(itemPurchase.TransactionId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (DbUpdateException) //catches trigger errors
                {
                    var _item = await _context.Items.FindAsync(itemPurchase.ItemId);
                    ViewData["Amount"] = _item.StockCount;
                    return View("Error");
                }
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId", itemPurchase.CustomerId);
            ViewData["ItemId"] = new SelectList(_context.Items, "ItemId", "Title", itemPurchase.ItemId);
            return View(itemPurchase);
        }

        // GET: ItemPurchases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemPurchase = await _context.ItemPurchase.FindAsync(id);
            if (itemPurchase == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId", itemPurchase.CustomerId);
            ViewData["ItemId"] = new SelectList(_context.Items, "ItemId", "Title", itemPurchase.ItemId);
            return View(itemPurchase);
        }

        // POST: ItemPurchases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TransactionId,ItemId,CustomerId,TotalCost,PurchaseDate,Quantity")] ItemPurchase itemPurchase)
        {
            if (id != itemPurchase.TransactionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ItemPurchase _itemPurchase = _context.ItemPurchase.Where(s => s.TransactionId == itemPurchase.TransactionId).First();
                    _itemPurchase.ItemId = itemPurchase.ItemId;
                    _itemPurchase.CustomerId = itemPurchase.CustomerId;
                    _itemPurchase.TotalCost = itemPurchase.TotalCost;
                    _itemPurchase.PurchaseDate = itemPurchase.PurchaseDate;
                    _itemPurchase.Quantity = itemPurchase.Quantity;
                    _context.Update(_itemPurchase);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemPurchaseExists(itemPurchase.TransactionId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerId", itemPurchase.CustomerId);
            ViewData["ItemId"] = new SelectList(_context.Items, "ItemId", "Title", itemPurchase.ItemId);
            return View(itemPurchase);
        }

        // GET: ItemPurchases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemPurchase = await _context.ItemPurchase
                .Include(i => i.Customer)
                .Include(i => i.Item)
                .FirstOrDefaultAsync(m => m.TransactionId == id);
            if (itemPurchase == null)
            {
                return NotFound();
            }

            return View(itemPurchase);
        }

        // POST: ItemPurchases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var itemPurchase = await _context.ItemPurchase.FindAsync(id);
            _context.ItemPurchase.Remove(itemPurchase);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemPurchaseExists(int id)
        {
            return _context.ItemPurchase.Any(e => e.TransactionId == id);
        }
    }
}
