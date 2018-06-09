using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektZespolowy.Models.MyModels
{
    public abstract class Podmiot
    {
        public int PodmiotId { get; set; }
        public int? Ilosc_punktow { get; set; }
        public Adres adres { get; set; }

        internal void dodajRachunekDoHistorii(Rachunek rachunek)
        {
            throw new NotImplementedException();
        }
    }
}
