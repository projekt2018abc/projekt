using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektZespolowy.Models.MyModels
{
    public class NaszaPlacowka
    {
        public static Adres adres = new Adres
        {
            Miejscowosc = "Kraków",
            Kod_pocztowy = "31-864",
            Ulica = " ul. Jana Pawła II",
            Numer_domu = "37"
        };
        public static String Telefon = "(070)012-34-56";
        public static String Fax = "(070)-011-22-33";

        public static String ToString()
        {
            return $"{adres.ToString()}\n" +
                $"Telefon:{Telefon}\n" +
                $"Fax:{Fax}";
        }
    }
}