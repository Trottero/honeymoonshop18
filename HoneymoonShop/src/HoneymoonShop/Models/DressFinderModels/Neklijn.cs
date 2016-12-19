using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Neklijnen")]
    public class Neklijn
    {
        public int NeklijnID { get; set; }
        public string NeklijnNaam { get; set; }

        public IList<Jurk> Jurken { get; set; }
    }
}