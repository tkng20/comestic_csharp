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
    public class ProductController : Controller
    {
        private readonly ShopContext _context;

        public ProductController(ShopContext context)
        {
            _context = context;
        }

        // GET: Product
        public async Task<IActionResult> Index()
        {
            var shopContext = _context.Products.Include(p => p.Brand).Include(p => p.Cat).Include(p => p.ChildCat).Include(p => p.Coupon);
            return View(await shopContext.ToListAsync());
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(ulong? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Cat)
                .Include(p => p.ChildCat)
                .Include(p => p.Coupon)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Slug");
            ViewData["CatId"] = new SelectList(_context.Categories, "Id", "Slug");
            ViewData["ChildCatId"] = new SelectList(_context.Categories, "Id", "Slug");
            ViewData["CouponId"] = new SelectList(_context.Coupons, "Id", "Code");
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Slug,Summary,Description,Photo1,Photo2,Photo3,Photo4,Stock,Condition,Status,Price,CouponId,CatId,ChildCatId,BrandId")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Slug", product.BrandId);
            ViewData["CatId"] = new SelectList(_context.Categories, "Id", "Slug", product.CatId);
            ViewData["ChildCatId"] = new SelectList(_context.Categories, "Id", "Slug", product.ChildCatId);
            ViewData["CouponId"] = new SelectList(_context.Coupons, "Id", "Code", product.CouponId);
            return View(product);
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(ulong? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Slug", product.BrandId);
            ViewData["CatId"] = new SelectList(_context.Categories, "Id", "Slug", product.CatId);
            ViewData["ChildCatId"] = new SelectList(_context.Categories, "Id", "Slug", product.ChildCatId);
            ViewData["CouponId"] = new SelectList(_context.Coupons, "Id", "Code", product.CouponId);
            return View(product);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ulong id, [Bind("Id,Title,Slug,Summary,Description,Photo1,Photo2,Photo3,Photo4,Stock,Condition,Status,Price,CouponId,CatId,ChildCatId,BrandId")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Slug", product.BrandId);
            ViewData["CatId"] = new SelectList(_context.Categories, "Id", "Slug", product.CatId);
            ViewData["ChildCatId"] = new SelectList(_context.Categories, "Id", "Slug", product.ChildCatId);
            ViewData["CouponId"] = new SelectList(_context.Coupons, "Id", "Code", product.CouponId);
            return View(product);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(ulong? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Cat)
                .Include(p => p.ChildCat)
                .Include(p => p.Coupon)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(ulong id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(ulong id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
