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
    public class PostCategoryController : Controller
    {
        private readonly ShopContext _context;

        public PostCategoryController(ShopContext context)
        {
            _context = context;
        }

        // GET: PostCategory
        public async Task<IActionResult> Index()
        {
            return View(await _context.PostCategories.ToListAsync());
        }

        // GET: PostCategory/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postCategoryModel = await _context.PostCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postCategoryModel == null)
            {
                return NotFound();
            }

            return View(postCategoryModel);
        }

        // GET: PostCategory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PostCategory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Slug,Status,CreatedAt,UpdatedAt")] PostCategories postCategoryModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(postCategoryModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(postCategoryModel);
        }

        // GET: PostCategory/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postCategoryModel = await _context.PostCategories.FindAsync(id);
            if (postCategoryModel == null)
            {
                return NotFound();
            }
            return View(postCategoryModel);
        }

        // POST: PostCategory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Title,Slug,Status,CreatedAt,UpdatedAt")] PostCategories postCategoryModel)
        {
            if (id != postCategoryModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postCategoryModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostCategoryModelExists(postCategoryModel.Id))
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
            return View(postCategoryModel);
        }

        // GET: PostCategory/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postCategoryModel = await _context.PostCategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postCategoryModel == null)
            {
                return NotFound();
            }

            return View(postCategoryModel);
        }

        // POST: PostCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var postCategoryModel = await _context.PostCategories.FindAsync(id);
            _context.PostCategories.Remove(postCategoryModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostCategoryModelExists(long id)
        {
            return _context.PostCategories.Any(e => e.Id == id);
        }
    }
}
