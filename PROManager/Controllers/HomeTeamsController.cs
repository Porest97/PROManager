using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PROManager.Models;

namespace PROManager.Controllers
{
    public class HomeTeamsController : Controller
    {
        private readonly PROManagerContext _context;

        public HomeTeamsController(PROManagerContext context)
        {
            _context = context;
        }

        // GET: HomeTeams
        public async Task<IActionResult> Index()
        {
            var pROManagerContext = _context.HomeTeam.Include(h => h.Team);
            return View(await pROManagerContext.ToListAsync());
        }

        // GET: HomeTeams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homeTeam = await _context.HomeTeam
                .Include(h => h.Team)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (homeTeam == null)
            {
                return NotFound();
            }

            return View(homeTeam);
        }

        // GET: HomeTeams/Create
        public IActionResult Create()
        {
            ViewData["TeamId"] = new SelectList(_context.Team, "Id", "Id");
            return View();
        }

        // POST: HomeTeams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TeamId")] HomeTeam homeTeam)
        {
            if (ModelState.IsValid)
            {
                _context.Add(homeTeam);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TeamId"] = new SelectList(_context.Team, "Id", "Id", homeTeam.TeamId);
            return View(homeTeam);
        }

        // GET: HomeTeams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homeTeam = await _context.HomeTeam.FindAsync(id);
            if (homeTeam == null)
            {
                return NotFound();
            }
            ViewData["TeamId"] = new SelectList(_context.Team, "Id", "Id", homeTeam.TeamId);
            return View(homeTeam);
        }

        // POST: HomeTeams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TeamId")] HomeTeam homeTeam)
        {
            if (id != homeTeam.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(homeTeam);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HomeTeamExists(homeTeam.Id))
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
            ViewData["TeamId"] = new SelectList(_context.Team, "Id", "Id", homeTeam.TeamId);
            return View(homeTeam);
        }

        // GET: HomeTeams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homeTeam = await _context.HomeTeam
                .Include(h => h.Team)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (homeTeam == null)
            {
                return NotFound();
            }

            return View(homeTeam);
        }

        // POST: HomeTeams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var homeTeam = await _context.HomeTeam.FindAsync(id);
            _context.HomeTeam.Remove(homeTeam);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HomeTeamExists(int id)
        {
            return _context.HomeTeam.Any(e => e.Id == id);
        }
    }
}
