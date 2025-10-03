using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using INETAssignment1.Data;
using INETAssignment1.Models;

namespace INETAssignment1.Controllers
{
    public class BandsController : Controller
    {
        private readonly INETAssignment1Context _context;

        public BandsController(INETAssignment1Context context)
        {
            _context = context;
        }

        // GET: Bands
        public async Task<IActionResult> Index()
        {
            var iNETAssignment1Context = _context.Band.Include(b => b.genre);
            return View(await iNETAssignment1Context.ToListAsync());
        }

        // GET: Bands/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var band = await _context.Band
                .Include(b => b.genre)
                .FirstOrDefaultAsync(m => m.bandID == id);
            if (band == null)
            {
                return NotFound();
            }

            return View(band);
        }

        // GET: Bands/Create
        public IActionResult Create()
        {
            ViewData["genreID"] = new SelectList(_context.Genre, "genreID", "genreName");
            return View();
        }

        // POST: Bands/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("bandID,bandName,bandDescription,genreID")] Band band)
        {
            if (ModelState.IsValid)
            {
                _context.Add(band);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["genreID"] = new SelectList(_context.Genre, "genreID", "genreName", band.genreID);
            return View(band);
        }

        // GET: Bands/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var band = await _context.Band.FindAsync(id);
            if (band == null)
            {
                return NotFound();
            }
            ViewData["genreID"] = new SelectList(_context.Genre, "genreID", "genreName", band.genreID);
            return View(band);
        }

        // POST: Bands/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("bandID,bandName,bandDescription,genreID")] Band band)
        {
            if (id != band.bandID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(band);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BandExists(band.bandID))
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
            ViewData["genreID"] = new SelectList(_context.Genre, "genreID", "genreName", band.genreID);
            return View(band);
        }

        // GET: Bands/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var band = await _context.Band
                .Include(b => b.genre)
                .FirstOrDefaultAsync(m => m.bandID == id);
            if (band == null)
            {
                return NotFound();
            }

            return View(band);
        }

        // POST: Bands/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var band = await _context.Band.FindAsync(id);
            if (band != null)
            {
                _context.Band.Remove(band);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BandExists(int id)
        {
            return _context.Band.Any(e => e.bandID == id);
        }
    }
}
