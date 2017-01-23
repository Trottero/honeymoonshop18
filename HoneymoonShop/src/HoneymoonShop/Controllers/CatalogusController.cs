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
    public class CatalogusController : Controller
    {
        ApplicationDbContext _context;

        public CatalogusController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            try
            {
                ViewData["CategorieID"] = new SelectList(_context.Categorien, "CategorieID", "CategorieNaam");

                CatalogusFilterModel filterModel = new CatalogusFilterModel();

                filterModel.alleMerken = _context.Merken.ToList();
                filterModel.alleStijlen = _context.Stijlen.ToList();
                filterModel.alleNeklijnen = _context.Neklijnen.ToList();
                filterModel.alleSilhouetten = _context.Silhouetten.ToList();
                filterModel.alleKleuren = _context.Kleuren.ToList();
                filterModel.filteredJurken = _context.Jurken.ToList();
                var jurken = from j in _context.Jurken.Include(j => j.Categorie).Include(j => j.Kleur).Include(j => j.Merk).Include(j => j.Neklijn).Include(j => j.Silhouette).Include(j => j.Stijl)
                             select j;
                jurken = jurken.Where(j => j.Categorie.CategorieNaam == "Nieuwe Collectie");
                List<Jurk> list = new List<Jurk>();
                int count = 0;
                foreach (var item in jurken)
                {
                    if (count < 6)
                    {
                        list.Add(item);
                    }
                    count++;
                }
                filterModel.filteredJurken = list;
                return View(filterModel);
            } catch (Exception e)
            {
                return Json(e);
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jurk = await _context.Jurken.Include(j => j.Categorie).Include(j => j.Kleur).Include(j => j.Merk).Include(j => j.Neklijn).Include(j => j.Silhouette).Include(j => j.Stijl)
                .SingleOrDefaultAsync(m => m.JurkID == id);
            var jurken = from j in _context.Jurken.Include(j => j.Categorie).Include(j => j.Kleur).Include(j => j.Merk).Include(j => j.Neklijn).Include(j => j.Silhouette).Include(j => j.Stijl)
                         select j;
            ViewData["Jurken"] = jurken;
            if (jurk == null)
            {
                return NotFound();
            }

            return View(jurk);
        }
        
        public async Task<IActionResult> Collection(String id)
            //id = collection name
        {
            ViewData["CategorieID"] = new SelectList(_context.Categorien, "CategorieID", "CategorieNaam");

            CatalogusFilterModel filterModel = new CatalogusFilterModel();          

            filterModel.alleMerken = _context.Merken.ToList();
            filterModel.alleStijlen = _context.Stijlen.ToList();
            filterModel.alleNeklijnen = _context.Neklijnen.ToList();
            filterModel.alleSilhouetten = _context.Silhouetten.ToList();
            filterModel.alleKleuren = _context.Kleuren.ToList();
            filterModel.filteredJurken = _context.Jurken.ToList();


            var jurken = from j in _context.Jurken.Include(j => j.Categorie).Include(j => j.Kleur).Include(j => j.Merk).Include(j => j.Neklijn).Include(j => j.Silhouette).Include(j => j.Stijl)
                         select j;
            if (id == null || id.Equals(""))
            {
                return View(filterModel);
            }
            id = Uri.UnescapeDataString(id);
            jurken = jurken.Where(j => j.Categorie.CategorieNaam == id);
            if (jurken == null)
            {
                return NotFound();
            }
            filterModel.filteredJurken = await jurken.ToListAsync();
            return View(filterModel);
        }

        [HttpPost]
        public async Task<IActionResult> Collection(CatalogusFilterModel filterModel)
        {
            ViewData["CategorieID"] = new SelectList(_context.Categorien, "CategorieID", "CategorieNaam");

            //CREATE LISTS OF SELECTED INPUT
            var selectedMerkIDs = (from merk in filterModel.alleMerken
                                   where merk.Status == "checked"
                                   select merk.MerkID).ToList();

            var selectedStijlIDs = (from stijl in filterModel.alleStijlen
                                    where stijl.Status == "checked"
                                    select stijl.StijlID).ToList();

            var selectedNeklijnIDs = (from neklijn in filterModel.alleNeklijnen
                                      where neklijn.Status == "checked"
                                      select neklijn.NeklijnID).ToList();

            var selectedSilhouetteIDs = (from silhouette in filterModel.alleSilhouetten
                                         where silhouette.Status == "checked"
                                         select silhouette.SilhouetteID).ToList();

            var selectedKleurIDs = (from kleur in filterModel.alleKleuren
                                    where kleur.Status == "checked"
                                    select kleur.KleurID).ToList();

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