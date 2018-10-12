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
    public class EmployeeTerritoriesController : Controller
    {
        private readonly NorthwindContext _context;

        public EmployeeTerritoriesController(NorthwindContext context)
        {
            _context = context;
        }

        // GET: EmployeeTerritories
        public async Task<IActionResult> Index()
        {
            var northwindContext = _context.EmployeeTerritories.Include(e => e.Employee).Include(e => e.Territory);
            return View(await northwindContext.ToListAsync());
        }

        // GET: EmployeeTerritories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeTerritories = await _context.EmployeeTerritories
                .Include(e => e.Employee)
                .Include(e => e.Territory)
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employeeTerritories == null)
            {
                return NotFound();
            }

            return View(employeeTerritories);
        }

        // GET: EmployeeTerritories/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "FirstName");
            ViewData["TerritoryId"] = new SelectList(_context.Territories, "TerritoryId", "TerritoryId");
            return View();
        }

        // POST: EmployeeTerritories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,TerritoryId")] EmployeeTerritories employeeTerritories)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeTerritories);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "FirstName", employeeTerritories.EmployeeId);
            ViewData["TerritoryId"] = new SelectList(_context.Territories, "TerritoryId", "TerritoryId", employeeTerritories.TerritoryId);
            return View(employeeTerritories);
        }

        // GET: EmployeeTerritories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeTerritories = await _context.EmployeeTerritories.FindAsync(id);
            if (employeeTerritories == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "FirstName", employeeTerritories.EmployeeId);
            ViewData["TerritoryId"] = new SelectList(_context.Territories, "TerritoryId", "TerritoryId", employeeTerritories.TerritoryId);
            return View(employeeTerritories);
        }

        // POST: EmployeeTerritories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,TerritoryId")] EmployeeTerritories employeeTerritories)
        {
            if (id != employeeTerritories.EmployeeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeTerritories);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeTerritoriesExists(employeeTerritories.EmployeeId))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "FirstName", employeeTerritories.EmployeeId);
            ViewData["TerritoryId"] = new SelectList(_context.Territories, "TerritoryId", "TerritoryId", employeeTerritories.TerritoryId);
            return View(employeeTerritories);
        }

        // GET: EmployeeTerritories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeeTerritories = await _context.EmployeeTerritories
                .Include(e => e.Employee)
                .Include(e => e.Territory)
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employeeTerritories == null)
            {
                return NotFound();
            }

            return View(employeeTerritories);
        }

        // POST: EmployeeTerritories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employeeTerritories = await _context.EmployeeTerritories.FindAsync(id);
            _context.EmployeeTerritories.Remove(employeeTerritories);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeTerritoriesExists(int id)
        {
            return _context.EmployeeTerritories.Any(e => e.EmployeeId == id);
        }
    }
}
