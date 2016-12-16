using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    [Table("Jurken")]
    public class Jurk
    {
        [Key]
        public int ArtikelNr { get; set; }

        //Foreign key for Merk
        public int MerkID { get; set; }

        [Required]
        public Merk Merk { get; set; }

        //Foreign key for Categorie
        public int CategorieID { get; set; }

        [Required]
        public Categorie Categorie { get; set; }

        //Foreign key for Stijl
        public int StijlID { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public Stijl Stijl { get; set; }

        [Required]
        public int Prijs { get; set; }

        //Foreign key for Neklijn
        public int NeklijnID { get; set; }

        [Required]
        public Neklijn Neklijn { get; set; }

        //Foreign key for Silhouette
        public int SilhouetteID { get; set; }

        [Required]
        public Silhouette Silhouette { get; set; }
        
        //Foreign key for Kleur
        public int KleurID { get; set; }

        [Required]
        public Kleur Kleur { get; set; }

        [Required]
        public string Omschrijving { get; set; }

        [Display(Name = "Afbeelding")]
        public string AfbeeldingNaam { get; set; }
    }
}
