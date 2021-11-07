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
    public class CategoryController : Controller
    {
        private readonly ShopContext _context;

        public CategoryController(ShopContext context)
        {
            _context = context;
        }

        // GET: Category
        public async Task<IActionResult> Index()
        {
            var shopContext = _context.Categories.Include(c => c.AddedByNavigation).Include(c => c.Parent);
            return View(await shopContext.ToListAsync());
        }

        // GET: Category/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryModel = await _context.Categories
                .Include(c => c.AddedByNavigation)
                .Include(c => c.Parent)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoryModel == null)
            {
                return NotFound();
            }

            return View(categoryModel);
        }

        // GET: Category/Create
        public IActionResult Create()
        {
            ViewData["AddedBy"] = new SelectList(_context.Users, "Id", "Name");
            ViewData["ParentId"] = new SelectList(_context.Categories, "Id", "Slug");
            return View();
        }

        // POST: Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Slug,Summary,Photo,IsParent,ParentId,AddedBy,Status,CreatedAt,UpdatedAt")] Categories categoryModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoryModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddedBy"] = new SelectList(_context.Users, "Id", "Name", categoryModel.AddedBy);
            ViewData["ParentId"] = new SelectList(_context.Categories, "Id", "Slug", categoryModel.ParentId);
            return View(categoryModel);
        }

        // GET: Category/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryModel = await _context.Categories.FindAsync(id);
            if (categoryModel == null)
            {
                return NotFound();
            }
            ViewData["AddedBy"] = new SelectList(_context.Users, "Id", "Name", categoryModel.AddedBy);
            ViewData["ParentId"] = new SelectList(_context.Categories, "Id", "Slug", categoryModel.ParentId);
            return View(categoryModel);
        }

        // POST: Category/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Title,Slug,Summary,Photo,IsParent,ParentId,AddedBy,Status,CreatedAt,UpdatedAt")] Categories categoryModel)
        {
            if (id != categoryModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoryModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryModelExists(categoryModel.Id))
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
            ViewData["AddedBy"] = new SelectList(_context.Users, "Id", "Name", categoryModel.AddedBy);
            ViewData["ParentId"] = new SelectList(_context.Categories, "Id", "Slug", categoryModel.ParentId);
            return View(categoryModel);
        }

        // GET: Category/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryModel = await _context.Categories
                .Include(c => c.AddedByNavigation)
                .Include(c => c.Parent)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoryModel == null)
            {
                return NotFound();
            }

            return View(categoryModel);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var categoryModel = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(categoryModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryModelExists(long id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
