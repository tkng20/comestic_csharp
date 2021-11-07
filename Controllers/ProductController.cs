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
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Cat)
                .Include(p => p.ChildCat)
                .Include(p => p.Coupon)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
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
        public async Task<IActionResult> Create([Bind("Id,Title,Slug,Summary,Description,Photo1,Photo2,Photo3,Photo4,Stock,Color,Condition,Status,Price,CouponId,CatId,ChildCatId,BrandId,Created_at,Updated_at")] Products products)
        {
            if (ModelState.IsValid)
            {
                _context.Add(products);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Slug", products.BrandId);
            ViewData["CatId"] = new SelectList(_context.Categories, "Id", "Slug", products.CatId);
            ViewData["ChildCatId"] = new SelectList(_context.Categories, "Id", "Slug", products.ChildCatId);
            ViewData["CouponId"] = new SelectList(_context.Coupons, "Id", "Code", products.CouponId);
            return View(products);
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Slug", products.BrandId);
            ViewData["CatId"] = new SelectList(_context.Categories, "Id", "Slug", products.CatId);
            ViewData["ChildCatId"] = new SelectList(_context.Categories, "Id", "Slug", products.ChildCatId);
            ViewData["CouponId"] = new SelectList(_context.Coupons, "Id", "Code", products.CouponId);
            return View(products);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Title,Slug,Summary,Description,Photo1,Photo2,Photo3,Photo4,Stock,Color,Condition,Status,Price,CouponId,CatId,ChildCatId,BrandId,Created_at,Updated_at")] Products products)
        {
            if (id != products.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(products);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductsExists(products.Id))
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
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Slug", products.BrandId);
            ViewData["CatId"] = new SelectList(_context.Categories, "Id", "Slug", products.CatId);
            ViewData["ChildCatId"] = new SelectList(_context.Categories, "Id", "Slug", products.ChildCatId);
            ViewData["CouponId"] = new SelectList(_context.Coupons, "Id", "Code", products.CouponId);
            return View(products);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Cat)
                .Include(p => p.ChildCat)
                .Include(p => p.Coupon)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var products = await _context.Products.FindAsync(id);
            _context.Products.Remove(products);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductsExists(long id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
