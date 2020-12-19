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
        public string vardas { get; set; }
        public string pavarde { get; set; }
        public string tel_nr { get; set; }
        public string email { get; set; }
        public string adresas { get; set; }
        public DateTime gimimo_data { get; set; }
        public int stazas { get; set; }
        public string pareigos { get; set; }


        //Foreign key salono
        public int SalonasId { get; set; }
        public Salonas Salonas { get; set; }

        public ICollection<Paslauga> Paslauga { get; set; }
    }
}

