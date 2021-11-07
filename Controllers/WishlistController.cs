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
    public class WishlistController : Controller
    {
        private readonly ShopContext _context;

        public WishlistController(ShopContext context)
        {
            _context = context;
        }

        // GET: Wishlist
        public async Task<IActionResult> Index()
        {
            var shopContext = _context.Wishlists.Include(w => w.Cart).Include(w => w.Product).Include(w => w.User);
            return View(await shopContext.ToListAsync());
        }

        // GET: Wishlist/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wishlistModel = await _context.Wishlists
                .Include(w => w.Cart)
                .Include(w => w.Product)
                .Include(w => w.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wishlistModel == null)
            {
                return NotFound();
            }

            return View(wishlistModel);
        }

        // GET: Wishlist/Create
        public IActionResult Create()
        {
            ViewData["CartId"] = new SelectList(_context.Carts, "Id", "Id");
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Color");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Name");
            return View();
        }

        // POST: Wishlist/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductId,CartId,UserId,Price,Quantity,Amount,CreatedAt,UpdatedAt")] Wishlists wishlistModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wishlistModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CartId"] = new SelectList(_context.Carts, "Id", "Id", wishlistModel.CartId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Color", wishlistModel.ProductId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Name", wishlistModel.UserId);
            return View(wishlistModel);
        }

        // GET: Wishlist/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wishlistModel = await _context.Wishlists.FindAsync(id);
            if (wishlistModel == null)
            {
                return NotFound();
            }
            ViewData["CartId"] = new SelectList(_context.Carts, "Id", "Id", wishlistModel.CartId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Color", wishlistModel.ProductId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Name", wishlistModel.UserId);
            return View(wishlistModel);
        }

        // POST: Wishlist/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,ProductId,CartId,UserId,Price,Quantity,Amount,CreatedAt,UpdatedAt")] Wishlists wishlistModel)
        {
            if (id != wishlistModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wishlistModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WishlistModelExists(wishlistModel.Id))
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
            ViewData["CartId"] = new SelectList(_context.Carts, "Id", "Id", wishlistModel.CartId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Color", wishlistModel.ProductId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Name", wishlistModel.UserId);
            return View(wishlistModel);
        }

        // GET: Wishlist/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wishlistModel = await _context.Wishlists
                .Include(w => w.Cart)
                .Include(w => w.Product)
                .Include(w => w.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wishlistModel == null)
            {
                return NotFound();
            }

            return View(wishlistModel);
        }

        // POST: Wishlist/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var wishlistModel = await _context.Wishlists.FindAsync(id);
            _context.Wishlists.Remove(wishlistModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WishlistModelExists(long id)
        {
            return _context.Wishlists.Any(e => e.Id == id);
        }
    }
}
