using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Stijlen")]
    public class Stijl
    {
        public int StijlID { get; set; }

        [Required]
        [Display(Name = "Stijl")]
        public string StijlNaam { get; set; }

        public virtual IList<Jurk> Jurken { get; set; }
    }
}