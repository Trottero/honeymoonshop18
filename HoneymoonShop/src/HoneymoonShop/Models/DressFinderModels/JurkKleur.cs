using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HoneymoonShop.Models.DressFinderModels
{
    public class JurkKleur
    {
        public int JurkID { get; set; }
        public Jurk Jurk { get; set; }
        
        public int KleurID { get; set; }
        public Kleur Kleur { get; set; }

        [NotMapped]
        public bool selected { get; set; }

       
    }
}
