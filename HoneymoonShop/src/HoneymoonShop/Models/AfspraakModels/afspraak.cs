﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Afspraken2")]
    public class Afspraak
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Datum")]
        public String Datum { get; set; }
        
        [Display(Name = "Tijd")]
        public String Tijd { get; set; }

        //Foreign key for Klant ID
        [Display(Name = "Klant ID")]
        public int KlantID { get; set; }

        public virtual Klant Klant { get; set; }
    }
}
