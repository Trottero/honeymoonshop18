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
        public List<int> selectedMerken { get; set; }

        public List<Jurk> filteredJurken { get; set; }
    }
}
