using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WPFW_week13.Data;
using WPFW_week13.Models;

namespace WPFW_week13.Controllers
{
    [Authorize]
    public class TestResultsController : Controller
    {
        private readonly WPFW_week13Context _context;

        public TestResultsController(WPFW_week13Context context)
        {
            _context = context;
        }

        // GET: TestResults
        public async Task<IActionResult> Index()
        {
            return View(await _context.TestResults.ToListAsync());
        }

        // POST: TestResults
        [HttpPost]
        public async Task<IActionResult> Index(string FilterText)
        {
            if (FilterText != null || FilterText != "") return View(await _context.TestResults.Where(a => a.StudentName.Contains(FilterText)).ToListAsync());
            return View(await _context.TestResults.ToListAsync());
        }

        // GET: TestResults/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testResults = await _context.TestResults
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testResults == null)
            {
                return NotFound();
            }

            return View(testResults);
        }

        // GET: TestResults/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TestResults/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StudentName,Result")] TestResults testResults)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testResults);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(testResults);
        }

        // GET: TestResults/Edit/5
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testResults = await _context.TestResults.FindAsync(id);
            if (testResults == null)
            {
                return NotFound();
            }
            return View(testResults);
        }

        // POST: TestResults/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StudentName,Result")] TestResults testResults)
        {
            if (id != testResults.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testResults);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestResultsExists(testResults.Id))
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
            return View(testResults);
        }

        // GET: TestResults/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testResults = await _context.TestResults
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testResults == null)
            {
                return NotFound();
            }

            return View(testResults);
        }

        // POST: TestResults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var testResults = await _context.TestResults.FindAsync(id);
            _context.TestResults.Remove(testResults);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestResultsExists(int id)
        {
            return _context.TestResults.Any(e => e.Id == id);
        }
    }
}
