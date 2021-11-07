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
    public class NotificationController : Controller
    {
        private readonly ShopContext _context;

        public NotificationController(ShopContext context)
        {
            _context = context;
        }

        // GET: Notification
        public async Task<IActionResult> Index()
        {
            return View(await _context.Notifications.ToListAsync());
        }

        // GET: Notification/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notificationModel = await _context.Notifications
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notificationModel == null)
            {
                return NotFound();
            }

            return View(notificationModel);
        }

        // GET: Notification/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Notification/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,NotifiableType,NotifiableId,Data,ReadAt,CreatedAt,UpdatedAt")] Notifications notificationModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(notificationModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(notificationModel);
        }

        // GET: Notification/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notificationModel = await _context.Notifications.FindAsync(id);
            if (notificationModel == null)
            {
                return NotFound();
            }
            return View(notificationModel);
        }

        // POST: Notification/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Type,NotifiableType,NotifiableId,Data,ReadAt,CreatedAt,UpdatedAt")] Notifications notificationModel)
        {
            if (id != notificationModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notificationModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotificationModelExists(notificationModel.Id))
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
            return View(notificationModel);
        }

        // GET: Notification/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notificationModel = await _context.Notifications
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notificationModel == null)
            {
                return NotFound();
            }

            return View(notificationModel);
        }

        // POST: Notification/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var notificationModel = await _context.Notifications.FindAsync(id);
            _context.Notifications.Remove(notificationModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotificationModelExists(string id)
        {
            return _context.Notifications.Any(e => e.Id == id);
        }
    }
}
