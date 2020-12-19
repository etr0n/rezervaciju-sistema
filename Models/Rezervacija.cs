using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using GrozioSalonuISCF.Areas.Identity.Data;

namespace GrozioSalonuISCF.Models
{
    public class Rezervacija
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RezervacijaId { get; set; }
        public DateTime proc_prad { get; set; }
        public DateTime data { get; set; }
        public bool busenos { get; set; }

        //Foreign key user
        public string UserId { get; set; }
        public virtual GrozioSalonuISCFUser User { get; set; }

        //Foreign key pasluga
        public int PaslaugaId { get; set; }
        public Paslauga Paslauga { get; set; }
    }
}
