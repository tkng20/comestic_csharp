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
    public class PostController : Controller
    {
        private readonly ShopContext _context;

        public PostController(ShopContext context)
        {
            _context = context;
        }

        // GET: Post
        public async Task<IActionResult> Index()
        {
            var shopContext = _context.Posts.Include(p => p.AddedByNavigation).Include(p => p.PostCat).Include(p => p.PostTag);
            return View(await shopContext.ToListAsync());
        }

        // GET: Post/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postModel = await _context.Posts
                .Include(p => p.AddedByNavigation)
                .Include(p => p.PostCat)
                .Include(p => p.PostTag)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postModel == null)
            {
                return NotFound();
            }

            return View(postModel);
        }

        // GET: Post/Create
        public IActionResult Create()
        {
            ViewData["AddedBy"] = new SelectList(_context.Users, "Id", "Name");
            ViewData["PostCatId"] = new SelectList(_context.PostCategories, "Id", "Slug");
            ViewData["PostTagId"] = new SelectList(_context.PostTags, "Id", "Slug");
            return View();
        }

        // POST: Post/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Slug,Summary,Description,Quote,Photo,Tags,PostCatId,PostTagId,AddedBy,Status,CreatedAt,UpdatedAt")] Posts postModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(postModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddedBy"] = new SelectList(_context.Users, "Id", "Name", postModel.AddedBy);
            ViewData["PostCatId"] = new SelectList(_context.PostCategories, "Id", "Slug", postModel.PostCatId);
            ViewData["PostTagId"] = new SelectList(_context.PostTags, "Id", "Slug", postModel.PostTagId);
            return View(postModel);
        }

        // GET: Post/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postModel = await _context.Posts.FindAsync(id);
            if (postModel == null)
            {
                return NotFound();
            }
            ViewData["AddedBy"] = new SelectList(_context.Users, "Id", "Name", postModel.AddedBy);
            ViewData["PostCatId"] = new SelectList(_context.PostCategories, "Id", "Slug", postModel.PostCatId);
            ViewData["PostTagId"] = new SelectList(_context.PostTags, "Id", "Slug", postModel.PostTagId);
            return View(postModel);
        }

        // POST: Post/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Title,Slug,Summary,Description,Quote,Photo,Tags,PostCatId,PostTagId,AddedBy,Status,CreatedAt,UpdatedAt")] Posts postModel)
        {
            if (id != postModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostModelExists(postModel.Id))
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
            ViewData["AddedBy"] = new SelectList(_context.Users, "Id", "Name", postModel.AddedBy);
            ViewData["PostCatId"] = new SelectList(_context.PostCategories, "Id", "Slug", postModel.PostCatId);
            ViewData["PostTagId"] = new SelectList(_context.PostTags, "Id", "Slug", postModel.PostTagId);
            return View(postModel);
        }

        // GET: Post/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postModel = await _context.Posts
                .Include(p => p.AddedByNavigation)
                .Include(p => p.PostCat)
                .Include(p => p.PostTag)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postModel == null)
            {
                return NotFound();
            }

            return View(postModel);
        }

        // POST: Post/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var postModel = await _context.Posts.FindAsync(id);
            _context.Posts.Remove(postModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostModelExists(long id)
        {
            return _context.Posts.Any(e => e.Id == id);
        }
    }
}
