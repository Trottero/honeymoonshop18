﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Neklijnen")]
    public class Neklijn
    {
        public int NeklijnID { get; set; }

        [Display(Name = "Neklijn")]
        [Required]
        public string NeklijnNaam { get; set; }

        public virtual IList<Jurk> Jurken { get; set; }

        [NotMapped]
        public string Status { get; set; }
    }
}
