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
    public class ProductReviewController : Controller
    {
        private readonly ShopContext _context;

        public ProductReviewController(ShopContext context)
        {
            _context = context;
        }

        // GET: ProductReview
        public async Task<IActionResult> Index()
        {
            var shopContext = _context.ProductReviews.Include(p => p.Product).Include(p => p.User);
            return View(await shopContext.ToListAsync());
        }

        // GET: ProductReview/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productReviewModel = await _context.ProductReviews
                .Include(p => p.Product)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productReviewModel == null)
            {
                return NotFound();
            }

            return View(productReviewModel);
        }

        // GET: ProductReview/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Color");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Name");
            return View();
        }

        // POST: ProductReview/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,ProductId,Rate,Review,Status,CreatedAt,UpdatedAt")] ProductReviews productReviewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productReviewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Color", productReviewModel.ProductId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Name", productReviewModel.UserId);
            return View(productReviewModel);
        }

        // GET: ProductReview/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productReviewModel = await _context.ProductReviews.FindAsync(id);
            if (productReviewModel == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Color", productReviewModel.ProductId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Name", productReviewModel.UserId);
            return View(productReviewModel);
        }

        // POST: ProductReview/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,UserId,ProductId,Rate,Review,Status,CreatedAt,UpdatedAt")] ProductReviews productReviewModel)
        {
            if (id != productReviewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productReviewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductReviewModelExists(productReviewModel.Id))
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
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Color", productReviewModel.ProductId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Name", productReviewModel.UserId);
            return View(productReviewModel);
        }

        // GET: ProductReview/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productReviewModel = await _context.ProductReviews
                .Include(p => p.Product)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productReviewModel == null)
            {
                return NotFound();
            }

            return View(productReviewModel);
        }

        // POST: ProductReview/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var productReviewModel = await _context.ProductReviews.FindAsync(id);
            _context.ProductReviews.Remove(productReviewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductReviewModelExists(long id)
        {
            return _context.ProductReviews.Any(e => e.Id == id);
        }
    }
}
