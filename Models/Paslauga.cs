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
        public string pavadinimas { get; set; }
        public string aprasymas { get; set; }
        public float kaina { get; set; }
        public float trukme { get; set; }
        public string priemones { get; set; }
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

