using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjektZespolowy.Models.MyModels;
using WebApplication6.Data;
using WebApplication6.Models;
using ProjektZespolowy.Models.RezerwcjaViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;


namespace ProjektZespolowy.Controllers
{
    public class RezerwacjaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RezerwacjaController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Rezerwacja
        [Authorize(Roles = "Administrator, Pracownik, Uzytkownik, UzytkownikNiezweryfikowany,Indywidualne, Firma, Wlasciciel, Monitoring")]
        public ActionResult Index()
        {

            var wszystkieRezerwacje = _context.Rezerwacje.ToList();
            List<RezerwacjaIndex> rezerwacje = new List<RezerwacjaIndex>();
            if (User.Identity.IsAuthenticated)
            {
                wszystkieRezerwacje.Clear();
                wszystkieRezerwacje = _context.Rezerwacje.
                   Where(x => x.KlientId == _context.ApplicationUser.
                   Where(y => y.UserName == User.Identity.Name).
                   Select(y => y.Id).First()).
                   ToList();
            }
            else
                return RedirectToAction("Index", "Home");
            if (User.IsInRole("Administrator"))
            {
                 wszystkieRezerwacje = _context.Rezerwacje.ToList();
            }
            if (User.Identity.Name == null)
                wszystkieRezerwacje.Clear();
            
            
            foreach (var item in wszystkieRezerwacje)
            {
                rezerwacje.Add(new RezerwacjaIndex
                {
                    data = item.Date,
                    UserName = _context.ApplicationUser.Where(x => x.Id == item.KlientId).Select(y => y.UserName).FirstOrDefault(),
                    Usluga = item.usluga,
                    RezerwacjaId = item.RezerwacjaId
                });
            }
            return View(rezerwacje);
        }

        // GET: Rezerwacja/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Rezerwacja/Create
        public ActionResult Create()
        {
            var myjnie = _context.Uslugi.Where(u=>u.TypUslugi== "mycie standardowe"||u.TypUslugi== "mycie woskowanie").ToList();
            ViewBag.myjnie = new SelectList(myjnie, "TypUslugi","TypUslugi");
            return View();
        }

        // POST: Rezerwacja/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection, Rezerwacja rezerwacja,string myjnie)
        {
            try
            {
                var testy = _context.Rezerwacje.ToList();
                foreach (var item in testy)
                {
                    if (item.Date == rezerwacja.Date)
                    {
                        ViewBag.blad = "Data zarezerwowana";
                        var x = _context.Uslugi.ToList();
                        ViewBag.myjnie = new SelectList(x, "TypUslugi", "TypUslugi");
                        return View();
                    }
                    
                }
                var usluga = _context.Uslugi.Where(x => x.TypUslugi == myjnie).FirstOrDefault();
                var nowy = _context.ApplicationUser.Where(x=>x.UserName == User.Identity.Name).FirstOrDefault();
                Rezerwacja nowa = new Rezerwacja { Date = rezerwacja.Date, usluga = myjnie, KlientId = nowy.Id };
                _context.Rezerwacje.Add(nowa);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Rezerwacja/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Rezerwacja/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Rezerwacja/Delete/5
        public ActionResult Delete(int id)
        {
            Rezerwacja rezerwacja = _context.Rezerwacje.Where(x => x.RezerwacjaId == id).FirstOrDefault();
            _context.Rezerwacje.Remove(rezerwacja);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // POST: Rezerwacja/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete( IFormCollection collection)
        {
            try
            {
               

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}