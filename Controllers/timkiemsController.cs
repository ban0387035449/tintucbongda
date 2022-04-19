using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using tintucbongda.Data;
using tintucbongda.Models;

namespace tintucbongda.Controllers
{
    public class timkiemsController : Controller
    {
        private readonly tintucbongdaContext _context;

        public timkiemsController(tintucbongdaContext context)
        {
            _context = context;
        }

        // GET: timkiems
        public async Task<IActionResult> Index(string TimkiemGenre, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from b in _context.timkiem
                                            orderby b.Genre
                                            select b.Genre;
            var Timkiems = from b in _context.timkiem
                           select b;
            if (!string.IsNullOrEmpty(searchString))
            {
                Timkiems = Timkiems.Where(s => s.Title!.Contains(searchString));
            }
            if (!string.IsNullOrEmpty(TimkiemGenre))
            {
                Timkiems = Timkiems.Where(x => x.Genre == TimkiemGenre);
            }
            var TimkiemGenreVM = new timkiemGenreViewModel
            {
                Genres = new SelectList(await
            genreQuery.Distinct().ToListAsync()),
                timkiems = await Timkiems.ToListAsync()
            };
            return View(TimkiemGenreVM);
        }

        // GET: timkiems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timkiem = await _context.timkiem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (timkiem == null)
            {
                return NotFound();
            }

            return View(timkiem);
        }

        // GET: timkiems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: timkiems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price")] timkiem timkiem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(timkiem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(timkiem);
        }

        // GET: timkiems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timkiem = await _context.timkiem.FindAsync(id);
            if (timkiem == null)
            {
                return NotFound();
            }
            return View(timkiem);
        }

        // POST: timkiems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price")] timkiem timkiem)
        {
            if (id != timkiem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timkiem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!timkiemExists(timkiem.Id))
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
            return View(timkiem);
        }

        // GET: timkiems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timkiem = await _context.timkiem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (timkiem == null)
            {
                return NotFound();
            }

            return View(timkiem);
        }

        // POST: timkiems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var timkiem = await _context.timkiem.FindAsync(id);
            _context.timkiem.Remove(timkiem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool timkiemExists(int id)
        {
            return _context.timkiem.Any(e => e.Id == id);
        }
    }
}
