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
    public class BannerController : Controller
    {
        private readonly ShopContext _context;

        public BannerController(ShopContext context)
        {
            _context = context;
        }

        // GET: Banner
        public async Task<IActionResult> Index()
        {
            return View(await _context.Banners.ToListAsync());
        }

        // GET: Banner/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bannerModel = await _context.Banners
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bannerModel == null)
            {
                return NotFound();
            }

            return View(bannerModel);
        }

        // GET: Banner/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Banner/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Slug,Photo,Description,Status,CreatedAt,UpdatedAt")] Banners bannerModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bannerModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bannerModel);
        }

        // GET: Banner/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bannerModel = await _context.Banners.FindAsync(id);
            if (bannerModel == null)
            {
                return NotFound();
            }
            return View(bannerModel);
        }

        // POST: Banner/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Title,Slug,Photo,Description,Status,CreatedAt,UpdatedAt")] Banners banner)
        {
            if (id != banner.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(banner);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BannerModelExists(banner.Id))
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
            return View(banner);
        }

        // GET: Banner/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bannerModel = await _context.Banners
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bannerModel == null)
            {
                return NotFound();
            }

            return View(bannerModel);
        }

        // POST: Banner/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var bannerModel = await _context.Banners.FindAsync(id);
            _context.Banners.Remove(bannerModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BannerModelExists(long id)
        {
            return _context.Banners.Any(e => e.Id == id);
        }
    }
}
