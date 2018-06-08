using System;

namespace ProjektZespolowy.Models
{
    public class Osoba
    {
        public int OsobaId { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Haslo_hashed { get; set; }        //Używamy autentykacji z ASP więc racej nam się to nie przyda?
        public int? Pesel { get; set; }
        public string AppUserId { get; set; }           //Id obiektu klasy Application User
    }
}