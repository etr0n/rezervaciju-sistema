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
        public string pavadinimas { get; set; }
        public string imones_kodas { get; set; }
        public string adresas { get; set; }
        public string tel_nr { get; set; }
        public string email { get; set; }
        public DateTime ikurimo_data { get; set; }
        public string password { get; set; }

        public ICollection<Paslauga> Paslauga { get; set; }
        
        //Foreign key miesto
        public int MiestasId { get; set; }
        public Miestas Miestas { get; set; }
        public ICollection<Islaidos> Islaidos { get; set; }
        public ICollection<Darbuotojas> Darbuotojas { get; set; }
        public ICollection<Redagavimas> Redagavimas { get; set; }
    }
}
