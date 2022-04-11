using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CapstoneProject.Data;
using CapstoneProject.Models;

namespace CapstoneProject.Controllers
{
    public class HelmetsController : Controller
    {
        private readonly ProductContext _context;

        public HelmetsController(ProductContext context)
        {
            _context = context;
        }

        // GET: Helmets
        public async Task<IActionResult> Index()
        {
            return View(await _context.Helmets.ToListAsync());
        }

        // GET: Helmets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var helmet = await _context.Helmets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (helmet == null)
            {
                return NotFound();
            }

            return View(helmet);
        }

        // GET: Helmets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Helmets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypeId,Brand,Description,Size")] Helmet helmet)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(helmet);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. " + "see your system administrator.");
            }
            return View(helmet);
        }

        // GET: Helmets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var helmet = await _context.Helmets.FindAsync(id);
            if (helmet == null)
            {
                return NotFound();
            }
            return View(helmet);
        }

        // POST: Helmets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var helmetToUpdate = await _context.Helmets.FirstOrDefaultAsync(s => s.Id == id);
            if (await TryUpdateModelAsync<Helmet>(
                helmetToUpdate,
                "",
                s => s.Brand, s => s.Description, s => s.Size))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
            return View(helmetToUpdate);
        }

        // GET: Helmets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var helmet = await _context.Helmets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (helmet == null)
            {
                return NotFound();
            }

            return View(helmet);
        }

        // POST: Helmets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var helmet = await _context.Helmets.FindAsync(id);
            if (helmet == null)
            {
                return RedirectToAction(nameof(Index));
            }
            try
            {
                _context.Helmets.Remove(helmet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {
                return RedirectToAction(nameof(Delete), new { id = id, saveChangesError = true });
            }
        }
    }
}
