using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DummyDetailsController : Controller
    {
        private readonly DummyContext _context;

        public DummyDetailsController(DummyContext context)
        {
            _context = context;
        }

        // GET: DummyDetails
        public async Task<IActionResult> Index()
        {
            var dummyContext = _context.DummyDetails.Include(d => d.Master);
            return View(await dummyContext.ToListAsync());
        }

        // GET: DummyDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DummyDetails == null)
            {
                return NotFound();
            }

            var dummyDetail = await _context.DummyDetails
                .Include(d => d.Master)
                .FirstOrDefaultAsync(m => m.DetailId == id);
            if (dummyDetail == null)
            {
                return NotFound();
            }

            return View(dummyDetail);
        }

        // GET: DummyDetails/Create
        public IActionResult Create()
        {
            ViewData["MasterId"] = new SelectList(_context.DummyMasters, "MasterId", "MasterId");
            return View();
        }

        // POST: DummyDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DetailId,DetailName,MasterId")] DummyDetail dummyDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dummyDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MasterId"] = new SelectList(_context.DummyMasters, "MasterId", "MasterId", dummyDetail.MasterId);
            return View(dummyDetail);
        }

        // GET: DummyDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DummyDetails == null)
            {
                return NotFound();
            }

            var dummyDetail = await _context.DummyDetails.FindAsync(id);
            if (dummyDetail == null)
            {
                return NotFound();
            }
            ViewData["MasterId"] = new SelectList(_context.DummyMasters, "MasterId", "MasterId", dummyDetail.MasterId);
            return View(dummyDetail);
        }

        // POST: DummyDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DetailId,DetailName,MasterId")] DummyDetail dummyDetail)
        {
            if (id != dummyDetail.DetailId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dummyDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DummyDetailExists(dummyDetail.DetailId))
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
            ViewData["MasterId"] = new SelectList(_context.DummyMasters, "MasterId", "MasterId", dummyDetail.MasterId);
            return View(dummyDetail);
        }

        // GET: DummyDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DummyDetails == null)
            {
                return NotFound();
            }

            var dummyDetail = await _context.DummyDetails
                .Include(d => d.Master)
                .FirstOrDefaultAsync(m => m.DetailId == id);
            if (dummyDetail == null)
            {
                return NotFound();
            }

            return View(dummyDetail);
        }

        // POST: DummyDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DummyDetails == null)
            {
                return Problem("Entity set 'DummyContext.DummyDetails'  is null.");
            }
            var dummyDetail = await _context.DummyDetails.FindAsync(id);
            if (dummyDetail != null)
            {
                _context.DummyDetails.Remove(dummyDetail);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DummyDetailExists(int id)
        {
          return (_context.DummyDetails?.Any(e => e.DetailId == id)).GetValueOrDefault();
        }
    }
}
