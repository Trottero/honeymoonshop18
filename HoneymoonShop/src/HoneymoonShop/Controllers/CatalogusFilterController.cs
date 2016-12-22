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

            filterModel.filteredJurken = _context.Jurken.Include(j => j.Categorie).Include(j => j.Kleur).Include(j => j.Merk).Include(j => j.Neklijn).Include(j => j.Silhouette).Include(j => j.Stijl).ToList();
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


            var jurken = from j in _context.Jurken.Include(j => j.Categorie).Include(j => j.Kleur).Include(j => j.Merk).Include(j => j.Neklijn).Include(j => j.Silhouette).Include(j => j.Stijl)
                         select j;
            
            //Filter merk
            if (filterModel.selectedMerken != null)
            {
                foreach (int merkID in filterModel.selectedMerken)
                {
                    jurken = jurken.Where(j => j.Merk.MerkID == merkID);
                }
            }

            //Filter stijl
            if (filterModel.selectedStijlen != null)
            {
                foreach (int stijlID in filterModel.selectedStijlen)
                {
                    jurken = jurken.Where(j => j.Stijl.StijlID == stijlID);
                }
            }

            //Filter minimum prijs
            if (filterModel.selectedMinimumPrijs > 0)
            {
                jurken = jurken.Where(j => j.Prijs > filterModel.selectedMinimumPrijs);
                
            }

            //Filter maximum prijs
            if (filterModel.selectedMaximumPrijs < int.MaxValue)
            {
                jurken = jurken.Where(j => j.Prijs < filterModel.selectedMaximumPrijs);
            }

            //Filter neklijn
            if (filterModel.selectedNeklijnen != null)
            {
                foreach (int neklijnID in filterModel.selectedNeklijnen)
                {
                    jurken = jurken.Where(j => j.Neklijn.NeklijnID == neklijnID);
                }
            }

            //Filter silhouette
            if (filterModel.selectedSilhouetten != null)
            {
                foreach (int silhouetteID in filterModel.selectedSilhouetten)
                {
                    jurken = jurken.Where(j => j.Silhouette.SilhouetteID == silhouetteID);
                }
            }
            //Filter kleur
            if (filterModel.selectedKleuren != null)
            {
                foreach (int kleurID in filterModel.selectedKleuren)
                {
                    jurken = jurken.Where(j => j.Kleur.KleurID == kleurID);
                }
            }

            filterModel.filteredJurken = await jurken.ToListAsync();
            
            return View(filterModel);
        }
    }
}
