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
        public DbSet<Klientas> Klientai { get; set; }
    }
}
