using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Northwind.Core.Domain.Entities;
using Northwind.Core.Infra.Context;

namespace Northwind.Core.Web.Controllers
{
    public class TerritoriesController : Controller
    {
        private readonly NorthwindContext _context;

        public TerritoriesController(NorthwindContext context)
        {
            _context = context;
        }

        // GET: Territories
        public async Task<IActionResult> Index()
        {
            var northwindContext = _context.Territories.Include(t => t.Region);
            return View(await northwindContext.ToListAsync());
        }

        // GET: Territories/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var territories = await _context.Territories
                .Include(t => t.Region)
                .FirstOrDefaultAsync(m => m.TerritoryId == id);
            if (territories == null)
            {
                return NotFound();
            }

            return View(territories);
        }

        // GET: Territories/Create
        public IActionResult Create()
        {
            ViewData["RegionId"] = new SelectList(_context.Region, "RegionId", "RegionDescription");
            return View();
        }

        // POST: Territories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TerritoryId,TerritoryDescription,RegionId")] Territories territories)
        {
            if (ModelState.IsValid)
            {
                _context.Add(territories);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RegionId"] = new SelectList(_context.Region, "RegionId", "RegionDescription", territories.RegionId);
            return View(territories);
        }

        // GET: Territories/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var territories = await _context.Territories.FindAsync(id);
            if (territories == null)
            {
                return NotFound();
            }
            ViewData["RegionId"] = new SelectList(_context.Region, "RegionId", "RegionDescription", territories.RegionId);
            return View(territories);
        }

        // POST: Territories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("TerritoryId,TerritoryDescription,RegionId")] Territories territories)
        {
            if (id != territories.TerritoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(territories);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TerritoriesExists(territories.TerritoryId))
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
            ViewData["RegionId"] = new SelectList(_context.Region, "RegionId", "RegionDescription", territories.RegionId);
            return View(territories);
        }

        // GET: Territories/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var territories = await _context.Territories
                .Include(t => t.Region)
                .FirstOrDefaultAsync(m => m.TerritoryId == id);
            if (territories == null)
            {
                return NotFound();
            }

            return View(territories);
        }

        // POST: Territories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var territories = await _context.Territories.FindAsync(id);
            _context.Territories.Remove(territories);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TerritoriesExists(string id)
        {
            return _context.Territories.Any(e => e.TerritoryId == id);
        }
    }
}
