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
    public class PostTagController : Controller
    {
        private readonly ShopContext _context;

        public PostTagController(ShopContext context)
        {
            _context = context;
        }

        // GET: PostTag
        public async Task<IActionResult> Index()
        {
            return View(await _context.PostTags.ToListAsync());
        }

        // GET: PostTag/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postTagModel = await _context.PostTags
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postTagModel == null)
            {
                return NotFound();
            }

            return View(postTagModel);
        }

        // GET: PostTag/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PostTag/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Slug,Status,CreatedAt,UpdatedAt")] PostTags postTagModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(postTagModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(postTagModel);
        }

        // GET: PostTag/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postTagModel = await _context.PostTags.FindAsync(id);
            if (postTagModel == null)
            {
                return NotFound();
            }
            return View(postTagModel);
        }

        // POST: PostTag/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Title,Slug,Status,CreatedAt,UpdatedAt")] PostTags postTagModel)
        {
            if (id != postTagModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postTagModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostTagModelExists(postTagModel.Id))
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
            return View(postTagModel);
        }

        // GET: PostTag/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postTagModel = await _context.PostTags
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postTagModel == null)
            {
                return NotFound();
            }

            return View(postTagModel);
        }

        // POST: PostTag/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var postTagModel = await _context.PostTags.FindAsync(id);
            _context.PostTags.Remove(postTagModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostTagModelExists(long id)
        {
            return _context.PostTags.Any(e => e.Id == id);
        }
    }
}
