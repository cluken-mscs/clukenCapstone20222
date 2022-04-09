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
        public async Task<IActionResult> Index()
        {
            return View(await _context.Coats.ToListAsync());
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
        public async Task<IActionResult> Create([Bind("Id,TypeId,Brand,Description,Size")] Coat coat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(coat);
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TypeId,Brand,Description,Size")] Coat coat)
        {
            if (id != coat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoatExists(coat.Id))
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
            return View(coat);
        }

        // GET: Coats/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: Coats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coat = await _context.Coats.FindAsync(id);
            _context.Coats.Remove(coat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoatExists(int id)
        {
            return _context.Coats.Any(e => e.Id == id);
        }
    }
}
