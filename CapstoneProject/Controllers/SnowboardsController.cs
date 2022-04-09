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
        public async Task<IActionResult> Index()
        {
            return View(await _context.Snowboards.ToListAsync());
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
        public async Task<IActionResult> Create([Bind("Id,TypeId,Brand,Description,Size")] Snowboard snowboard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(snowboard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,TypeId,Brand,Description,Size")] Snowboard snowboard)
        {
            if (id != snowboard.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(snowboard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SnowboardExists(snowboard.Id))
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
            return View(snowboard);
        }

        // GET: Snowboards/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: Snowboards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var snowboard = await _context.Snowboards.FindAsync(id);
            _context.Snowboards.Remove(snowboard);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SnowboardExists(int id)
        {
            return _context.Snowboards.Any(e => e.Id == id);
        }
    }
}
