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
    public class AFAktivitiesController : Controller
    {
        private readonly PROManagerContext _context;

        public AFAktivitiesController(PROManagerContext context)
        {
            _context = context;
        }

        // GET: AFAktivities
        public async Task<IActionResult> Index()
        {
            var pROManagerContext = _context.AFAktivity.Include(a => a.FAktivityType).Include(a => a.Person);
            return View(await pROManagerContext.ToListAsync());
        }

        // GET: AFAktivities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aFAktivity = await _context.AFAktivity
                .Include(a => a.FAktivityType)
                .Include(a => a.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aFAktivity == null)
            {
                return NotFound();
            }

            return View(aFAktivity);
        }

        // GET: AFAktivities/Create
        public IActionResult Create()
        {
            ViewData["AFAktivityTypeId"] = new SelectList(_context.Set<AFAktivityType>(), "Id", "AFAktivityTypeName");
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName");
            return View();
        }

        // POST: AFAktivities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StartDateTime,EndDateTime,AFAktivityTypeId,PersonId,Description")] AFAktivity aFAktivity)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aFAktivity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AFAktivityTypeId"] = new SelectList(_context.Set<AFAktivityType>(), "Id", "AFAktivityTypeName", aFAktivity.AFAktivityTypeId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", aFAktivity.PersonId);
            return View(aFAktivity);
        }

        // GET: AFAktivities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aFAktivity = await _context.AFAktivity.FindAsync(id);
            if (aFAktivity == null)
            {
                return NotFound();
            }
            ViewData["AFAktivityTypeId"] = new SelectList(_context.Set<AFAktivityType>(), "Id", "AFAktivityTypeName", aFAktivity.AFAktivityTypeId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", aFAktivity.PersonId);
            return View(aFAktivity);
        }

        // POST: AFAktivities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StartDateTime,EndDateTime,AFAktivityTypeId,PersonId,Description")] AFAktivity aFAktivity)
        {
            if (id != aFAktivity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aFAktivity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AFAktivityExists(aFAktivity.Id))
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
            ViewData["AFAktivityTypeId"] = new SelectList(_context.Set<AFAktivityType>(), "Id", "AFAktivityTypeName", aFAktivity.AFAktivityTypeId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", aFAktivity.PersonId);
            return View(aFAktivity);
        }

        // GET: AFAktivities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aFAktivity = await _context.AFAktivity
                .Include(a => a.FAktivityType)
                .Include(a => a.Person)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aFAktivity == null)
            {
                return NotFound();
            }

            return View(aFAktivity);
        }

        // POST: AFAktivities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aFAktivity = await _context.AFAktivity.FindAsync(id);
            _context.AFAktivity.Remove(aFAktivity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AFAktivityExists(int id)
        {
            return _context.AFAktivity.Any(e => e.Id == id);
        }
    }
}
