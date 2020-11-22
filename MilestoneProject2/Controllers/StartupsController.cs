using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MilestoneProject2.Data;
using MilestoneProject2.Models;

namespace MilestoneProject2.Controllers
{
    public class StartupsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StartupsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Startups
        public async Task<IActionResult> Index()
        {
            return View(await _context.Startups.ToListAsync());
        }

        // GET: Startups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var startups = await _context.Startups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (startups == null)
            {
                return NotFound();
            }

            return View(startups);
        }

        // GET: Startups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Startups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Poster,Texts,Country,AboutProject")] Startups startups)
        {
            if (ModelState.IsValid)
            {
                _context.Add(startups);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(startups);
        }

        // GET: Startups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var startups = await _context.Startups.FindAsync(id);
            if (startups == null)
            {
                return NotFound();
            }
            return View(startups);
        }

        // POST: Startups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Poster,Texts,Country,AboutProject")] Startups startups)
        {
            if (id != startups.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(startups);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StartupsExists(startups.Id))
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
            return View(startups);
        }

        // GET: Startups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var startups = await _context.Startups
                .FirstOrDefaultAsync(m => m.Id == id);
            if (startups == null)
            {
                return NotFound();
            }

            return View(startups);
        }

        // POST: Startups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var startups = await _context.Startups.FindAsync(id);
            _context.Startups.Remove(startups);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StartupsExists(int id)
        {
            return _context.Startups.Any(e => e.Id == id);
        }
    }
}
