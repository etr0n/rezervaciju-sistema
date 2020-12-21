using GrozioSalonuISCF.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrozioSalonuISCF.Models
{
    public class Salonas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SalonasId { get; set; }

        [Display(Name = "SAlonas")]
        [Required(ErrorMessage = "Laukelis negali būti tuščias")]
        public string pavadinimas { get; set; }

        [Display(Name = "Įmonės kodas")]
        [Required(ErrorMessage = "Laukelis negali būti tuščias")]
        public string imones_kodas { get; set; }

        [Display(Name = "Adresas")]
        [Required(ErrorMessage = "Laukelis negali būti tuščias")]
        public string adresas { get; set; }

        [Display(Name = "Tel. Nr")]
        [Required(ErrorMessage = "Laukelis negali būti tuščias")]
        public string tel_nr { get; set; }

        [Display(Name = "El. paštas")]
        [Required(ErrorMessage = "Laukelis negali būti tuščias")]
        public string email { get; set; }


        [Required(ErrorMessage = "Laukelis negali būti tuščias")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Įkūrimo data")]
        public DateTime ikurimo_data { get; set; }

        public ICollection<Paslauga> Paslauga { get; set; }
        public ICollection<Islaidos> Islaidos { get; set; }
        public ICollection<Darbuotojas> Darbuotojas { get; set; }

        //Foreign key miesto
        public int MiestasId { get; set; }
        public Miestas Miestas { get; set; }

        //Foreign key user
        public string UserId { get; set; }
        public virtual GrozioSalonuISCFUser User { get; set; }

    }
}
