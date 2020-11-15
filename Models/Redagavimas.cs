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
        public DateTime data { get; set; }
        public string priezastis { get; set; }
        public string tipas { get; set; }
        //Foreign key salono
        public int SalonoId { get; set; }
        public Salonas Salonas { get; set; }
        //Foreign key kliento
        public int KlientasId { get; set; }
        public Klientas Klientas { get; set; }
        //Foreign key admino
        public int AdminId { get; set; }
        public Admin Admin { get; set; }
    }
}
