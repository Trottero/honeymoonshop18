using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Categorien")]
    public class Categorie
    {
        public int CategorieID { get; set; }

        [Required]
        [Display(Name = "Categorie")]
        public string CategorieNaam { get; set; }

        public virtual IList<Jurk> Jurken { get; set; }
    }
}