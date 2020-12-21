using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrozioSalonuISCF.Models
{
    public class Atsiliepimas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AtsiliepimasId { get; set; }
        public string aprasymas { get; set; }
        public bool paslaugos_busena { get; set; }
        public DateTime data { get; set; }
        public string vardas { get; set; }

        public ICollection<Rezervacija> Rezervacija { get; set; }
      

    }
}

