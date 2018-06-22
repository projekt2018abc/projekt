using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ProjektZespolowy.Models;
using ProjektZespolowy.Models.AccountViewModels;
using ProjektZespolowy.Models.MyModels;

namespace WebApplication6.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Weryfikacja")]
        public bool UserConfirmed { get; set; }

        [Display(Name = "Pracownik")]
        public bool IsEmployee { get; set; }

        [Display(Name = "Imie")]
        public string FirstName { get; set; }

        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }

        [Display(Name = "Nazwa firmy")]
        public string CompanyName { get; set; }

        public string Pesel { get; set; }

        public string Nip { get; set; }

        public string Regon { get; set; }

        [Display(Name = "Punkty")]
        public int Points { get; set; }

        [Display(Name = "Osoba fizyczna")]
        public bool IsNaturalPerson { get; set; }

        [Display(Name = "Numer telefonu")]
        override public string PhoneNumber { get; set; }


        //public List<Rachunek> Historia { get; set; }

        /** --------------------------------------- **/
        public int PodmiotId { get; set; }

        //public void createPodmiotFromApplicationUser(TypKontaEnum typKonta)
        //{
        //    switch (typKonta)
        //    {
        //        case TypKontaEnum.Indywidualne:
        //            var k = new Klient();
        //            PodmiotId = k.PodmiotId;
        //            break;
        //        case TypKontaEnum.Firma:
        //            var f = new Firma();
        //            PodmiotId = f.PodmiotId;
        //            break;
        //        case TypKontaEnum.Pracownik:
        //            var p = new Pracownik();
        //            PodmiotId = p.PodmiotId;
        //            break;
        //        case TypKontaEnum.Monitoring:
        //            var m = new Pracownik { DostepDoMonitoringu = true };
        //            PodmiotId = m.PodmiotId;
        //            break;
        //        case TypKontaEnum.Właściciel:
        //            var w = new Wlasciciel();
        //            PodmiotId = w.PodmiotId;
        //            break;
        //        default:
        //            break;
        //    }


        //}

        //internal void dodajRachunekDoHistorii(Rachunek rachunek)
        //{
        //    Historia.Add(rachunek);
        //}
    }
}