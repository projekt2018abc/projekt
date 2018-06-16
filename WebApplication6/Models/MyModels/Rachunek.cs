//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using WebApplication6.Data;

//namespace ProjektZespolowy.Models.MyModels
//{
//    public class Rachunek
//    {
//        public int RachunekId { get; set; }
//        private List<WykonanaUsluga> Uslugi;
//        //public Podmiot Klient { get; set; }
//        private int PunktyZysk { get; set; }
//        private int PunktyWykorzystane { get; set; }
//        private double Cena;
//        public DateTime Data { get; set; }
//        public String Paragon { get; set; }
//        public Faktura faktura { get; set; }

//        public void dodajUsluge(WykonanaUsluga usluga)
//        {
//            Uslugi.Add(usluga);
//            aktualizuj();
//        }
//        public void usunUsluge(WykonanaUsluga usluga)
//        {
//            Uslugi.Remove(usluga);
//            aktualizuj();
//        }

//        private void aktualizuj()
//        {
//            PunktyZysk = 0;
//            PunktyWykorzystane = 0;
//            Cena = 0;
//            foreach (WykonanaUsluga usluga in Uslugi)
//            {
//                usluga.aktualizuj();
//                PunktyZysk += usluga.DodanePunkty;
//                PunktyWykorzystane += usluga.WykorzystanePunkty;
//                Cena += usluga.Koszt;

//            }
//        }

//        //public bool wykorzystajPunkty(WykonanaUsluga usluga, int iloscProduktu)
//        //{
//        //    int koszt = iloscProduktu * usluga.Usluga.PunktyKoszt;
//        //    if (koszt > Klient.Ilosc_punktow)
//        //        return false;
//        //    usluga.wykorzystajPunkty(iloscProduktu);
//        //    aktualizuj();
//        //    return true;
//        //}

//        //public bool zatwierdzRachunek(bool czyFaktura)
//        //{
//        //    if (Klient.Ilosc_punktow < PunktyWykorzystane)
//        //    {
//        //        System.Console.WriteLine("Za mało punktów na koncie klienta");
//        //        return false;
//        //    }
//        //    Paragon = generujParagon();
//        //    Klient.Ilosc_punktow -= PunktyWykorzystane;
//        //    Klient.Ilosc_punktow += PunktyZysk;
//        //    Klient.dodajRachunekDoHistorii(this);
//        //    if (czyFaktura)
//        //        faktura = generujFakture();

//        //    using (ApplicationDbContext context = new ApplicationDbContext())
//        //    {
//        //        context.Add(this);
//        //        context.SaveChanges();
//        //    }

//        //    return true;


//        }

//        private Faktura generujFakture()
//        {
//            throw new NotImplementedException();
//        }

//        private string generujParagon()
//        {
//            Data = DateTime.Now;
//            return $"Stacja Paliw SPB\n" +
//                    $"{NaszaPlacowka.ToString()}\n" +
//                    $"{UslugiToString()}\n" +
//                    $"{Data}\n" +
//                    $"Dziękujemy za skorzystanie z naszych usług\n" +
//                    $"Zapraszamy ponownie!";

//        }

//        private string UslugiToString()
//        {
//            String lista = null;
//            foreach (WykonanaUsluga usluga in Uslugi)
//            {
//                if (usluga.IloscZaPunkty > 0)
//                    lista += $"{usluga.Usluga.TypUslugi} X {usluga.Ilosc}:{usluga.Ilosc * usluga.Usluga.Cena}PLN\n" +
//                            $"Z czego {usluga.IloscZaPunkty} za {usluga.WykorzystanePunkty} punkty\n" +
//                            $"Łącznie: {usluga.Koszt}\n";
//                else
//                    lista += $"{usluga.Usluga.TypUslugi} X {usluga.Ilosc}: {usluga.Koszt}PLN\n";
//            }
//            return lista;
//        }
//    }
//}
