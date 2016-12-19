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
        public string StijlNaam { get; set; }

        public IList<Jurk> Jurken { get; set; }
    }
}