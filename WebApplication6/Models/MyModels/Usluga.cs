namespace ProjektZespolowy.Models.MyModels
{
    public class Usluga
    {
        public int UslugaId { get; set; }
        public string TypUslugi { get; set; }
        public double Cena { get; set; }

        //public double Cena {
        //    get
        //    {
        //        return Cena;
        //    }
        //    set
        //    {
        //        //System.Math.Round(value,2);
        //    }
        //}
        public int PunktyZysk { get; set; }
        public int PunktyKoszt { get; set; }

    }
}