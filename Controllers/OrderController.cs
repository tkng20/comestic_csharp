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
    public class OrderController : Controller
    {
        private readonly ShopContext _context;

        public OrderController(ShopContext context)
        {
            _context = context;
        }

        // GET: Order
        public async Task<IActionResult> Index()
        {
            var shopContext = _context.Orders.Include(o => o.Coupon).Include(o => o.Product).Include(o => o.Shipping).Include(o => o.User);
            return View(await shopContext.ToListAsync());
        }

        // GET: Order/Details/5
        public async Task<IActionResult> Details(ulong? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Coupon)
                .Include(o => o.Product)
                .Include(o => o.Shipping)
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Order/Create
        public IActionResult Create()
        {
            ViewData["CouponId"] = new SelectList(_context.Coupons, "Id", "Code");
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Condition");
            ViewData["ShippingId"] = new SelectList(_context.Shippings, "Id", "Status");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Fullname");
            return View();
        }

        // POST: Order/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OrderNumber,ProductId,UserId,SubTotal,ShippingId,CouponId,TotalAmount,Quantity,PaymentMethod,PaymentStatus,Status,FirstName,LastName,Email,Phone,Address")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CouponId"] = new SelectList(_context.Coupons, "Id", "Code", order.CouponId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Condition", order.ProductId);
            ViewData["ShippingId"] = new SelectList(_context.Shippings, "Id", "Status", order.ShippingId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Fullname", order.UserId);
            return View(order);
        }

        // GET: Order/Edit/5
        public async Task<IActionResult> Edit(ulong? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["CouponId"] = new SelectList(_context.Coupons, "Id", "Code", order.CouponId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Condition", order.ProductId);
            ViewData["ShippingId"] = new SelectList(_context.Shippings, "Id", "Status", order.ShippingId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Fullname", order.UserId);
            return View(order);
        }

        // POST: Order/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ulong id, [Bind("Id,OrderNumber,ProductId,UserId,SubTotal,ShippingId,CouponId,TotalAmount,Quantity,PaymentMethod,PaymentStatus,Status,FirstName,LastName,Email,Phone,Address")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
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
            ViewData["CouponId"] = new SelectList(_context.Coupons, "Id", "Code", order.CouponId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Condition", order.ProductId);
            ViewData["ShippingId"] = new SelectList(_context.Shippings, "Id", "Status", order.ShippingId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Fullname", order.UserId);
            return View(order);
        }

        // GET: Order/Delete/5
        public async Task<IActionResult> Delete(ulong? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Coupon)
                .Include(o => o.Product)
                .Include(o => o.Shipping)
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(ulong id)
        {
            var order = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(ulong id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
