using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjektZespolowy.Models;
using ProjektZespolowy.Models.MyModels;
using WebApplication6.Models;

namespace WebApplication6.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Podmiot> Podmioty { get; set; }
        public DbSet<Osoba> Osoby { get; set; }
        public DbSet<Klient> Klienci { get; set; }
        public DbSet<Firma> Firmy { get; set; }
        public DbSet<Pracownik> Pracownicy { get; set; }
        public DbSet<Wlasciciel> Wlasciciele { get; set; }
        public DbSet<Adres> Adresy { get; set; }
        public DbSet<Faktura> Faktury { get; set; }
        public DbSet<Powiadomienie> Powiadomienia { get; set; }
        public DbSet<Usluga> Uslugi { get; set; }
        public DbSet<WykonanaUsluga> WykonaneUslugi { get; set; }
        public DbSet<Rachunek> Rachunki { get; set; }
        public DbSet<Rezerwacja> Rezerwacje { get; set; }





        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public ApplicationDbContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:projekt2018.database.windows.net,1433;Initial Catalog=ProjektZDB_2018-06-06T18-38Z;Persist Security Info=False;User ID=projekt2018abc;Password=dupA1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30");
        }
    }
}
