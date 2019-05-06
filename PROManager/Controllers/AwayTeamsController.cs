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
    public class AwayTeamsController : Controller
    {
        private readonly PROManagerContext _context;

        public AwayTeamsController(PROManagerContext context)
        {
            _context = context;
        }

        // GET: AwayTeams
        public async Task<IActionResult> Index()
        {
            var pROManagerContext = _context.AwayTeam.Include(a => a.Team);
            return View(await pROManagerContext.ToListAsync());
        }

        // GET: AwayTeams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var awayTeam = await _context.AwayTeam
                .Include(a => a.Team)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (awayTeam == null)
            {
                return NotFound();
            }

            return View(awayTeam);
        }

        // GET: AwayTeams/Create
        public IActionResult Create()
        {
            ViewData["TeamId"] = new SelectList(_context.Team, "Id", "TeamName");
            return View();
        }

        // POST: AwayTeams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TeamId")] AwayTeam awayTeam)
        {
            if (ModelState.IsValid)
            {
                _context.Add(awayTeam);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TeamId"] = new SelectList(_context.Team, "Id", "TeamName", awayTeam.TeamId);
            return View(awayTeam);
        }

        // GET: AwayTeams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var awayTeam = await _context.AwayTeam.FindAsync(id);
            if (awayTeam == null)
            {
                return NotFound();
            }
            ViewData["TeamId"] = new SelectList(_context.Team, "Id", "TeamName", awayTeam.TeamId);
            return View(awayTeam);
        }

        // POST: AwayTeams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TeamId")] AwayTeam awayTeam)
        {
            if (id != awayTeam.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(awayTeam);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AwayTeamExists(awayTeam.Id))
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
            ViewData["TeamId"] = new SelectList(_context.Team, "Id", "TeamName", awayTeam.TeamId);
            return View(awayTeam);
        }

        // GET: AwayTeams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var awayTeam = await _context.AwayTeam
                .Include(a => a.Team)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (awayTeam == null)
            {
                return NotFound();
            }

            return View(awayTeam);
        }

        // POST: AwayTeams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var awayTeam = await _context.AwayTeam.FindAsync(id);
            _context.AwayTeam.Remove(awayTeam);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AwayTeamExists(int id)
        {
            return _context.AwayTeam.Any(e => e.Id == id);
        }
    }
}
