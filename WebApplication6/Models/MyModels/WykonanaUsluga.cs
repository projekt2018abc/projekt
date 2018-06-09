using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektZespolowy.Models.MyModels
{
    public class WykonanaUsluga
    {
        public Usluga Usluga { get; set; }
        public double Ilosc { get; set; }
        public int IloscZaPunkty { get; set; }
        public DateTime Data { get; set; }
        public double Koszt { get; set; }
        public int WykorzystanePunkty { get; set; }
        public int DodanePunkty { get; set; }

        public bool wykorzystajPunkty(int iloscProduktu)
        {
            int i = iloscProduktu+IloscZaPunkty;
            if (Ilosc - IloscZaPunkty < -1)
                return false;
            IloscZaPunkty = i;
            WykorzystanePunkty = Usluga.PunktyKoszt * IloscZaPunkty;
            aktualizuj();
            return true;


        }

        public void aktualizuj()
        {
            double i = Ilosc - IloscZaPunkty;
            if (i < 0)
                i = 0;
            Koszt = i * Usluga.Cena;
            DodanePunkty = (int)Ilosc * Usluga.PunktyZysk;
        }
        //!TODO
        public void WystawRachunek()
        {

        }
    }
}
