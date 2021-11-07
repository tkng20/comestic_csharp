using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using comestic.Models;

namespace comestic.Controllers
{
    public class ShippingController : Controller
    {
        private readonly ShopContext _context;

        public ShippingController(ShopContext context)
        {
            _context = context;
        }

        // GET: Shipping
        public async Task<IActionResult> Index()
        {
            return View(await _context.Shippings.ToListAsync());
        }

        // GET: Shipping/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shippingModel = await _context.Shippings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shippingModel == null)
            {
                return NotFound();
            }

            return View(shippingModel);
        }

        // GET: Shipping/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Shipping/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,Price,Status,CreatedAt,UpdatedAt")] Shippings shippingModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shippingModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shippingModel);
        }

        // GET: Shipping/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shippingModel = await _context.Shippings.FindAsync(id);
            if (shippingModel == null)
            {
                return NotFound();
            }
            return View(shippingModel);
        }

        // POST: Shipping/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Type,Price,Status,CreatedAt,UpdatedAt")] Shippings shippingModel)
        {
            if (id != shippingModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shippingModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShippingModelExists(shippingModel.Id))
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
            return View(shippingModel);
        }

        // GET: Shipping/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shippingModel = await _context.Shippings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shippingModel == null)
            {
                return NotFound();
            }

            return View(shippingModel);
        }

        // POST: Shipping/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var shippingModel = await _context.Shippings.FindAsync(id);
            _context.Shippings.Remove(shippingModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShippingModelExists(long id)
        {
            return _context.Shippings.Any(e => e.Id == id);
        }
    }
}
