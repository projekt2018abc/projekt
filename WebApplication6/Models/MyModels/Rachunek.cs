using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektZespolowy.Models.MyModels
{
    public class Rachunek
    {
        public int RachunekId { get; set; }
        private List<WykonanaUsluga> Uslugi;
        public Podmiot Klient { get; set; }
        private int PunktyZysk { get; set; }
        private int PunktyWykorzystane { get; set; }
        private double Cena;
        public DateTime Data { get; set; }

        public void dodajUsluge(WykonanaUsluga usluga)
        {
            Uslugi.Add(usluga);
            aktualizuj();
        }
        public void usunUsluge(WykonanaUsluga usluga)
        {
            Uslugi.Remove(usluga);
            aktualizuj();
        }

        private void aktualizuj()
        {
            PunktyZysk = 0;
            PunktyWykorzystane = 0;
            Cena = 0;
            foreach(WykonanaUsluga usluga in Uslugi)
            {
                usluga.aktualizuj();
                PunktyZysk += usluga.DodanePunkty;
                PunktyWykorzystane += usluga.WykorzystanePunkty;
                Cena += usluga.Koszt;

            }
        }

        private bool wykorzystajPunkty(WykonanaUsluga usluga, int iloscProduktu)
        {
            int koszt = iloscProduktu * usluga.Usluga.PunktyKoszt;
            if (koszt > Klient.Ilosc_punktow)
                return false;
            usluga.wykorzystajPunkty(iloscProduktu);
            aktualizuj();
            return true;
        }
    }
}
