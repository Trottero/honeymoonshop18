using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoneymoonShop.Models
{
    public class CatalogusFilterModel
    {        
        public List<Merk> alleMerken { get; set; }
        public List<Stijl> alleStijlen { get; set; }

        public int selectedMinimumPrijs { get; set; }
        public int selectedMaximumPrijs { get; set; }

        public List<Neklijn> alleNeklijnen { get; set; }
        public List<Silhouette> alleSilhouetten { get; set; }

        public List<Kleur> alleKleuren { get; set; }


        public List<Jurk> filteredJurken { get; set; }

        public string sorteerOptie { get; set; }
    }
}
