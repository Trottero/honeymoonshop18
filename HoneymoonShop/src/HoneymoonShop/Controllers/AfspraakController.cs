using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HoneymoonShop.Data;
using Microsoft.EntityFrameworkCore;
using Models;
using HoneymoonShop.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HoneymoonShop.Controllers
{
    public class AfspraakController : Controller
    {
        ApplicationDbContext _context;

        public AfspraakController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
                AfspraakViewModel viewModel = new AfspraakViewModel();

                return View(viewModel);
        }

        public IActionResult Bevestig(AfspraakViewModel viewModel)
        {
            return View(viewModel);
        }
    

        public async Task<IActionResult> success(AfspraakViewModel viewModel)
        {

            return View("~/Views/Home/Index.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> Collection(CatalogusFilterModel filterModel)
        {
            ViewData["CategorieID"] = new SelectList(_context.Categorien, "CategorieID", "CategorieNaam");

            //CREATE LISTS OF SELECTED INPUT
            var selectedMerkIDs = (from merk in filterModel.alleMerken
                                   where merk.Status == "checked"
                                   select merk.MerkID).ToList();
            //Pass user input to view model
            filterModel.selectedMerken = selectedMerkIDs;

            var selectedStijlIDs = (from stijl in filterModel.alleStijlen
                                    where stijl.Status == "checked"
                                    select stijl.StijlID).ToList();
            //Pass user input to view model
            filterModel.selectedStijlen = selectedStijlIDs;

            var selectedNeklijnIDs = (from neklijn in filterModel.alleNeklijnen
                                      where neklijn.Status == "checked"
                                      select neklijn.NeklijnID).ToList();
            //Pass user input to view model
            filterModel.selectedNeklijnen = selectedNeklijnIDs;

            var selectedSilhouetteIDs = (from silhouette in filterModel.alleSilhouetten
                                         where silhouette.Status == "checked"
                                         select silhouette.SilhouetteID).ToList();


            //Pass user input to view model
            filterModel.selectedSilhouetten = selectedSilhouetteIDs;


            var selectedKleurIDs = (from kleur in filterModel.alleKleuren
                                    where kleur.Status == "checked"
                                    select kleur.KleurID).ToList();
            //Pass user input to view model
            filterModel.selectedKleuren = selectedKleurIDs;

            int minPrijs = 0;
            int maxPrijs = 10000;

            //Convert PrijsRange to minimum and maximum prijs
            if (!string.IsNullOrEmpty(filterModel.PrijsRange))
            {
                minPrijs = Int32.Parse(filterModel.PrijsRange.Split(',')[0]);
                maxPrijs = Int32.Parse(filterModel.PrijsRange.Split(',')[1]);
            }

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
            if (filterModel.sorteerOptie != null)
            {
                string caseSwitch = filterModel.sorteerOptie;
                switch (caseSwitch)
                {
                    case "Prijs Hoog/Laag":
                        filteredJurken = filteredJurken.OrderByDescending(j => j.Prijs);
                        break;
                    case "Prijs Laag/Hoog":
                        filteredJurken = filteredJurken.OrderBy(j => j.Prijs);
                        break;
                    case "Merk A-Z":
                        filteredJurken = filteredJurken.OrderBy(j => j.Merk.MerkNaam);
                        break;
                    case "Merk Z-A":
                        filteredJurken = filteredJurken.OrderByDescending(j => j.Merk.MerkNaam);
                        break;
                    default:
                        break;
                }

            }

            filterModel.filteredJurken = await filteredJurken.ToListAsync();
            return View(filterModel);
        }
    }
}