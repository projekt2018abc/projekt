using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjektZespolowy.Models.MyModels;
using WebApplication6.Data;

namespace ProjektZespolowy.Controllers
{
    public class RachunekController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RachunekController(ApplicationDbContext context)
        {
            _context = context;
            ViewBag.wykonaneUslugi = _context.WykonaneUslugi.Where(u => u.Zaksiegowano == false).ToList();
        }

        // GET: Rachunek
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rachunki.ToListAsync());
        }

        // GET: Rachunek/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rachunek = await _context.Rachunki
                .SingleOrDefaultAsync(m => m.RachunekId == id);
            if (rachunek == null)
            {
                return NotFound();
            }

            return View(rachunek);
        }

        // GET: Rachunek/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rachunek/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RachunekId,Data,Paragon")] Rachunek rachunek)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rachunek);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rachunek);
        }

        // GET: Rachunek/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rachunek = await _context.Rachunki.SingleOrDefaultAsync(m => m.RachunekId == id);
            if (rachunek == null)
            {
                return NotFound();
            }
            return View(rachunek);
        }

        // POST: Rachunek/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RachunekId,Data,Paragon")] Rachunek rachunek)
        {
            if (id != rachunek.RachunekId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rachunek);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RachunekExists(rachunek.RachunekId))
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
            return View(rachunek);
        }

        // GET: Rachunek/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rachunek = await _context.Rachunki
                .SingleOrDefaultAsync(m => m.RachunekId == id);
            if (rachunek == null)
            {
                return NotFound();
            }

            return View(rachunek);
        }

        // POST: Rachunek/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rachunek = await _context.Rachunki.SingleOrDefaultAsync(m => m.RachunekId == id);
            _context.Rachunki.Remove(rachunek);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RachunekExists(int id)
        {
            return _context.Rachunki.Any(e => e.RachunekId == id);
        }
    }
}
