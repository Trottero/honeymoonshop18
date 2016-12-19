using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Merk")]
    public class Merk
    {
        public int MerkID { get; set; }

        [Display(Name = "Merk")]
        [Required]
        public string MerkNaam { get; set; }

        public virtual IList<Jurk> Jurken { get; set; }
    }
}