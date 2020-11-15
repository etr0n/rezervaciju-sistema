using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrozioSalonuISCF.Models
{
    public class Rezervacija
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int nr { get; set; }
        public DateTime proc_prad { get; set; }
        public DateTime data { get; set; }
        public bool busenos { get; set; }

        //Foreign key kliento
        public int KlientasId { get; set; }
        public Klientas Klientas { get; set; }

        //Foreign key pasluga
        public int PaslaugaId { get; set; }
        public Paslauga Paslauga { get; set; }
    }
}
