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
    public class BootsController : Controller
    {
        private readonly ProductContext _context;

        public BootsController(ProductContext context)
        {
            _context = context;
        }

        // GET: Boots
        public async Task<IActionResult> Index(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["BrandSortParm"] = String.IsNullOrEmpty(sortOrder) ? "brand_desc" : "";
            ViewData["DescSortParm"] = sortOrder == "Description" ? "desc_desc" : "Description";
            ViewData["CurrentFilter"] = searchString;
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;
            var boots = from b in _context.Boots
                           select b;
            if (!String.IsNullOrEmpty(searchString))
            {
                boots = boots.Where(b => b.Description.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "brand_desc":
                    boots = boots.OrderByDescending(b => b.Brand);
                    break;
                case "Description":
                    boots = boots.OrderBy(b => b.Description);
                    break;
                case "desc_desc":
                    boots = boots.OrderByDescending(b => b.Description);
                    break;
                default:
                    boots = boots.OrderBy(b => b.Brand);
                    break;
            }
            int pageSize = 3;
            return View(await PaginatedList<Boot>.CreateAsync(boots.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Boots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boot = await _context.Boots
                .FirstOrDefaultAsync(m => m.Id == id);
            if (boot == null)
            {
                return NotFound();
            }

            return View(boot);
        }

        // GET: Boots/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Boots/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("TypeId,Brand,Description,Size")] Boot boot)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(boot);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. " + "see your system administrator.");
            }

            return View(boot);
        }

        // GET: Boots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boot = await _context.Boots.FindAsync(id);
            if (boot == null)
            {
                return NotFound();
            }
            return View(boot);
        }

        // POST: Boots/Edit/5
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
            var bootToUpdate = await _context.Boots.FirstOrDefaultAsync(s => s.Id == id);
            if (await TryUpdateModelAsync<Boot>(
                bootToUpdate,
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
            return View(bootToUpdate);
        }

        // GET: Boots/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boot = await _context.Boots
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (boot == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete failed. Try again, and if the problem persists " +
                    "see your system administrator.";
            }
            return View(boot);
        }

        // POST: Boots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var boot = await _context.Boots.FindAsync(id);
            if (boot == null)
            {
                return RedirectToAction(nameof(Index));
            }
            try
            {
                _context.Boots.Remove(boot);
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
