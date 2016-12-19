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
        public int JurkID { get; set; }

        //Should be unique
        [Display(Name = "Artikel nummer")]
        [Required]
        public int ArtikelNr { get; set; }

        //Foreign key for Merk
        [Display(Name = "Merk")]
        public int MerkID { get; set; }

        [Required]
        public Merk Merk { get; set; }

        //Foreign key for Categorie
        [Display(Name = "Categorie")]
        public int CategorieID { get; set; }

        [Required]
        public Categorie Categorie { get; set; }

        //Foreign key for Stijl
        [Display(Name = "Stijl")]
        public int StijlID { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public Stijl Stijl { get; set; }

        [Required]
        public int Prijs { get; set; }

        //Foreign key for Neklijn
        [Display(Name = "Neklijn")]
        public int NeklijnID { get; set; }

        [Required]
        public Neklijn Neklijn { get; set; }

        //Foreign key for Silhouette
        [Display(Name = "Silhouette")]
        public int SilhouetteID { get; set; }

        [Required]
        public Silhouette Silhouette { get; set; }

        //Foreign key for Kleur
        [Display(Name = "Kleur")]
        public int KleurID { get; set; }

        [Required]
        public Kleur Kleur { get; set; }

        [Required]
        public string Omschrijving { get; set; }

        [Display(Name = "Afbeelding 1")]
        public string AfbeeldingNaam1 { get; set; }

        [Display(Name = "Afbeelding 2")]
        public string AfbeeldingNaam2 { get; set; }

        [Display(Name = "Afbeelding 3")]
        public string AfbeeldingNaam3 { get; set; }

        [Display(Name = "Afbeelding 4")]
        public string AfbeeldingNaam4 { get; set; }
    }
}
