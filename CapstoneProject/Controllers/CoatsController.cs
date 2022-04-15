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
    public class CoatsController : Controller
    {
        private readonly ProductContext _context;

        public CoatsController(ProductContext context)
        {
            _context = context;
        }

        // GET: Coats
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
            var coats = from b in _context.Coats
                        select b;
            if (!String.IsNullOrEmpty(searchString))
            {
                coats = coats.Where(c => c.Description.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "brand_desc":
                    coats = coats.OrderByDescending(c => c.Brand);
                    break;
                case "Description":
                    coats = coats.OrderBy(c => c.Description);
                    break;
                case "desc_desc":
                    coats = coats.OrderByDescending(c => c.Description);
                    break;
                default:
                    coats = coats.OrderBy(c => c.Brand);
                    break;
            }
            int pageSize = 3;
            return View(await PaginatedList<Coat>.CreateAsync(coats.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Coats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coat = await _context.Coats
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coat == null)
            {
                return NotFound();
            }

            return View(coat);
        }

        // GET: Coats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Coats/Create
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
            var coatToUpdate = await _context.Coats.FirstOrDefaultAsync(s => s.Id == id);
            if (await TryUpdateModelAsync<Coat>(
                coatToUpdate,
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
            return View(coatToUpdate);
        }

        // GET: Coats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coat = await _context.Coats.FindAsync(id);
            if (coat == null)
            {
                return NotFound();
            }
            return View(coat);
        }

        // POST: Coats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,TypeId,Brand,Description,Size")] Coat coat)
        //{
        //    if (id != coat.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(coat);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!CoatExists(coat.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(coat);
        //}

        // GET: Coats/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coat = await _context.Coats
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coat == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewData["ErrorMessage"] =
                    "Delete failed. Try again, and if the problem persists " +
                    "see your system administrator.";
            }
            return View(coat);
        }

        // POST: Coats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coat = await _context.Coats.FindAsync(id);
            if (coat == null)
            {
                return RedirectToAction(nameof(Index));
            }
            try
            {
                _context.Coats.Remove(coat);
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
