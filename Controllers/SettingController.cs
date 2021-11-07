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
    public class SettingController : Controller
    {
        private readonly ShopContext _context;

        public SettingController(ShopContext context)
        {
            _context = context;
        }

        // GET: Setting
        public async Task<IActionResult> Index()
        {
            return View(await _context.Settings.ToListAsync());
        }

        // GET: Setting/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var settingModel = await _context.Settings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (settingModel == null)
            {
                return NotFound();
            }

            return View(settingModel);
        }

        // GET: Setting/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Setting/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,ShortDes,Logo,Photo,Address,Phone,Email,CreatedAt,UpdatedAt")] Settings settingModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(settingModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(settingModel);
        }

        // GET: Setting/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var settingModel = await _context.Settings.FindAsync(id);
            if (settingModel == null)
            {
                return NotFound();
            }
            return View(settingModel);
        }

        // POST: Setting/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Description,ShortDes,Logo,Photo,Address,Phone,Email,CreatedAt,UpdatedAt")] Settings settingModel)
        {
            if (id != settingModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(settingModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SettingModelExists(settingModel.Id))
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
            return View(settingModel);
        }

        // GET: Setting/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var settingModel = await _context.Settings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (settingModel == null)
            {
                return NotFound();
            }

            return View(settingModel);
        }

        // POST: Setting/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var settingModel = await _context.Settings.FindAsync(id);
            _context.Settings.Remove(settingModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SettingModelExists(long id)
        {
            return _context.Settings.Any(e => e.Id == id);
        }
    }
}
