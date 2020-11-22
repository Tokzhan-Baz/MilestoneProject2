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
    public class StartupsNewsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StartupsNewsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StartupsNews
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.StartupsNews.Include(s => s.News).Include(s => s.Startups);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: StartupsNews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var startupsNews = await _context.StartupsNews
                .Include(s => s.News)
                .Include(s => s.Startups)
                .FirstOrDefaultAsync(m => m.StartupsId == id);
            if (startupsNews == null)
            {
                return NotFound();
            }

            return View(startupsNews);
        }

        // GET: StartupsNews/Create
        public IActionResult Create()
        {
            ViewData["NewsId"] = new SelectList(_context.News, "Id", "Id");
            ViewData["StartupsId"] = new SelectList(_context.Startups, "Id", "Id");
            return View();
        }

        // POST: StartupsNews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StartupsId,NewsId")] StartupsNews startupsNews)
        {
            if (ModelState.IsValid)
            {
                _context.Add(startupsNews);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["NewsId"] = new SelectList(_context.News, "Id", "Id", startupsNews.NewsId);
            ViewData["StartupsId"] = new SelectList(_context.Startups, "Id", "Id", startupsNews.StartupsId);
            return View(startupsNews);
        }

        // GET: StartupsNews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var startupsNews = await _context.StartupsNews.FindAsync(id);
            if (startupsNews == null)
            {
                return NotFound();
            }
            ViewData["NewsId"] = new SelectList(_context.News, "Id", "Id", startupsNews.NewsId);
            ViewData["StartupsId"] = new SelectList(_context.Startups, "Id", "Id", startupsNews.StartupsId);
            return View(startupsNews);
        }

        // POST: StartupsNews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StartupsId,NewsId")] StartupsNews startupsNews)
        {
            if (id != startupsNews.StartupsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(startupsNews);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StartupsNewsExists(startupsNews.StartupsId))
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
            ViewData["NewsId"] = new SelectList(_context.News, "Id", "Id", startupsNews.NewsId);
            ViewData["StartupsId"] = new SelectList(_context.Startups, "Id", "Id", startupsNews.StartupsId);
            return View(startupsNews);
        }

        // GET: StartupsNews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var startupsNews = await _context.StartupsNews
                .Include(s => s.News)
                .Include(s => s.Startups)
                .FirstOrDefaultAsync(m => m.StartupsId == id);
            if (startupsNews == null)
            {
                return NotFound();
            }

            return View(startupsNews);
        }

        // POST: StartupsNews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var startupsNews = await _context.StartupsNews.FindAsync(id);
            _context.StartupsNews.Remove(startupsNews);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StartupsNewsExists(int id)
        {
            return _context.StartupsNews.Any(e => e.StartupsId == id);
        }
    }
}
