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

        [Display(Name = "Procedūros data")]
        [Required(ErrorMessage = "Laukelis negali būti tuščias")]
        public DateTime proc_prad { get; set; }

        [Display(Name = "Užklausos data")]
        [Required(ErrorMessage = "Laukelis negali būti tuščias")]
        public DateTime data { get; set; }

        [Display(Name = "Būsena")]
        [Required(ErrorMessage = "Laukelis negali būti tuščias")]
        public string busena { get; set; }

        //FK atsiliepimo
        public int AtsiliepimasId { get; set; }
        public Atsiliepimas Atsiliepimas { get; set; }

        //Foreign key user
        public string UserId { get; set; }
        public virtual GrozioSalonuISCFUser User { get; set; }

        //Foreign key pasluga
        public int PaslaugaId { get; set; }
        public Paslauga Paslauga { get; set; }
    }
}
