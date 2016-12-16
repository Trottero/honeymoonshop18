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
        public string CategorieNaam { get; set; }

        public IList<Jurk> Jurken { get; set; }
    }
}