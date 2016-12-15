using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HoneymoonShop.Models
{
    public class BruidsJurk
    {
        public int ID { get; set; } //key

        [Required]
        [Display(Name = "Artikel Nummer")]
        public int ArtikelNr { get; set; }        

        public string Merk { get; set; }

        [Required]
        [StringLength(300)]
        public string Omschrijving { get; set; }

        public string Stijl { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public int Prijs { get; set; }

        /* TODO
        public string[] kenmerken { get; set; }
        */

        [Display(Name = "Afbeelding")]
        public string AfbeeldingUrl { get; set; }

    }
}
