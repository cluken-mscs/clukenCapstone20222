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
    public class SnowboardsController : Controller
    {
        private readonly ProductContext _context;

        public SnowboardsController(ProductContext context)
        {
            _context = context;
        }

        // GET: Snowboards
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
            var snowboards = from s in _context.Snowboards
                        select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                snowboards = snowboards.Where(s => s.Description.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "brand_desc":
                    snowboards = snowboards.OrderByDescending(s => s.Brand);
                    break;
                case "Description":
                    snowboards = snowboards.OrderBy(s => s.Description);
                    break;
                case "desc_desc":
                    snowboards = snowboards.OrderByDescending(s => s.Description);
                    break;
                default:
                    snowboards = snowboards.OrderBy(s => s.Brand);
                    break;
            }
            int pageSize = 3;
            return View(await PaginatedList<Snowboard>.CreateAsync(snowboards.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Snowboards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var snowboard = await _context.Snowboards
                .FirstOrDefaultAsync(m => m.Id == id);
            if (snowboard == null)
            {
                return NotFound();
            }

            return View(snowboard);
        }

        // GET: Snowboards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Snowboards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypeId,Brand,Description,Size")] Snowboard snowboard)
        {
            try
            {
            if (ModelState.IsValid)
                {
                    _context.Add(snowboard);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. " + "see your system administrator.");
            }
            return View(snowboard);
        }

        // GET: Snowboards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var snowboard = await _context.Snowboards.FindAsync(id);
            if (snowboard == null)
            {
                return NotFound();
            }
            return View(snowboard);
        }

        // POST: Snowboards/Edit/5
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
            var snowboardToUpdate = await _context.Snowboards.FirstOrDefaultAsync(s => s.Id == id);
            if (await TryUpdateModelAsync<Snowboard>(
                snowboardToUpdate,
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
            return View(snowboardToUpdate);
        }

        // GET: Snowboards/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var snowboard = await _context.Snowboards
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (snowboard == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete failed. Try again, and if the problem persists " +
                    "see your system administrator.";
            }
            return View(snowboard);
        }

        // POST: Snowboards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var snowboard = await _context.Snowboards.FindAsync(id);
            if (snowboard == null)
            {
                return RedirectToAction(nameof(Index));
            }
            try
            {
                _context.Snowboards.Remove(snowboard);
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
