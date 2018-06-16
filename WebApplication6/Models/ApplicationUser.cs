using System;
using System.Collections.Generic;
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
        public bool UserConfirmed { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Pesel { get; set; }

        public string Nip { get; set; }

        public string Regon { get; set; }

        public int Points { get; set; }

        public bool IsNaturalPerson { get; set; }

        public List<Rachunek> Historia { get; set; }

        /** --------------------------------------- **/
        public int PodmiotId { get; set; }

        public void createPodmiotFromApplicationUser(TypKontaEnum typKonta)
        {
            switch (typKonta)
            {
                case TypKontaEnum.Indywidualne:
                    var k = new Klient();
                    PodmiotId = k.PodmiotId;
                    break;
                case TypKontaEnum.Firma:
                    var f = new Firma();
                    PodmiotId = f.PodmiotId;
                    break;
                case TypKontaEnum.Pracownik:
                    var p = new Pracownik();
                    PodmiotId = p.PodmiotId;
                    break;
                case TypKontaEnum.Monitoring:
                    var m = new Pracownik { DostepDoMonitoringu = true };
                    PodmiotId = m.PodmiotId;
                    break;
                case TypKontaEnum.Właściciel:
                    var w = new Wlasciciel();
                    PodmiotId = w.PodmiotId;
                    break;
                default:
                    break;
            }


        }

        internal void dodajRachunekDoHistorii(Rachunek rachunek)
        {
            Historia.Add(rachunek);
        }
    }
}