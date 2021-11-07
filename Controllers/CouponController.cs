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
    public class CouponController : Controller
    {
        private readonly ShopContext _context;

        public CouponController(ShopContext context)
        {
            _context = context;
        }

        // GET: Coupon
        public async Task<IActionResult> Index()
        {
            return View(await _context.Coupons.ToListAsync());
        }

        // GET: Coupon/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var couponModel = await _context.Coupons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (couponModel == null)
            {
                return NotFound();
            }

            return View(couponModel);
        }

        // GET: Coupon/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Coupon/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code,Type,Value,Status,IsVoucher,Quantity,CreatedAt,EndedAt,UpdatedAt")] Coupons couponModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(couponModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(couponModel);
        }

        // GET: Coupon/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var couponModel = await _context.Coupons.FindAsync(id);
            if (couponModel == null)
            {
                return NotFound();
            }
            return View(couponModel);
        }

        // POST: Coupon/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Code,Type,Value,Status,IsVoucher,Quantity,CreatedAt,EndedAt,UpdatedAt")] Coupons couponModel)
        {
            if (id != couponModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(couponModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CouponModelExists(couponModel.Id))
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
            return View(couponModel);
        }

        // GET: Coupon/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var couponModel = await _context.Coupons
                .FirstOrDefaultAsync(m => m.Id == id);
            if (couponModel == null)
            {
                return NotFound();
            }

            return View(couponModel);
        }

        // POST: Coupon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var couponModel = await _context.Coupons.FindAsync(id);
            _context.Coupons.Remove(couponModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CouponModelExists(long id)
        {
            return _context.Coupons.Any(e => e.Id == id);
        }
    }
}
