using ProjektZespolowy.Models.MyModels;
using System;

namespace ProjektZespolowy.Models
{
    public class Osoba:Podmiot
    {
        //public int OsobaId { get; set; }              //id dziedziczymy z klasy Podmiot
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Haslo_hashed { get; set; }        //Używamy autentykacji z ASP więc racej nam się to nie przyda?
        public int? Pesel { get; set; }
        public string AppUserId { get; set; }           //Id obiektu klasy Application User
    }
}