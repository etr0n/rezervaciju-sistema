using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrozioSalonuISCF.Models
{
    public class Vartotojas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int vartId { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public ICollection<Salonas> Salonas { get; set; }
        public ICollection<Rezervacija> Rezervacija { get; set; }
        public ICollection<Redagavimas> Redagavimas { get; set; }
    }
}
