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
    public class PostcategoryController : Controller
    {
        private readonly ShopContext _context;

        public PostcategoryController(ShopContext context)
        {
            _context = context;
        }

        // GET: Postcategory
        public async Task<IActionResult> Index()
        {
            return View(await _context.Postcategories.ToListAsync());
        }

        // GET: Postcategory/Details/5
        public async Task<IActionResult> Details(ulong? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postcategory = await _context.Postcategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postcategory == null)
            {
                return NotFound();
            }

            return View(postcategory);
        }

        // GET: Postcategory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Postcategory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Slug,Status")] Postcategory postcategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(postcategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(postcategory);
        }

        // GET: Postcategory/Edit/5
        public async Task<IActionResult> Edit(ulong? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postcategory = await _context.Postcategories.FindAsync(id);
            if (postcategory == null)
            {
                return NotFound();
            }
            return View(postcategory);
        }

        // POST: Postcategory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ulong id, [Bind("Id,Title,Slug,Status")] Postcategory postcategory)
        {
            if (id != postcategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postcategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostcategoryExists(postcategory.Id))
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
            return View(postcategory);
        }

        // GET: Postcategory/Delete/5
        public async Task<IActionResult> Delete(ulong? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postcategory = await _context.Postcategories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (postcategory == null)
            {
                return NotFound();
            }

            return View(postcategory);
        }

        // POST: Postcategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(ulong id)
        {
            var postcategory = await _context.Postcategories.FindAsync(id);
            _context.Postcategories.Remove(postcategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostcategoryExists(ulong id)
        {
            return _context.Postcategories.Any(e => e.Id == id);
        }
    }
}
