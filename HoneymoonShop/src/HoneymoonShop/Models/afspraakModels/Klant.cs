using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Klanten")]
    public class Klant
    {
        [Key]
        public int KlantID { get; set; }

        [Display(Name = "Voor- en achternaam")]
        public String Naam { get; set; }
            
        [Display(Name = "Trouwdatum")]
        public DateTime Trouwdatum { get; set; }

        [Display(Name = "Telefoonnummer")]
        public int Telefoonnummer { get; set; }

        [Display(Name = "E-mailadres")]
        public String Emailadres { get; set; }
    }
}
