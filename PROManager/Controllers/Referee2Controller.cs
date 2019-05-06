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
    public class Referee2Controller : Controller
    {
        private readonly PROManagerContext _context;

        public Referee2Controller(PROManagerContext context)
        {
            _context = context;
        }

        // GET: Referee2
        public async Task<IActionResult> Index()
        {
            var pROManagerContext = _context.Referee2.Include(r => r.Person);
            return View(await pROManagerContext.ToListAsync());
        }

        // GET: Referee2/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var referee2 = await _context.Referee2
                .Include(r => r.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (referee2 == null)
            {
                return NotFound();
            }

            return View(referee2);
        }

        // GET: Referee2/Create
        public IActionResult Create()
        {
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id");
            return View();
        }

        // POST: Referee2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PersonId")] Referee2 referee2)
        {
            if (ModelState.IsValid)
            {
                _context.Add(referee2);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id", referee2.PersonId);
            return View(referee2);
        }

        // GET: Referee2/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var referee2 = await _context.Referee2.FindAsync(id);
            if (referee2 == null)
            {
                return NotFound();
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id", referee2.PersonId);
            return View(referee2);
        }

        // POST: Referee2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PersonId")] Referee2 referee2)
        {
            if (id != referee2.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(referee2);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Referee2Exists(referee2.Id))
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
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id", referee2.PersonId);
            return View(referee2);
        }

        // GET: Referee2/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var referee2 = await _context.Referee2
                .Include(r => r.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (referee2 == null)
            {
                return NotFound();
            }

            return View(referee2);
        }

        // POST: Referee2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var referee2 = await _context.Referee2.FindAsync(id);
            _context.Referee2.Remove(referee2);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Referee2Exists(int id)
        {
            return _context.Referee2.Any(e => e.Id == id);
        }
    }
}
