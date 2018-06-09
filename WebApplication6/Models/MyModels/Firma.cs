using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektZespolowy.Models.MyModels
{
    public class Firma:Podmiot
    {
        public string Regon { get; set; }
        public string Nazwa { get; set; }
        public string Haslo_hashed { get; set; }        //Używamy autentykacji z ASP więc racej nam się to nie przyda?
    }
}
