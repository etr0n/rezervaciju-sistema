﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrozioSalonuISCF.Models
{
    public class PaslaugosTipas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PaslaugosTipasId { get; set; }
        public string pavadinimas { get; set; }
        public ICollection<Paslauga> Paslauga{ get; set; }
    }
}
