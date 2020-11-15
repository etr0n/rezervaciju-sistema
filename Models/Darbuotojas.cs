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
        public string Vardas { get; set; }
        public string Pavarde { get; set; }
        public string tel_nr { get; set; }
        public string email { get; set; }

        //Foreign key salono
        public int SalonasId { get; set; }
        public Salonas Salonas { get; set; }

        public ICollection<Paslauga> Paslauga { get; set; }
    }
}

