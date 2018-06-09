using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektZespolowy.Models.MyModels
{
    public class Adres
    {
        public string Miejscowosc { get; set; }
        public string Kod_pocztowy { get; set; }
        public string Ulica { get; set; }
        public string Numer_domu { get; set; }
        public string Numer_lokalu { get; set; }
    }
}
