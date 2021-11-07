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

            var productModel = await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Cat)
                .Include(p => p.ChildCat)
                .Include(p => p.Coupon)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productModel == null)
            {
                return NotFound();
            }

            return View(productModel);
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
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Slug,Summary,Description,Photo1,Photo2,Photo3,Photo4,Stock,Color,Condition,Status,Price,CouponId,CatId,ChildCatId,BrandId,CreatedAt,UpdatedAt")] Products productModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Slug", productModel.BrandId);
            ViewData["CatId"] = new SelectList(_context.Categories, "Id", "Slug", productModel.CatId);
            ViewData["ChildCatId"] = new SelectList(_context.Categories, "Id", "Slug", productModel.ChildCatId);
            ViewData["CouponId"] = new SelectList(_context.Coupons, "Id", "Code", productModel.CouponId);
            return View(productModel);
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productModel = await _context.Products.FindAsync(id);
            if (productModel == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Slug", productModel.BrandId);
            ViewData["CatId"] = new SelectList(_context.Categories, "Id", "Slug", productModel.CatId);
            ViewData["ChildCatId"] = new SelectList(_context.Categories, "Id", "Slug", productModel.ChildCatId);
            ViewData["CouponId"] = new SelectList(_context.Coupons, "Id", "Code", productModel.CouponId);
            return View(productModel);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Title,Slug,Summary,Description,Photo1,Photo2,Photo3,Photo4,Stock,Color,Condition,Status,Price,CouponId,CatId,ChildCatId,BrandId,CreatedAt,UpdatedAt")] Products productModel)
        {
            if (id != productModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductModelExists(productModel.Id))
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
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Slug", productModel.BrandId);
            ViewData["CatId"] = new SelectList(_context.Categories, "Id", "Slug", productModel.CatId);
            ViewData["ChildCatId"] = new SelectList(_context.Categories, "Id", "Slug", productModel.ChildCatId);
            ViewData["CouponId"] = new SelectList(_context.Coupons, "Id", "Code", productModel.CouponId);
            return View(productModel);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productModel = await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Cat)
                .Include(p => p.ChildCat)
                .Include(p => p.Coupon)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productModel == null)
            {
                return NotFound();
            }

            return View(productModel);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var productModel = await _context.Products.FindAsync(id);
            _context.Products.Remove(productModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductModelExists(long id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
