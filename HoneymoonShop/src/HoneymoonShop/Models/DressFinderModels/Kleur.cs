using HoneymoonShop.Models.DressFinderModels;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Kleuren")]
    public class Kleur
    {
        public int KleurID { get; set; }

        [Required]
        [Display(Name = "Kleur")]
        public string KleurNaam { get; set; }

        public virtual List<JurkKleur> JurkKleuren { get; set; }

        [NotMapped]
        public string Status { get; set; }
    }
}
