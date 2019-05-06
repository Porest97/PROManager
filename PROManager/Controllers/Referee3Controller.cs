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
    public class Referee3Controller : Controller
    {
        private readonly PROManagerContext _context;

        public Referee3Controller(PROManagerContext context)
        {
            _context = context;
        }

        // GET: Referee3
        public async Task<IActionResult> Index()
        {
            var pROManagerContext = _context.Referee3.Include(r => r.Person);
            return View(await pROManagerContext.ToListAsync());
        }

        // GET: Referee3/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var referee3 = await _context.Referee3
                .Include(r => r.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (referee3 == null)
            {
                return NotFound();
            }

            return View(referee3);
        }

        // GET: Referee3/Create
        public IActionResult Create()
        {
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id");
            return View();
        }

        // POST: Referee3/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PersonId")] Referee3 referee3)
        {
            if (ModelState.IsValid)
            {
                _context.Add(referee3);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id", referee3.PersonId);
            return View(referee3);
        }

        // GET: Referee3/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var referee3 = await _context.Referee3.FindAsync(id);
            if (referee3 == null)
            {
                return NotFound();
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id", referee3.PersonId);
            return View(referee3);
        }

        // POST: Referee3/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PersonId")] Referee3 referee3)
        {
            if (id != referee3.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(referee3);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Referee3Exists(referee3.Id))
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
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id", referee3.PersonId);
            return View(referee3);
        }

        // GET: Referee3/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var referee3 = await _context.Referee3
                .Include(r => r.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (referee3 == null)
            {
                return NotFound();
            }

            return View(referee3);
        }

        // POST: Referee3/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var referee3 = await _context.Referee3.FindAsync(id);
            _context.Referee3.Remove(referee3);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Referee3Exists(int id)
        {
            return _context.Referee3.Any(e => e.Id == id);
        }
    }
}
