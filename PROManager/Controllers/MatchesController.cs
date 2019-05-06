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
    public class MatchesController : Controller
    {
        private readonly PROManagerContext _context;

        public MatchesController(PROManagerContext context)
        {
            _context = context;
        }

        // GET: Matches
        public async Task<IActionResult> Index()
        {
            var pROManagerContext = _context.Match.Include(m => m.Arena).Include(m => m.AwayTeam).Include(m => m.HomeTeam).Include(m => m.Referee).Include(m => m.Referee1).Include(m => m.Referee2).Include(m => m.Referee3).Include(m => m.Series);
            return View(await pROManagerContext.ToListAsync());
        }

        // GET: Matches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = await _context.Match
                .Include(m => m.Arena)
                .Include(m => m.AwayTeam)
                .Include(m => m.HomeTeam)
                .Include(m => m.Referee)
                .Include(m => m.Referee1)
                .Include(m => m.Referee2)
                .Include(m => m.Referee3)
                .Include(m => m.Series)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (match == null)
            {
                return NotFound();
            }

            return View(match);
        }

        // GET: Matches/Create
        public IActionResult Create()
        {
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName");
            ViewData["AwayTeamId"] = new SelectList(_context.AwayTeam, "Id", "Id");
            ViewData["HomeTeamId"] = new SelectList(_context.HomeTeam, "Id", "Id");
            ViewData["RefereeId"] = new SelectList(_context.Referee, "Id", "Id");
            ViewData["Referee1Id"] = new SelectList(_context.Referee1, "Id", "Id");
            ViewData["Referee2Id"] = new SelectList(_context.Referee1, "Id", "Id");
            ViewData["Referee3Id"] = new SelectList(_context.Referee1, "Id", "Id");
            ViewData["SeriesId"] = new SelectList(_context.Series, "Id", "SeriesName");
            return View();
        }

        // POST: Matches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MatchDateTime,ArenaId,HomeTeamId,AwayTeamId,ScoreHomeTeam,ScoreAwayTeam,RefereeId,Referee1Id,Referee2Id,Referee3Id,SeriesId")] Match match)
        {
            if (ModelState.IsValid)
            {
                _context.Add(match);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName", match.ArenaId);
            ViewData["AwayTeamId"] = new SelectList(_context.AwayTeam, "Id", "Id", match.AwayTeamId);
            ViewData["HomeTeamId"] = new SelectList(_context.HomeTeam, "Id", "Id", match.HomeTeamId);
            ViewData["RefereeId"] = new SelectList(_context.Referee, "Id", "Id", match.RefereeId);
            ViewData["Referee1Id"] = new SelectList(_context.Referee1, "Id", "Id", match.Referee1Id);
            ViewData["Referee2Id"] = new SelectList(_context.Referee1, "Id", "Id", match.Referee2Id);
            ViewData["Referee3Id"] = new SelectList(_context.Referee1, "Id", "Id", match.Referee3Id);
            ViewData["SeriesId"] = new SelectList(_context.Series, "Id", "SeriesName", match.SeriesId);
            return View(match);
        }

        // GET: Matches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = await _context.Match.FindAsync(id);
            if (match == null)
            {
                return NotFound();
            }
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName", match.ArenaId);
            ViewData["AwayTeamId"] = new SelectList(_context.AwayTeam, "Id", "Id", match.AwayTeamId);
            ViewData["HomeTeamId"] = new SelectList(_context.HomeTeam, "Id", "Id", match.HomeTeamId);
            ViewData["RefereeId"] = new SelectList(_context.Referee, "Id", "Id", match.RefereeId);
            ViewData["Referee1Id"] = new SelectList(_context.Referee1, "Id", "Id", match.Referee1Id);
            ViewData["Referee2Id"] = new SelectList(_context.Referee1, "Id", "Id", match.Referee2Id);
            ViewData["Referee3Id"] = new SelectList(_context.Referee1, "Id", "Id", match.Referee3Id);
            ViewData["SeriesId"] = new SelectList(_context.Series, "Id", "SeriesName", match.SeriesId);
            return View(match);
        }

        // POST: Matches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MatchDateTime,ArenaId,HomeTeamId,AwayTeamId,ScoreHomeTeam,ScoreAwayTeam,RefereeId,Referee1Id,Referee2Id,Referee3Id,SeriesId")] Match match)
        {
            if (id != match.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(match);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatchExists(match.Id))
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
            ViewData["ArenaId"] = new SelectList(_context.Arena, "Id", "ArenaName", match.ArenaId);
            ViewData["AwayTeamId"] = new SelectList(_context.AwayTeam, "Id", "Id", match.AwayTeamId);
            ViewData["HomeTeamId"] = new SelectList(_context.HomeTeam, "Id", "Id", match.HomeTeamId);
            ViewData["RefereeId"] = new SelectList(_context.Referee, "Id", "Id", match.RefereeId);
            ViewData["Referee1Id"] = new SelectList(_context.Referee1, "Id", "Id", match.Referee1Id);
            ViewData["Referee2Id"] = new SelectList(_context.Referee1, "Id", "Id", match.Referee2Id);
            ViewData["Referee3Id"] = new SelectList(_context.Referee1, "Id", "Id", match.Referee3Id);
            ViewData["SeriesId"] = new SelectList(_context.Series, "Id", "SeriesName", match.SeriesId);
            return View(match);
        }

        // GET: Matches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var match = await _context.Match
                .Include(m => m.Arena)
                .Include(m => m.AwayTeam)
                .Include(m => m.HomeTeam)
                .Include(m => m.Referee)
                .Include(m => m.Referee1)
                .Include(m => m.Referee2)
                .Include(m => m.Referee3)
                .Include(m => m.Series)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (match == null)
            {
                return NotFound();
            }

            return View(match);
        }

        // POST: Matches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var match = await _context.Match.FindAsync(id);
            _context.Match.Remove(match);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatchExists(int id)
        {
            return _context.Match.Any(e => e.Id == id);
        }
    }
}
