using System;
using System.Collections;
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
        private Rachunek rachunek;

        public RachunekController(ApplicationDbContext context)
        {
            _context = context;
            if (Temp.rachunek == null)
            {
                rachunek = new Rachunek { Data = DateTime.Now };
                Temp.rachunek = rachunek;
            }
            else
                rachunek = Temp.rachunek;

            


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
            ViewBag.uslugiNaRachunku = rachunek.Uslugi;
            ViewBag.wykonaneUslugi = _context.WykonaneUslugi.Where(u => u.Zaksiegowano == false).Include(u => u.Usluga).ToList();
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
                //ViewBag.wykonaneUslugi = _context.WykonaneUslugi.Where(u => u.Zaksiegowano == false).ToList();
                return RedirectToAction(nameof(Podsumowanie));
                
            }
            return View(rachunek);
        }

        public async Task<IActionResult> Podsumowanie()
        {
            ViewBag.rachunek = rachunek;
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

        //[ActionName("DodajUslugeAsync")]
        public async Task<IActionResult> DodajUslugeAsync(int id)
        {
            WykonanaUsluga usluga = _context.WykonaneUslugi.Where(u=>u.WykonanaUslugaId==id).Include(u=>u.Usluga).Single();
            this.rachunek.dodajUsluge(usluga);
           //ViewBag.wykonaneUslugi =await _context.WykonaneUslugi.Where(u => u.Zaksiegowano == false&& u.WykonanaUslugaId!=id).Include(u => u.Usluga).ToListAsync();
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Create));
            
        }

        public async Task<IActionResult> UsunUslugeAsync(int id)
        {
            WykonanaUsluga usluga = _context.WykonaneUslugi.Where(u => u.WykonanaUslugaId == id).Include(u => u.Usluga).Single();
            this.rachunek.usunUsluge(usluga);
            //ViewBag.wykonaneUslugi =await _context.WykonaneUslugi.Where(u => u.Zaksiegowano == false || u.WykonanaUslugaId == id).Include(u => u.Usluga).ToListAsync();
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Create));

        }

        private async Task<IActionResult> CreateAsync()
        {
            //
            return Create();
        }

        public async Task<IActionResult> SzukajKlient()
        {
            string mail = Convert.ToString(Request.Form["userMail"]);
            try
            {
                rachunek.Klient = _context.Users.Where(u => u.Email == mail).Single();
            }
            catch(Exception ex)
            {
                rachunek.Klient = null;
            }
            return RedirectToAction(nameof(Podsumowanie));
            
        }

        public async Task<IActionResult> DodajZaPunkt(int id)
        {
            rachunek.Uslugi.Find(u => u.WykonanaUslugaId == id).wykorzystajPunkty(1);
            return RedirectToAction(nameof(Podsumowanie));

        }

        public async Task<IActionResult> UsunZaPunkt(int id)
        {
            rachunek.Uslugi.Find(u => u.WykonanaUslugaId == id).wykorzystajPunkty(-1);
            return RedirectToAction(nameof(Podsumowanie));

        }

        public async Task<IActionResult> Wystaw()
        {
            rachunek.zatwierdzRachunek(false);
            _context.UpdateRange(rachunek, rachunek.Klient);
            _context.SaveChanges();
            Temp.rachunek = null;
            ViewBag.rachunek = rachunek;
            return Paragon();
        }

        private IActionResult Paragon()
        {
            return View();
        }

        private bool RachunekExists(int id)
        {
            return _context.Rachunki.Any(e => e.RachunekId == id);
            
        }
    }
}
