using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektZespolowy.Models.MyModels
{
    public class Faktura
    {
        public int FakturaId { get; set; }
        public DateTime Data { get; set; }

        public void wystaw(Podmiot podmiot,Usluga usluga)
        {

        }
    }
}
