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
        [Required]
        public int MerkID { get; set; }
        
        public virtual Merk Merk { get; set; }

        //Foreign key for Categorie
        [Display(Name = "Categorie")]
        [Required]
        public int CategorieID { get; set; }

        public virtual Categorie Categorie { get; set; }

        //Foreign key for Stijl
        [Display(Name = "Stijl")]
        [Required]
        public int StijlID { get; set; }

        [DataType(DataType.Currency)]
        public virtual Stijl Stijl { get; set; }

        [Required]
        public int Prijs { get; set; }

        //Foreign key for Neklijn
        [Display(Name = "Neklijn")]
        [Required]
        public int NeklijnID { get; set; }
                  
        public virtual Neklijn Neklijn { get; set; }

        //Foreign key for Silhouette
        [Display(Name = "Silhouette")]
        [Required]
        public int SilhouetteID { get; set; }

        public virtual Silhouette Silhouette { get; set; }

        //Foreign key for Kleur
        [Display(Name = "Kleur")]
        [Required]
        public int KleurID { get; set; }

        public virtual Kleur Kleur { get; set; }

        [Required]
        public string Omschrijving { get; set; }

        [Display(Name = "Afb. 1")]
        public string AfbeeldingNaam1 { get; set; }

        [Display(Name = "Afb. 2")]
        public string AfbeeldingNaam2 { get; set; }

        [Display(Name = "Afb. 3")]
        public string AfbeeldingNaam3 { get; set; }

        [Display(Name = "Afb 4")]
        public string AfbeeldingNaam4 { get; set; }
    }
}
