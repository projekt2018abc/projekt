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
    public class WykonanaUslugaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private WykonanaUsluga usluga;

        public WykonanaUslugaController(ApplicationDbContext context)
        {
            _context = context;
            usluga = new WykonanaUsluga();
        }

        // GET: WykonanaUsluga
        public async Task<IActionResult> Index()
        {
            return View(await _context.WykonaneUslugi.ToListAsync());
        }

        // GET: WykonanaUsluga/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wykonanaUsluga = await _context.WykonaneUslugi
                .SingleOrDefaultAsync(m => m.WykonanaUslugaId == id);
            if (wykonanaUsluga == null)
            {
                return NotFound();
            }

            return View(wykonanaUsluga);
        }

        // GET: WykonanaUsluga/Create
        public IActionResult Create()
        {
            ViewBag.Uslugi = _context.Uslugi.ToList();
            return View();
        }

        // POST: WykonanaUsluga/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WykonanaUslugaId,Ilosc,IloscZaPunkty,Data,Koszt,WykorzystanePunkty,DodanePunkty,Zaksiegowano,Usluga")] WykonanaUsluga wykonanaUsluga)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wykonanaUsluga);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(wykonanaUsluga);
        }

        // GET: WykonanaUsluga/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wykonanaUsluga = await _context.WykonaneUslugi.SingleOrDefaultAsync(m => m.WykonanaUslugaId == id);
            if (wykonanaUsluga == null)
            {
                return NotFound();
            }
            return View(wykonanaUsluga);
        }

        // POST: WykonanaUsluga/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WykonanaUslugaId,Ilosc,IloscZaPunkty,Data,Koszt,WykorzystanePunkty,DodanePunkty,Zaksiegowano")] WykonanaUsluga wykonanaUsluga)
        {
            if (id != wykonanaUsluga.WykonanaUslugaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wykonanaUsluga);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WykonanaUslugaExists(wykonanaUsluga.WykonanaUslugaId))
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
            return View(wykonanaUsluga);
        }

        // GET: WykonanaUsluga/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wykonanaUsluga = await _context.WykonaneUslugi
                .SingleOrDefaultAsync(m => m.WykonanaUslugaId == id);
            if (wykonanaUsluga == null)
            {
                return NotFound();
            }

            return View(wykonanaUsluga);
        }

        // POST: WykonanaUsluga/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wykonanaUsluga = await _context.WykonaneUslugi.SingleOrDefaultAsync(m => m.WykonanaUslugaId == id);
            _context.WykonaneUslugi.Remove(wykonanaUsluga);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WykonanaUslugaExists(int id)
        {
            return _context.WykonaneUslugi.Any(e => e.WykonanaUslugaId == id);
        }

        //public ActionResult DodajUsluge(int id)
        //{
        //    //WykonanaUsluga = _context.Uslugi.Where(u => u.UslugaId == id).Single();
        //    return RedirectToAction("DodajUsluge");
        //}
    }
}
