using System.Collections.Generic;

namespace ProjektZespolowy.Models.MyModels
{
    public class Stanowisko
    {
        public int StanowiskoId { get; set; }
        public string Typ { get; set; }
        public List<Usluga> DostepneUslugi { get; set; }
    }
}