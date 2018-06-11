﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using WebApplication6.Data;

namespace ProjektZespolowy.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180611210043_rachunek3")]
    partial class rachunek3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ProjektZespolowy.Models.MyModels.Adres", b =>
                {
                    b.Property<int>("AdresId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Kod_pocztowy");

                    b.Property<string>("Miejscowosc");

                    b.Property<string>("Numer_domu");

                    b.Property<string>("Numer_lokalu");

                    b.Property<string>("Ulica");

                    b.HasKey("AdresId");

                    b.ToTable("Adresy");
                });

            modelBuilder.Entity("ProjektZespolowy.Models.MyModels.Faktura", b =>
                {
                    b.Property<int>("FakturaId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Data");

                    b.HasKey("FakturaId");

                    b.ToTable("Faktury");
                });

            modelBuilder.Entity("ProjektZespolowy.Models.MyModels.Podmiot", b =>
                {
                    b.Property<int>("PodmiotId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AdresId");

                    b.Property<string>("AppUserId");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int?>("Ilosc_punktow");

                    b.HasKey("PodmiotId");

                    b.HasIndex("AdresId");

                    b.ToTable("Podmioty");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Podmiot");
                });

            modelBuilder.Entity("ProjektZespolowy.Models.MyModels.Powiadomienie", b =>
                {
                    b.Property<int>("PowiadomienieId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nazwa");

                    b.HasKey("PowiadomienieId");

                    b.ToTable("Powiadomienia");
                });

            modelBuilder.Entity("ProjektZespolowy.Models.MyModels.Rachunek", b =>
                {
                    b.Property<int>("RachunekId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Data");

                    b.Property<int?>("FakturaId");

                    b.Property<int?>("KlientPodmiotId");

                    b.Property<string>("Paragon");

                    b.HasKey("RachunekId");

                    b.HasIndex("FakturaId");

                    b.HasIndex("KlientPodmiotId");

                    b.ToTable("Rachunki");
                });

            modelBuilder.Entity("ProjektZespolowy.Models.MyModels.Rezerwacja", b =>
                {
                    b.Property<int>("RezerwacjaId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<int?>("UslugaId");

                    b.HasKey("RezerwacjaId");

                    b.HasIndex("UslugaId");

                    b.ToTable("Rezerwacje");
                });

            modelBuilder.Entity("ProjektZespolowy.Models.MyModels.Stanowisko", b =>
                {
                    b.Property<int>("StanowiskoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Typ");

                    b.HasKey("StanowiskoId");

                    b.ToTable("Stanowisko");
                });

            modelBuilder.Entity("ProjektZespolowy.Models.MyModels.Usluga", b =>
                {
                    b.Property<int>("UslugaId")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Cena");

                    b.Property<int>("PunktyKoszt");

                    b.Property<int>("PunktyZysk");

                    b.Property<int?>("StanowiskoId");

                    b.Property<string>("TypUslugi");

                    b.HasKey("UslugaId");

                    b.HasIndex("StanowiskoId");

                    b.ToTable("Uslugi");
                });

            modelBuilder.Entity("ProjektZespolowy.Models.MyModels.WykonanaUsluga", b =>
                {
                    b.Property<int>("WykonanaUslugaId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Data");

                    b.Property<int>("DodanePunkty");

                    b.Property<double>("Ilosc");

                    b.Property<int>("IloscZaPunkty");

                    b.Property<double>("Koszt");

                    b.Property<int?>("RachunekId");

                    b.Property<int?>("StanowiskoId");

                    b.Property<int?>("UslugaId");

                    b.Property<int>("WykorzystanePunkty");

                    b.Property<bool>("Zaksiegowano");

                    b.HasKey("WykonanaUslugaId");

                    b.HasIndex("RachunekId");

                    b.HasIndex("StanowiskoId");

                    b.HasIndex("UslugaId");

                    b.ToTable("WykonaneUslugi");
                });

            modelBuilder.Entity("WebApplication6.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<int>("PodmiotId");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<bool>("UserConfirmed");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("ProjektZespolowy.Models.MyModels.Firma", b =>
                {
                    b.HasBaseType("ProjektZespolowy.Models.MyModels.Podmiot");

                    b.Property<string>("Nazwa");

                    b.Property<string>("Regon");

                    b.ToTable("Firma");

                    b.HasDiscriminator().HasValue("Firma");
                });

            modelBuilder.Entity("ProjektZespolowy.Models.Osoba", b =>
                {
                    b.HasBaseType("ProjektZespolowy.Models.MyModels.Podmiot");

                    b.Property<string>("Imie");

                    b.Property<string>("Nazwisko");

                    b.Property<int?>("Pesel");

                    b.ToTable("Osoba");

                    b.HasDiscriminator().HasValue("Osoba");
                });

            modelBuilder.Entity("ProjektZespolowy.Models.Klient", b =>
                {
                    b.HasBaseType("ProjektZespolowy.Models.Osoba");

                    b.Property<string>("Nip");

                    b.ToTable("Klient");

                    b.HasDiscriminator().HasValue("Klient");
                });

            modelBuilder.Entity("ProjektZespolowy.Models.MyModels.Pracownik", b =>
                {
                    b.HasBaseType("ProjektZespolowy.Models.Osoba");

                    b.Property<bool>("DostepDoMonitoringu");

                    b.Property<string>("Stanowisko");

                    b.ToTable("Pracownik");

                    b.HasDiscriminator().HasValue("Pracownik");
                });

            modelBuilder.Entity("ProjektZespolowy.Models.MyModels.Wlasciciel", b =>
                {
                    b.HasBaseType("ProjektZespolowy.Models.MyModels.Pracownik");


                    b.ToTable("Wlasciciel");

                    b.HasDiscriminator().HasValue("Wlasciciel");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("WebApplication6.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("WebApplication6.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebApplication6.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("WebApplication6.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjektZespolowy.Models.MyModels.Podmiot", b =>
                {
                    b.HasOne("ProjektZespolowy.Models.MyModels.Adres", "adres")
                        .WithMany()
                        .HasForeignKey("AdresId");
                });

            modelBuilder.Entity("ProjektZespolowy.Models.MyModels.Rachunek", b =>
                {
                    b.HasOne("ProjektZespolowy.Models.MyModels.Faktura", "faktura")
                        .WithMany()
                        .HasForeignKey("FakturaId");

                    b.HasOne("ProjektZespolowy.Models.MyModels.Podmiot", "Klient")
                        .WithMany("Historia")
                        .HasForeignKey("KlientPodmiotId");
                });

            modelBuilder.Entity("ProjektZespolowy.Models.MyModels.Rezerwacja", b =>
                {
                    b.HasOne("ProjektZespolowy.Models.MyModels.Usluga", "usluga")
                        .WithMany()
                        .HasForeignKey("UslugaId");
                });

            modelBuilder.Entity("ProjektZespolowy.Models.MyModels.Usluga", b =>
                {
                    b.HasOne("ProjektZespolowy.Models.MyModels.Stanowisko")
                        .WithMany("DostepneUslugi")
                        .HasForeignKey("StanowiskoId");
                });

            modelBuilder.Entity("ProjektZespolowy.Models.MyModels.WykonanaUsluga", b =>
                {
                    b.HasOne("ProjektZespolowy.Models.MyModels.Rachunek")
                        .WithMany("Uslugi")
                        .HasForeignKey("RachunekId");

                    b.HasOne("ProjektZespolowy.Models.MyModels.Stanowisko", "Stanowisko")
                        .WithMany()
                        .HasForeignKey("StanowiskoId");

                    b.HasOne("ProjektZespolowy.Models.MyModels.Usluga", "Usluga")
                        .WithMany()
                        .HasForeignKey("UslugaId");
                });
#pragma warning restore 612, 618
        }
    }
}
