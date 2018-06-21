using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjektZespolowy.Models.MyModels;
using WebApplication6.Data;

namespace ProjektZespolowy.Controllers
{
    public class RezerwacjaController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Rezerwacja
        public ActionResult Index()
        {
            List < Rezerwacja > rezerwacje = db.Rezerwacje.ToList();
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
            return View();
        }

        // POST: Rezerwacja/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

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
            return View();
        }

        // POST: Rezerwacja/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}