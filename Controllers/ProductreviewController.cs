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
    public class ProductreviewController : Controller
    {
        private readonly ShopContext _context;

        public ProductreviewController(ShopContext context)
        {
            _context = context;
        }

        // GET: Productreview
        public async Task<IActionResult> Index()
        {
            var shopContext = _context.Productreviews.Include(p => p.Product).Include(p => p.User);
            return View(await shopContext.ToListAsync());
        }

        // GET: Productreview/Details/5
        public async Task<IActionResult> Details(ulong? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productreview = await _context.Productreviews
                .Include(p => p.Product)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productreview == null)
            {
                return NotFound();
            }

            return View(productreview);
        }

        // GET: Productreview/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Condition");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Fullname");
            return View();
        }

        // POST: Productreview/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,ProductId,Rating,Review,Status")] Productreview productreview)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productreview);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Condition", productreview.ProductId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Fullname", productreview.UserId);
            return View(productreview);
        }

        // GET: Productreview/Edit/5
        public async Task<IActionResult> Edit(ulong? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productreview = await _context.Productreviews.FindAsync(id);
            if (productreview == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Condition", productreview.ProductId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Fullname", productreview.UserId);
            return View(productreview);
        }

        // POST: Productreview/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ulong id, [Bind("Id,UserId,ProductId,Rating,Review,Status")] Productreview productreview)
        {
            if (id != productreview.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productreview);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductreviewExists(productreview.Id))
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
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Condition", productreview.ProductId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Fullname", productreview.UserId);
            return View(productreview);
        }

        // GET: Productreview/Delete/5
        public async Task<IActionResult> Delete(ulong? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productreview = await _context.Productreviews
                .Include(p => p.Product)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productreview == null)
            {
                return NotFound();
            }

            return View(productreview);
        }

        // POST: Productreview/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(ulong id)
        {
            var productreview = await _context.Productreviews.FindAsync(id);
            _context.Productreviews.Remove(productreview);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductreviewExists(ulong id)
        {
            return _context.Productreviews.Any(e => e.Id == id);
        }
    }
}
