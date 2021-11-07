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
    public class PostcommentController : Controller
    {
        private readonly ShopContext _context;

        public PostcommentController(ShopContext context)
        {
            _context = context;
        }

        // GET: Postcomment
        public async Task<IActionResult> Index()
        {
            var shopContext = _context.Postcomments.Include(p => p.Post).Include(p => p.User);
            return View(await shopContext.ToListAsync());
        }

        // GET: Postcomment/Details/5
        public async Task<IActionResult> Details(ulong? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postcomment = await _context.Postcomments
                .Include(p => p.Post)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postcomment == null)
            {
                return NotFound();
            }

            return View(postcomment);
        }

        // GET: Postcomment/Create
        public IActionResult Create()
        {
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Slug");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Fullname");
            return View();
        }

        // POST: Postcomment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,PostId,Comments,Status,ParentId")] Postcomment postcomment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(postcomment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Slug", postcomment.PostId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Fullname", postcomment.UserId);
            return View(postcomment);
        }

        // GET: Postcomment/Edit/5
        public async Task<IActionResult> Edit(ulong? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postcomment = await _context.Postcomments.FindAsync(id);
            if (postcomment == null)
            {
                return NotFound();
            }
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Slug", postcomment.PostId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Fullname", postcomment.UserId);
            return View(postcomment);
        }

        // POST: Postcomment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ulong id, [Bind("Id,UserId,PostId,Comments,Status,ParentId")] Postcomment postcomment)
        {
            if (id != postcomment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postcomment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostcommentExists(postcomment.Id))
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
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Slug", postcomment.PostId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Fullname", postcomment.UserId);
            return View(postcomment);
        }

        // GET: Postcomment/Delete/5
        public async Task<IActionResult> Delete(ulong? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postcomment = await _context.Postcomments
                .Include(p => p.Post)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postcomment == null)
            {
                return NotFound();
            }

            return View(postcomment);
        }

        // POST: Postcomment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(ulong id)
        {
            var postcomment = await _context.Postcomments.FindAsync(id);
            _context.Postcomments.Remove(postcomment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostcommentExists(ulong id)
        {
            return _context.Postcomments.Any(e => e.Id == id);
        }
    }
}
