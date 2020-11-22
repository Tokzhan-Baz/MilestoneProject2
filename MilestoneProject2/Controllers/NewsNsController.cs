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
    public class NewsNsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NewsNsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NewsNs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.NewsNs.Include(n => n.News);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: NewsNs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsN = await _context.NewsNs
                .Include(n => n.News)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (newsN == null)
            {
                return NotFound();
            }

            return View(newsN);
        }

        // GET: NewsNs/Create
        public IActionResult Create()
        {
            ViewData["NewsId"] = new SelectList(_context.News, "Id", "Id");
            return View();
        }

        // POST: NewsNs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Number,NewsId")] NewsN newsN)
        {
            if (ModelState.IsValid)
            {
                _context.Add(newsN);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NewsId"] = new SelectList(_context.News, "Id", "Id", newsN.NewsId);
            return View(newsN);
        }

        // GET: NewsNs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsN = await _context.NewsNs.FindAsync(id);
            if (newsN == null)
            {
                return NotFound();
            }
            ViewData["NewsId"] = new SelectList(_context.News, "Id", "Id", newsN.NewsId);
            return View(newsN);
        }

        // POST: NewsNs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Number,NewsId")] NewsN newsN)
        {
            if (id != newsN.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(newsN);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsNExists(newsN.Id))
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
            ViewData["NewsId"] = new SelectList(_context.News, "Id", "Id", newsN.NewsId);
            return View(newsN);
        }

        // GET: NewsNs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var newsN = await _context.NewsNs
                .Include(n => n.News)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (newsN == null)
            {
                return NotFound();
            }

            return View(newsN);
        }

        // POST: NewsNs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var newsN = await _context.NewsNs.FindAsync(id);
            _context.NewsNs.Remove(newsN);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewsNExists(int id)
        {
            return _context.NewsNs.Any(e => e.Id == id);
        }
    }
}
