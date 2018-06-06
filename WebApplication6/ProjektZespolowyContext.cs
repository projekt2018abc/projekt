using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjektZespolowy.Models;

namespace ProjektZespolowy
{
    public class ProjektZespolowyContext : DbContext
    {
        DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder<ProjektZespolowyContext>();
        

        public DbSet<Osoba> Osoby { get; set; }
        public DbSet<Klient> Klienci { get; set; }


        public ProjektZespolowyContext(DbContextOptions<ProjektZespolowyContext>options)
            : base(options)
        {

        }
    }
}
