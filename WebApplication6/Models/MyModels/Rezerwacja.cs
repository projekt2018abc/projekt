using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication6.Models;

namespace ProjektZespolowy.Models.MyModels
{
    public class Rezerwacja
    {
        public int RezerwacjaId { get; set; }
        public DateTime Date { get; set; }
        public string usluga { get; set; }
        public string KlientId { get; set; }

        public void zapytanieTermin()
        {

        }
        public void rezerwacja()
        {

        }
    }
}
