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
        public float suma { get; set; }
        public string paskirtis { get; set; }
        public DateTime data { get; set; }

        //Foreign key salono
        public int SalonasId { get; set; }
        public Salonas Salonas { get; set; }

    }
}
