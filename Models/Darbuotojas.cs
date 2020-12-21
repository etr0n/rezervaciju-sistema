using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrozioSalonuISCF.Models
{
    public class Darbuotojas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DarbuotojasId { get; set; }

        [Required(ErrorMessage = "Laukelis negali būti tuščias")]
        [Display(Name = "Vardas")]
        public string vardas { get; set; }

        [Required(ErrorMessage = "Laukelis negali būti tuščias")]
        [Display(Name = "Pavardė")]
        public string pavarde { get; set; }


        [Required(ErrorMessage = "Laukelis negali būti tuščias")]
        [Display(Name = "Tel. Nr.")]
        public string tel_nr { get; set; }


        [Required(ErrorMessage = "Laukelis negali būti tuščias")]
        [Display(Name = "El. paštas")]
        public string email { get; set; }


        [Required(ErrorMessage = "Laukelis negali būti tuščias")]
        [Display(Name = "Adresas")]
        public string adresas { get; set; }

        [Required(ErrorMessage = "Laukelis negali būti tuščias")]
        [Display(Name = "Gimimo data")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime gimimo_data { get; set; }

        [Required(ErrorMessage = "Laukelis negali būti tuščias")]
        [Range(0, 9999999, ErrorMessage = "Stažas negali būti neigiamas")]
        [Display(Name = "Stažas")]
        public int stazas { get; set; }

        [Required(ErrorMessage = "Laukelis negali būti tuščias")]
        [Display(Name = "Pareigos")]
        public string pareigos { get; set; }


        //Foreign key salono
        public int SalonasId { get; set; }
        public Salonas Salonas { get; set; }

        public ICollection<Paslauga> Paslauga { get; set; }
    }
}

