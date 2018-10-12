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
    public class CustomerDemographicsController : Controller
    {
        private readonly NorthwindContext _context;

        public CustomerDemographicsController(NorthwindContext context)
        {
            _context = context;
        }

        // GET: CustomerDemographics
        public async Task<IActionResult> Index()
        {
            return View(await _context.CustomerDemographics.ToListAsync());
        }

        // GET: CustomerDemographics/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerDemographics = await _context.CustomerDemographics
                .FirstOrDefaultAsync(m => m.CustomerTypeId == id);
            if (customerDemographics == null)
            {
                return NotFound();
            }

            return View(customerDemographics);
        }

        // GET: CustomerDemographics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomerDemographics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerTypeId,CustomerDesc")] CustomerDemographics customerDemographics)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerDemographics);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customerDemographics);
        }

        // GET: CustomerDemographics/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerDemographics = await _context.CustomerDemographics.FindAsync(id);
            if (customerDemographics == null)
            {
                return NotFound();
            }
            return View(customerDemographics);
        }

        // POST: CustomerDemographics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CustomerTypeId,CustomerDesc")] CustomerDemographics customerDemographics)
        {
            if (id != customerDemographics.CustomerTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerDemographics);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerDemographicsExists(customerDemographics.CustomerTypeId))
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
            return View(customerDemographics);
        }

        // GET: CustomerDemographics/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerDemographics = await _context.CustomerDemographics
                .FirstOrDefaultAsync(m => m.CustomerTypeId == id);
            if (customerDemographics == null)
            {
                return NotFound();
            }

            return View(customerDemographics);
        }

        // POST: CustomerDemographics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var customerDemographics = await _context.CustomerDemographics.FindAsync(id);
            _context.CustomerDemographics.Remove(customerDemographics);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerDemographicsExists(string id)
        {
            return _context.CustomerDemographics.Any(e => e.CustomerTypeId == id);
        }
    }
}
