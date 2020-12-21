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

        [Required(ErrorMessage = "Laukelis negali būti tuščias")]
        [Display(Name = "Aprašymas")]
        public string aprasymas { get; set; }

        [Required(ErrorMessage = "Laukelis negali būti tuščias")]
        [Display(Name = "Paslaugos būsena")]
        public bool paslaugos_busena { get; set; }

        [Required(ErrorMessage = "Laukelis negali būti tuščias")]
        [Display(Name = "Data")]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}", ApplyFormatInEditMode=true)]
        public DateTime data { get; set; }

        [Required(ErrorMessage = "Laukelis negali būti tuščias")]
        [Display(Name = "Vardas")]
        public string vardas { get; set; }

        public ICollection<Rezervacija> Rezervacija { get; set; }
      

    }
}

