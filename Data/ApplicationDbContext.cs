using System;
using System.Collections.Generic;
using System.Text;
using GrozioSalonuISCF.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GrozioSalonuISCF.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Atsiliepimas> Atsiliepimas { get; set; }
        public DbSet<Darbuotojas> Darbuotojas { get; set; }
        public DbSet<Islaidos> Islaidos { get; set; }
        public DbSet<Miestas> Miestas { get; set; }
        public DbSet<Paslauga> Paslauga { get; set; }
        public DbSet<PaslaugosTipas> PaslaugosTipas { get; set; }
        public DbSet<Redagavimas> Redagavimas { get; set; }
        public DbSet<Rezervacija> Rezervacija { get; set; }
        public DbSet<Salonas> Salonas { get; set; }
        public DbSet<Vartotojas> Vartotojas { get; set; }
    }
}
