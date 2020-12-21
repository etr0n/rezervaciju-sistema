using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrozioSalonuISCF.Models
{
    public class Islaidos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IslaidosId { get; set; }

        [Required(ErrorMessage = "Laukelis negali būti tuščias")]
        [Range(0, 9999999, ErrorMessage = "Suma negali būti neigiama")]
        [Display(Name = "Suma")]
        public float suma { get; set; }

        [Required(ErrorMessage = "Laukelis negali būti tuščias")]
        [Display(Name = "Paskirtis")]
        public string paskirtis { get; set; }

        [Required(ErrorMessage = "Laukelis negali būti tuščias")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data")]
        public DateTime data { get; set; }

        //Foreign key salono
        public int SalonasId { get; set; }
        public Salonas Salonas { get; set; }

    }
}
