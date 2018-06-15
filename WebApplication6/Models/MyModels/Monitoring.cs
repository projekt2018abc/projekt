using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektZespolowy.Models.MyModels
{
    public class Monitoring
    {
        public int Id { get; set; }
        public double PoziomPaliwa { get; set; }
        public double Cisnienie { get; set; }
        public double Temperatura { get; set; }
        public String Paliwo { get; set; }
        public DateTime Data { get; set; }

        public void zapiszDoBazy()
        {

        }
        public void sprawdzStan()
        {

        }
    }
}
