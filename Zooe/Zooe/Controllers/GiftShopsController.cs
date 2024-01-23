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
    public class GiftShopsController : Controller
    {
        private readonly Team10Context _context;

        public GiftShopsController(Team10Context context)
        {
            _context = context;
        }

        // GET: GiftShops
        public async Task<IActionResult> Index()
        {
            var team10Context = _context.GiftShop.Include(g => g.Department);
            return View(await team10Context.ToListAsync());
        }
        public async Task<IActionResult> Shop()
        {
            var team10Context = _context.GiftShop.Include(g => g.Department);
            return View(await team10Context.ToListAsync());
        }

        // GET: GiftShops/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giftShop = await _context.GiftShop
                .Include(g => g.Department)
                .FirstOrDefaultAsync(m => m.ShopId == id);
            if (giftShop == null)
            {
                return NotFound();
            }

            return View(giftShop);
        }

        // GET: GiftShops/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "DepartmentName");
            return View();
        }

        // POST: GiftShops/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ShopId,DepartmentId,ShopName,Description,ImageUrl,Location")] GiftShop giftShop)
        {
            if (ModelState.IsValid)
            {
                _context.Add(giftShop);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "DepartmentName", giftShop.DepartmentId);
            return View(giftShop);
        }

        // GET: GiftShops/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giftShop = await _context.GiftShop.FindAsync(id);
            if (giftShop == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "DepartmentName", giftShop.DepartmentId);
            return View(giftShop);
        }

        // POST: GiftShops/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ShopId,DepartmentId,ShopName,Description,ImageUrl,Location")] GiftShop giftShop)
        {
            if (id != giftShop.ShopId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    GiftShop _giftShop = _context.GiftShop.Where(s => s.ShopId == giftShop.ShopId).First();
                    _giftShop.DepartmentId = giftShop.DepartmentId;
                    _giftShop.ShopName = giftShop.ShopName;
                    _giftShop.Description = giftShop.Description;
                    _giftShop.ImageUrl = giftShop.ImageUrl;
                    _giftShop.Location = giftShop.Location;
                    _context.Update(_giftShop);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GiftShopExists(giftShop.ShopId))
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
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "DepartmentName", giftShop.DepartmentId);
            return View(giftShop);
        }

        // GET: GiftShops/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giftShop = await _context.GiftShop
                .Include(g => g.Department)
                .FirstOrDefaultAsync(m => m.ShopId == id);
            if (giftShop == null)
            {
                return NotFound();
            }

            return View(giftShop);
        }

        // POST: GiftShops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var giftShop = await _context.GiftShop.FindAsync(id);
            _context.GiftShop.Remove(giftShop);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GiftShopExists(int id)
        {
            return _context.GiftShop.Any(e => e.ShopId == id);
        }
    }
}
