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

       public string PrijsRange { get; set; }

        public List<Neklijn> alleNeklijnen { get; set; }
        public List<Silhouette> alleSilhouetten { get; set; }

        public List<Kleur> alleKleuren { get; set; }


        public List<Jurk> filteredJurken { get; set; }
        public string sorteerOptie { get; set; }

        public string Categorie { get; set; }
        //Lists to save filter input from user;
        public List<Int32> selectedMerken { get; set; }
        public List<Int32> selectedStijlen { get; set; }
        public List<Int32> selectedNeklijnen{ get; set; }
        public List<Int32> selectedSilhouetten{ get; set; }
        public List<Int32> selectedKleuren { get; set; }

    }
}
