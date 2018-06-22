using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektZespolowy.Models.RezerwcjaViewModels
{
    public class RezerwacjaIndex
    {
        public DateTime data { get; set; }
        public string UserName { get; set; }
        public string Usluga { get; set; }
        public int RezerwacjaId { get; set; }
    }
}
