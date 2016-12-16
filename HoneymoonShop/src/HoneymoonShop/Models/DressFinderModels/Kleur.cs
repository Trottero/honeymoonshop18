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
        public string KleurNaam { get; set; }

        public IList<Jurk> Jurken { get; set; }
    }
}