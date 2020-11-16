using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrozioSalonuISCF.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GrozioSalonuISCF.Data
{
    public class GrozioSalonuISCFContext : IdentityDbContext<GrozioSalonuISCFUser>
    {
        public GrozioSalonuISCFContext(DbContextOptions<GrozioSalonuISCFContext> options)
            : base(options)
        {
        }

        public DbSet<GrozioSalonuISCFUser> User { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Admin", NormalizedName = "Admin".ToUpper() });
            //builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Salono Admin", NormalizedName = "SalonoAdmin".ToUpper() });
            //builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Klientas", NormalizedName = "Klientas".ToUpper() });

            //const string ADMIN_ID = "b4280b6a-0613-4cbd-a9e6-f1701e926e73";
            //const string ROLE_ID = ADMIN_ID;
            //builder.Entity<IdentityRole>().HasData(new IdentityRole
            //{
            //    Id = ROLE_ID,
            //    Name = "admin",
            //    NormalizedName = "ADMIN"
            //});
            //builder.Entity<GrozioSalonuISCFUser>().HasData(new GrozioSalonuISCFUser
            //{
            //    Id = ADMIN_ID,
            //    UserName = "admin@admin.com",
            //    NormalizedUserName = "ADMIN@ADMIN.COM",
            //    Email = "admin@admin.com",
            //    NormalizedEmail = "ADMIN@ADMIN.COM",
            //    EmailConfirmed = true,
            //    PasswordHash = "AQAAAAEAACcQAAAAEKdW6mZkJFNZdMCwsbRZcUdwN2eYXUl45+apvsSWmV5JMS0Ofxfdq7qPgyWnWmwN9Q==",
            //    SecurityStamp = "G6G5BJLRBBNRNWDVM66F2J76XF6A7VQ2",
            //    ConcurrencyStamp = "6b8b09ab-bd63-4399-95cc-d7ff9c2b50ea"
            //});
            //builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            //{
            //    RoleId = ROLE_ID,
            //    UserId = ADMIN_ID
            //});

        }
    }
}
