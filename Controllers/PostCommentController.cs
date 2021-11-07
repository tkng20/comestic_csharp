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
    public class PostCommentController : Controller
    {
        private readonly ShopContext _context;

        public PostCommentController(ShopContext context)
        {
            _context = context;
        }

        // GET: PostComment
        public async Task<IActionResult> Index()
        {
            var shopContext = _context.PostComments.Include(p => p.Post).Include(p => p.User);
            return View(await shopContext.ToListAsync());
        }

        // GET: PostComment/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postCommentModel = await _context.PostComments
                .Include(p => p.Post)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postCommentModel == null)
            {
                return NotFound();
            }

            return View(postCommentModel);
        }

        // GET: PostComment/Create
        public IActionResult Create()
        {
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Slug");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Name");
            return View();
        }

        // POST: PostComment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,PostId,Comment,Status,ParentId,CreatedAt,UpdatedAt")] PostComments postCommentModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(postCommentModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Slug", postCommentModel.PostId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Name", postCommentModel.UserId);
            return View(postCommentModel);
        }

        // GET: PostComment/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postCommentModel = await _context.PostComments.FindAsync(id);
            if (postCommentModel == null)
            {
                return NotFound();
            }
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Slug", postCommentModel.PostId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Name", postCommentModel.UserId);
            return View(postCommentModel);
        }

        // POST: PostComment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,UserId,PostId,Comment,Status,ParentId,CreatedAt,UpdatedAt")] PostComments postCommentModel)
        {
            if (id != postCommentModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postCommentModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostCommentModelExists(postCommentModel.Id))
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
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Slug", postCommentModel.PostId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Name", postCommentModel.UserId);
            return View(postCommentModel);
        }

        // GET: PostComment/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postCommentModel = await _context.PostComments
                .Include(p => p.Post)
                .Include(p => p.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postCommentModel == null)
            {
                return NotFound();
            }

            return View(postCommentModel);
        }

        // POST: PostComment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var postCommentModel = await _context.PostComments.FindAsync(id);
            _context.PostComments.Remove(postCommentModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostCommentModelExists(long id)
        {
            return _context.PostComments.Any(e => e.Id == id);
        }
    }
}
