using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Afspraken")]
    public class Afspraak
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Datum")]
        public DateTime Datum { get; set; }

        [Display(Name = "Tijd")]
        public int Tijd { get; set; }

        //Foreign key for Klant ID
        [Display(Name = "Klant ID")]
        public int KlantID { get; set; }

        public virtual Klant Klant { get; set; }
    }
}
