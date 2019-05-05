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
    public class AFAktivityTypesController : Controller
    {
        private readonly PROManagerContext _context;

        public AFAktivityTypesController(PROManagerContext context)
        {
            _context = context;
        }

        // GET: AFAktivityTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.AFAktivityType.ToListAsync());
        }

        // GET: AFAktivityTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aFAktivityType = await _context.AFAktivityType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aFAktivityType == null)
            {
                return NotFound();
            }

            return View(aFAktivityType);
        }

        // GET: AFAktivityTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AFAktivityTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AFAktivityTypeName")] AFAktivityType aFAktivityType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aFAktivityType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aFAktivityType);
        }

        // GET: AFAktivityTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aFAktivityType = await _context.AFAktivityType.FindAsync(id);
            if (aFAktivityType == null)
            {
                return NotFound();
            }
            return View(aFAktivityType);
        }

        // POST: AFAktivityTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AFAktivityTypeName")] AFAktivityType aFAktivityType)
        {
            if (id != aFAktivityType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aFAktivityType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AFAktivityTypeExists(aFAktivityType.Id))
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
            return View(aFAktivityType);
        }

        // GET: AFAktivityTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aFAktivityType = await _context.AFAktivityType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aFAktivityType == null)
            {
                return NotFound();
            }

            return View(aFAktivityType);
        }

        // POST: AFAktivityTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aFAktivityType = await _context.AFAktivityType.FindAsync(id);
            _context.AFAktivityType.Remove(aFAktivityType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AFAktivityTypeExists(int id)
        {
            return _context.AFAktivityType.Any(e => e.Id == id);
        }
    }
}
