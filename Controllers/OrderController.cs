﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using comestic.Models;

namespace comestic.Controllers
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
            var shopContext = _context.Orders.Include(o => o.Coupon).Include(o => o.Shipping).Include(o => o.User);
            return View(await shopContext.ToListAsync());
        }

        // GET: Order/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderModel = await _context.Orders
                .Include(o => o.Coupon)
                .Include(o => o.Shipping)
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderModel == null)
            {
                return NotFound();
            }

            return View(orderModel);
        }

        // GET: Order/Create
        public IActionResult Create()
        {
            ViewData["CouponId"] = new SelectList(_context.Coupons, "Id", "Code");
            ViewData["ShippingId"] = new SelectList(_context.Shippings, "Id", "Type");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Name");
            return View();
        }

        // POST: Order/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OrderNumber,UserId,SubTotal,ShippingId,CouponId,TotalAmount,Quantity,PaymentMethod,PaymentStatus,Status,FirstName,LastName,Email,Phone,Country,Address,CreatedAt,UpdatedAt")] Orders orderModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CouponId"] = new SelectList(_context.Coupons, "Id", "Code", orderModel.CouponId);
            ViewData["ShippingId"] = new SelectList(_context.Shippings, "Id", "Type", orderModel.ShippingId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Name", orderModel.UserId);
            return View(orderModel);
        }

        // GET: Order/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderModel = await _context.Orders.FindAsync(id);
            if (orderModel == null)
            {
                return NotFound();
            }
            ViewData["CouponId"] = new SelectList(_context.Coupons, "Id", "Code", orderModel.CouponId);
            ViewData["ShippingId"] = new SelectList(_context.Shippings, "Id", "Type", orderModel.ShippingId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Name", orderModel.UserId);
            return View(orderModel);
        }

        // POST: Order/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,OrderNumber,UserId,SubTotal,ShippingId,CouponId,TotalAmount,Quantity,PaymentMethod,PaymentStatus,Status,FirstName,LastName,Email,Phone,Country,Address,CreatedAt,UpdatedAt")] Orders orderModel)
        {
            if (id != orderModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderModelExists(orderModel.Id))
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
            ViewData["CouponId"] = new SelectList(_context.Coupons, "Id", "Code", orderModel.CouponId);
            ViewData["ShippingId"] = new SelectList(_context.Shippings, "Id", "Type", orderModel.ShippingId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Name", orderModel.UserId);
            return View(orderModel);
        }

        // GET: Order/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderModel = await _context.Orders
                .Include(o => o.Coupon)
                .Include(o => o.Shipping)
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderModel == null)
            {
                return NotFound();
            }

            return View(orderModel);
        }

        // POST: Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var orderModel = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(orderModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderModelExists(long id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
