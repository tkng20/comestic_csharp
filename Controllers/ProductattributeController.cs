using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using comestic_csharp.Models;

namespace comestic_csharp.Controllers
{
    public class ProductattributeController : Controller
    {
        private readonly ShopContext _context;

        public ProductattributeController(ShopContext context)
        {
            _context = context;
        }

        // GET: Productattribute
        public async Task<IActionResult> Index()
        {
            var shopContext = _context.Productattributes.Include(p => p.Product);
            return View(await shopContext.ToListAsync());
        }

        // GET: Productattribute/Details/5
        public async Task<IActionResult> Details(ulong? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productattribute = await _context.Productattributes
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productattribute == null)
            {
                return NotFound();
            }

            return View(productattribute);
        }

        // GET: Productattribute/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Condition");
            return View();
        }

        // POST: Productattribute/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Color,Price,Stock,ProductId")] Productattribute productattribute)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productattribute);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Condition", productattribute.ProductId);
            return View(productattribute);
        }

        // GET: Productattribute/Edit/5
        public async Task<IActionResult> Edit(ulong? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productattribute = await _context.Productattributes.FindAsync(id);
            if (productattribute == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Condition", productattribute.ProductId);
            return View(productattribute);
        }

        // POST: Productattribute/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ulong id, [Bind("Id,Color,Price,Stock,ProductId")] Productattribute productattribute)
        {
            if (id != productattribute.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productattribute);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductattributeExists(productattribute.Id))
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
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Condition", productattribute.ProductId);
            return View(productattribute);
        }

        // GET: Productattribute/Delete/5
        public async Task<IActionResult> Delete(ulong? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productattribute = await _context.Productattributes
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productattribute == null)
            {
                return NotFound();
            }

            return View(productattribute);
        }

        // POST: Productattribute/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(ulong id)
        {
            var productattribute = await _context.Productattributes.FindAsync(id);
            _context.Productattributes.Remove(productattribute);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductattributeExists(ulong id)
        {
            return _context.Productattributes.Any(e => e.Id == id);
        }
    }
}
