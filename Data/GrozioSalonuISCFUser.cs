using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using GrozioSalonuISCF.Models;

namespace GrozioSalonuISCF.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the GrozioSalonuISCFUser class
    public class GrozioSalonuISCFUser : IdentityUser
    {
        public string LastName { get; set; }
        public virtual ICollection<Redagavimas> Redagavimas { get; set; }
        public virtual ICollection<Rezervacija> Rezervacija { get; set; }
        public virtual ICollection<Salonas> Salonas { get; set; }

    }
}
