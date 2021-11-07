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
    public class CartController : Controller
    {
        private readonly ShopContext _context;

        public CartController(ShopContext context)
        {
            _context = context;
        }

        // GET: Cart
        public async Task<IActionResult> Index()
        {
            var shopContext = _context.Carts.Include(c => c.Order).Include(c => c.Product).Include(c => c.User);
            return View(await shopContext.ToListAsync());
        }

        // GET: Cart/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartModel = await _context.Carts
                .Include(c => c.Order)
                .Include(c => c.Product)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cartModel == null)
            {
                return NotFound();
            }

            return View(cartModel);
        }

        // GET: Cart/Create
        public IActionResult Create()
        {
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Address");
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Color");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Name");
            return View();
        }

        // POST: Cart/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductId,OrderId,UserId,Price,Status,Quantity,Amount,CreatedAt,UpdatedAt")] Carts cartModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cartModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Address", cartModel.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Color", cartModel.ProductId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Name", cartModel.UserId);
            return View(cartModel);
        }

        // GET: Cart/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartModel = await _context.Carts.FindAsync(id);
            if (cartModel == null)
            {
                return NotFound();
            }
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Address", cartModel.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Color", cartModel.ProductId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Name", cartModel.UserId);
            return View(cartModel);
        }

        // POST: Cart/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,ProductId,OrderId,UserId,Price,Status,Quantity,Amount,CreatedAt,UpdatedAt")] Carts cartModel)
        {
            if (id != cartModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cartModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartModelExists(cartModel.Id))
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
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Address", cartModel.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Color", cartModel.ProductId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Name", cartModel.UserId);
            return View(cartModel);
        }

        // GET: Cart/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartModel = await _context.Carts
                .Include(c => c.Order)
                .Include(c => c.Product)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cartModel == null)
            {
                return NotFound();
            }

            return View(cartModel);
        }

        // POST: Cart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var cartModel = await _context.Carts.FindAsync(id);
            _context.Carts.Remove(cartModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CartModelExists(long id)
        {
            return _context.Carts.Any(e => e.Id == id);
        }
    }
}
