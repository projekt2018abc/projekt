using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektZespolowy.Models.MyModels
{
    public class Adres
    {
        public int AdresId { get; set; }
        public string Miejscowosc { get; set; }
        public string Kod_pocztowy { get; set; }
        public string Ulica { get; set; }
        public string Numer_domu { get; set; }
        public string Numer_lokalu { get; set; }
                
        public override string ToString()
        {
            if (Numer_lokalu != null)
            {
                return $"{Miejscowosc} {Kod_pocztowy}\n" +
                    $"{Ulica} {Numer_domu}/{Numer_lokalu}";
            }
            else
            {
                return $"{Miejscowosc} {Kod_pocztowy}\n" +
                    $"{Ulica} {Numer_domu}";
            }
        }
    }
}
