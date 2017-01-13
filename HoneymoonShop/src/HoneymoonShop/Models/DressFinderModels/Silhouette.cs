using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Silhouetten")]
    public class Silhouette
    {
        public int SilhouetteID { get; set; }

        [Required]
        [Display(Name = "Silhouette")]
        public string SilhouetteNaam { get; set; }

        public virtual IList<Jurk> Jurken { get; set; }

        [NotMapped]
        public bool IsSelected { get; set; } = false;
    }
}
