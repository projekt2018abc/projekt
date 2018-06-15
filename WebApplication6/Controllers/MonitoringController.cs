using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication6.Models;
using ProjektZespolowy.Models.MyModels;
using WebApplication6.Data;

namespace ProjektZespolowy.Controllers
{
    public class MonitoringController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Monitoring
        public ActionResult Index()
        {
            Random r = new Random();
            List<Monitoring> monity = new List<Monitoring>
            {
                new Monitoring { Id = 1, Paliwo = "Pb 95", Cisnienie = r.Next(100,200)+r.NextDouble(), PoziomPaliwa = r.Next(0, 100) + r.NextDouble(), Data = DateTime.Now, Temperatura = r.Next(-10, 50) + r.NextDouble() },
                new Monitoring { Id = 2, Paliwo = "Pb 98", Cisnienie = r.Next(100, 200) + r.NextDouble(), PoziomPaliwa = r.Next(0, 100) + r.NextDouble(), Data = DateTime.Now, Temperatura = r.Next(-10, 50) + r.NextDouble() },
                new Monitoring { Id = 3, Paliwo = "ON", Cisnienie = r.Next(100, 200) + r.NextDouble(), PoziomPaliwa = r.Next(0, 100) + r.NextDouble(), Data = DateTime.Now, Temperatura = r.Next(-10, 50) + r.NextDouble() },
                new Monitoring { Id = 4, Paliwo = "LPG", Cisnienie = r.Next(100, 200) + r.NextDouble(), PoziomPaliwa = r.Next(0, 100) + r.NextDouble(), Data = DateTime.Now, Temperatura = r.Next(-10, 50) + r.NextDouble() }
            };
            List<Powiadomienie> powiadomienia = new List<Powiadomienie>();
            foreach (var item in monity)
            {
                
                if (item.Cisnienie > 190)
                {
                    Powiadomienie p = new Powiadomienie {monitoring = item,Nazwa = "za wysokie ciśnienie w zbiorniku " + item.Paliwo };
                    powiadomienia.Add(p);
                }
                else if(item.Cisnienie<10)
                {
                    Powiadomienie p = new Powiadomienie { monitoring = item, Nazwa = "za niskie ciśnienie w zbiorniku " + item.Paliwo };
                    powiadomienia.Add(p);
                }

                if (item.PoziomPaliwa> 90)
                {
                    Powiadomienie p = new Powiadomienie { monitoring = item, Nazwa = "za wysoki poziom paliwa w zbiorniku " + item.Paliwo };
                    powiadomienia.Add(p);
                }
                else if (item.PoziomPaliwa < 10)
                {
                    Powiadomienie p = new Powiadomienie { monitoring = item, Nazwa = "za niski poziom paliwa w zbiorniku " + item.Paliwo };
                    powiadomienia.Add(p);
                }
                if (item.Temperatura > 40)
                {
                    Powiadomienie p = new Powiadomienie { monitoring = item, Nazwa = "za wysoka temperatura " + item.Paliwo };
                    powiadomienia.Add(p);
                }
                else if (item.Temperatura < -5)
                {
                    Powiadomienie p = new Powiadomienie { monitoring = item, Nazwa = "za niska temperatura" + item.Paliwo };
                    powiadomienia.Add(p);
                }

            }
            ViewBag.powiadomienia = powiadomienia.Select(x=>x.Nazwa);
            return View(monity);
        }

       
    }
}