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
        public DateTime data { get; set; }
        public string priezastis { get; set; }
        public string tipas { get; set; }
        //Foreign key user
        public string UserId { get; set; }
        public virtual GrozioSalonuISCFUser User { get; set; }
    }
}
