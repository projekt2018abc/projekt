using ProjektZespolowy.Models.MyModels;
using System;

namespace ProjektZespolowy.Models
{
    public abstract class Osoba:Podmiot
    {
        //public int OsobaId { get; set; }              //id dziedziczymy z klasy Podmiot
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int? Pesel { get; set; }
    }
}