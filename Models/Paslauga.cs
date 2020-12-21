using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrozioSalonuISCF.Models
{
    public class Paslauga
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaslaugaId { get; set; }

        [Required(ErrorMessage = "Laukelis negali būti tuščias")]
        [Display(Name = "Paslauga")]
        public string pavadinimas { get; set; }

        [Required(ErrorMessage = "Laukelis negali būti tuščias")]
        [Display(Name = "Aprašymas")]
        public string aprasymas { get; set; }

        [Required(ErrorMessage = "Laukelis negali būti tuščias")]
        [Range(0, 9999999, ErrorMessage = "Kaina negali būti neigiama")]
        [Display(Name = "Kaina")]
        public float kaina { get; set; }

        [Required(ErrorMessage = "Laukelis negali būti tuščias")]
        [Range(0, 9999999, ErrorMessage = "Trukmė  negali būti neigiama")]
        [Display(Name = "Trukmė")]
        public float trukme { get; set; }

        [Required(ErrorMessage = "Laukelis negali būti tuščias")]
        [Display(Name = "Priemonės")]
        public string priemones { get; set; }

        [Required(ErrorMessage = "Laukelis negali būti tuščias")]
        [Display(Name = "Rekomendacijos")]
        public string rekomendacijos { get; set; }

        public ICollection<Rezervacija> Rezervacija { get; set; }
        //public ICollection<Atsiliepimas> Atsiliepimas { get; set; }

        //Foreign key darbuotojo
        public int DarbuotojasId { get; set; }
        public Darbuotojas Darbuotojas { get; set; }

        //Foreign key salono
        public int SalonasId { get; set; }
        public Salonas Salonas { get; set; }
       
        //Foreign key paslaugos tipo
        public int PaslaugosTipasId { get; set; }
        public PaslaugosTipas PaslaugosTipas { get; set; }
    }
}

