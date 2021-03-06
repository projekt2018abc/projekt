﻿using System;
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
        public DbSet<Adres> Adresy { get; set; }
        public DbSet<Faktura> Faktury { get; set; }
        public DbSet<Powiadomienie> Powiadomienia { get; set; }
        public DbSet<Usluga> Uslugi { get; set; }
        public DbSet<WykonanaUsluga> WykonaneUslugi { get; set; }
        public DbSet<Rachunek> Rachunki { get; set; }
        public DbSet<Rezerwacja> Rezerwacje { get; set; }
        public DbSet<Monitoring> Monitorings { get; set; }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }





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
            optionsBuilder.UseSqlServer(Startup.DbConnectionString);
        }
        public DbSet<ProjektZespolowy.Models.MyModels.Stanowisko> Stanowisko { get; set; }
    }
}
