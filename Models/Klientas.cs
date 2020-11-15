using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace GrozioSalonuISCF.Models
{
    public class Klientas
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KlientasId { get; set; }
        public string Vardas { get; set; }
        public string Pavarde { get; set; }
        public DateTime GimimoData { get; set; }
        public ICollection<Rezervacija> Rezervacija { get; set; }
        public ICollection<Redagavimas> Redagavimas { get; set; }
    }
}
