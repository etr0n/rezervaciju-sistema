using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrozioSalonuISCF.Models
{
    public class Miestas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MiestasId { get; set; }

        [Required(ErrorMessage = "Laukelis negali būti tuščias")]
        [Display(Name = "Miestas")]
        public string pavadinimas { get; set; }
        public ICollection<Salonas> Salonas { get; set; }
    }
}
