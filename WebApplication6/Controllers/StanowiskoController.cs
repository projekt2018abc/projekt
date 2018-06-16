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
    public class StanowiskoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StanowiskoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Stanowisko
        public async Task<IActionResult> Index()
        {
            return View(await _context.Stanowisko.ToListAsync());
        }

        // GET: Stanowisko/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stanowisko = await _context.Stanowisko
                .SingleOrDefaultAsync(m => m.StanowiskoId == id);
            if (stanowisko == null)
            {
                return NotFound();
            }

            return View(stanowisko);
        }

        // GET: Stanowisko/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stanowisko/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StanowiskoId,Typ")] Stanowisko stanowisko)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stanowisko);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stanowisko);
        }

        // GET: Stanowisko/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stanowisko = await _context.Stanowisko.SingleOrDefaultAsync(m => m.StanowiskoId == id);
            if (stanowisko == null)
            {
                return NotFound();
            }
            return View(stanowisko);
        }

        // POST: Stanowisko/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StanowiskoId,Typ")] Stanowisko stanowisko)
        {
            if (id != stanowisko.StanowiskoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stanowisko);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StanowiskoExists(stanowisko.StanowiskoId))
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
            return View(stanowisko);
        }

        // GET: Stanowisko/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stanowisko = await _context.Stanowisko
                .SingleOrDefaultAsync(m => m.StanowiskoId == id);
            if (stanowisko == null)
            {
                return NotFound();
            }

            return View(stanowisko);
        }

        // POST: Stanowisko/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stanowisko = await _context.Stanowisko.SingleOrDefaultAsync(m => m.StanowiskoId == id);
            _context.Stanowisko.Remove(stanowisko);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StanowiskoExists(int id)
        {
            return _context.Stanowisko.Any(e => e.StanowiskoId == id);
        }
    }
}
