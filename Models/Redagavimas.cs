using GrozioSalonuISCF.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrozioSalonuISCF.Models
{
    public class Redagavimas

    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RedagavimasId { get; set; }
        [Required(ErrorMessage = "Laukelis negali būti tuščias")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data")]
        public DateTime data { get; set; }

        [Required(ErrorMessage = "Laukelis negali būti tuščias")]
        [Display(Name = "Priežastis")]
        public string priezastis { get; set; }

        [Required(ErrorMessage = "Laukelis negali būti tuščias")]
        [Display(Name = "Tipas")]
        public string tipas { get; set; }


        //Foreign key user
        public string UserId { get; set; }
        public virtual GrozioSalonuISCFUser User { get; set; }
    }
}
