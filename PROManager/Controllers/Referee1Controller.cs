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
    public class Referee1Controller : Controller
    {
        private readonly PROManagerContext _context;

        public Referee1Controller(PROManagerContext context)
        {
            _context = context;
        }

        // GET: Referee1
        public async Task<IActionResult> Index()
        {
            var pROManagerContext = _context.Referee1.Include(r => r.Person);
            return View(await pROManagerContext.ToListAsync());
        }

        // GET: Referee1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var referee1 = await _context.Referee1
                .Include(r => r.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (referee1 == null)
            {
                return NotFound();
            }

            return View(referee1);
        }

        // GET: Referee1/Create
        public IActionResult Create()
        {
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id");
            return View();
        }

        // POST: Referee1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PersonId")] Referee1 referee1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(referee1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id", referee1.PersonId);
            return View(referee1);
        }

        // GET: Referee1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var referee1 = await _context.Referee1.FindAsync(id);
            if (referee1 == null)
            {
                return NotFound();
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id", referee1.PersonId);
            return View(referee1);
        }

        // POST: Referee1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PersonId")] Referee1 referee1)
        {
            if (id != referee1.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(referee1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Referee1Exists(referee1.Id))
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
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id", referee1.PersonId);
            return View(referee1);
        }

        // GET: Referee1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var referee1 = await _context.Referee1
                .Include(r => r.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (referee1 == null)
            {
                return NotFound();
            }

            return View(referee1);
        }

        // POST: Referee1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var referee1 = await _context.Referee1.FindAsync(id);
            _context.Referee1.Remove(referee1);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Referee1Exists(int id)
        {
            return _context.Referee1.Any(e => e.Id == id);
        }
    }
}
