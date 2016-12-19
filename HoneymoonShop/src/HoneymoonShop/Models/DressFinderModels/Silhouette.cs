using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Silhouette")]
    public class Silhouette
    {
        public int SilhouetteID { get; set; }

        [Required]
        public string SilhouetteNaam { get; set; }

        public IList<Jurk> Jurken { get; set; }
    }
}