using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HoneymoonShop.Data;
using HoneymoonShop.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HoneymoonShop.Controllers
{
    public class CatalogusFilterController : Controller
    {
        ApplicationDbContext _context;

        public CatalogusFilterController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            CatalogusFilterModel filterModel = new CatalogusFilterModel();
            ViewData["MerkID"] = new SelectList(_context.Merken, "MerkID", "MerkNaam");
            ViewData["KleurID"] = new SelectList(_context.Kleuren, "KleurID", "KleurNaam");
            ViewData["MerkID"] = new SelectList(_context.Merken, "MerkID", "MerkNaam");
            ViewData["NeklijnID"] = new SelectList(_context.Neklijnen, "NeklijnID", "NeklijnNaam");
            ViewData["SilhouetteID"] = new SelectList(_context.Silhouetten, "SilhouetteID", "SilhouetteNaam");
            ViewData["StijlID"] = new SelectList(_context.Stijlen, "StijlID", "StijlNaam");

            filterModel.alleMerken = _context.Merken.ToList();
            filterModel.alleStijlen = _context.Stijlen.ToList();
            filterModel.alleNeklijnen = _context.Neklijnen.ToList();
            filterModel.alleSilhouetten = _context.Silhouetten.ToList();
            filterModel.alleKleuren = _context.Kleuren.ToList();
            filterModel.filteredJurken = _context.Jurken.ToList();

            return View(filterModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(CatalogusFilterModel filterModel)
        {
            ViewData["MerkID"] = new SelectList(_context.Merken, "MerkID", "MerkNaam");
            ViewData["KleurID"] = new SelectList(_context.Kleuren, "KleurID", "KleurNaam");
            ViewData["MerkID"] = new SelectList(_context.Merken, "MerkID", "MerkNaam");
            ViewData["NeklijnID"] = new SelectList(_context.Neklijnen, "NeklijnID", "NeklijnNaam");
            ViewData["SilhouetteID"] = new SelectList(_context.Silhouetten, "SilhouetteID", "SilhouetteNaam");
            ViewData["StijlID"] = new SelectList(_context.Stijlen, "StijlID", "StijlNaam");

            

            //CREATE LISTS OF SELECTED INPUT
            var selectedMerkIDs = (from merk in filterModel.alleMerken
                                   where merk.IsSelected
                                   select merk.MerkID).ToList();

            var selectedStijlIDs = (from stijl in filterModel.alleStijlen
                                    where stijl.IsSelected
                                    select stijl.StijlID).ToList();

            var selectedNeklijnIDs = (from neklijn in filterModel.alleNeklijnen
                                      where neklijn.IsSelected
                                      select neklijn.NeklijnID).ToList();

            var selectedSilhouetteIDs = (from silhouette in filterModel.alleSilhouetten
                                         where silhouette.IsSelected
                                         select silhouette.SilhouetteID).ToList();

            var selectedKleurIDs = (from kleur in filterModel.alleKleuren
                                    where kleur.IsSelected
                                    select kleur.KleurID).ToList();

            //default values 
            int minPrijs = 0;
            int maxPrijs = 10000;
            //Get minimum and maximum prijs from Model.PrijsRange
            /*if (filterModel.PrijsRange != null)
            {
                minPrijs = Int32.Parse(filterModel.PrijsRange.Split(',')[0]);
                maxPrijs = Int32.Parse(filterModel.PrijsRange.Split(',')[1]);
            }*/
            //FILTER INPUT
            var filteredJurken = from jurk in _context.Jurken.Include(j => j.Merk).Include(j => j.Stijl).Include(j => j.Neklijn).Include(j => j.Silhouette).Include(j => j.Kleur)
                                 where (selectedMerkIDs == null || selectedMerkIDs.Count == 0 || selectedMerkIDs.Contains(jurk.MerkID))
                                 && (selectedStijlIDs == null || selectedStijlIDs.Count == 0 || selectedStijlIDs.Contains(jurk.StijlID))
                                 && (selectedNeklijnIDs == null || selectedNeklijnIDs.Count == 0 || selectedNeklijnIDs.Contains(jurk.NeklijnID))
                                 && (selectedSilhouetteIDs == null || selectedSilhouetteIDs.Count == 0 || selectedSilhouetteIDs.Contains(jurk.SilhouetteID))
                                 && (selectedKleurIDs == null || selectedKleurIDs.Count == 0 || selectedKleurIDs.Contains(jurk.KleurID))
                                 && jurk.Prijs > minPrijs
                                 && jurk.Prijs < maxPrijs                                 
                                 select jurk;


            //SORTEER
            if (filterModel.sorteerOptie != null && filterModel.sorteerOptie.Equals("Prijs Hoog/Laag"))
            {
                filteredJurken = filteredJurken.OrderByDescending(j => j.Prijs);
            }
            if (filterModel.sorteerOptie != null && filterModel.sorteerOptie.Equals("Prijs Laag/Hoog"))
            {
                filteredJurken = filteredJurken.OrderBy(j => j.Prijs);
            }

            if (filterModel.sorteerOptie != null && filterModel.sorteerOptie.Equals("Merk A-Z"))
            {
                filteredJurken = filteredJurken.OrderBy(j => j.Merk.MerkNaam);
            }
            if (filterModel.sorteerOptie != null && filterModel.sorteerOptie.Equals("Merk Z-A"))
            {
                filteredJurken = filteredJurken.OrderByDescending(j => j.Merk.MerkNaam);
            }

            //Fill filter after call
            /*filterModel.alleMerken = _context.Merken.ToList();
            filterModel.alleStijlen = _context.Stijlen.ToList();
            filterModel.alleNeklijnen = _context.Neklijnen.ToList();
            filterModel.alleSilhouetten = _context.Silhouetten.ToList();
            filterModel.alleKleuren = _context.Kleuren.ToList();
            filterModel.filteredJurken = _context.Jurken.ToList();*/


            filterModel.filteredJurken = await filteredJurken.ToListAsync();
            return View(filterModel);
        }
    }
}
