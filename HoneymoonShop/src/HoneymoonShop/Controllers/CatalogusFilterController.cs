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

            filterModel.filteredJurken = _context.Jurken.Include(j => j.Categorie).Include(j => j.Kleur).Include(j => j.Merk).Include(j => j.Neklijn).Include(j => j.Silhouette).Include(j => j.Stijl).ToList();
            return View(filterModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(CatalogusFilterModel filterModel)
        {
            var jurken = from j in _context.Jurken.Include(j => j.Categorie).Include(j => j.Kleur).Include(j => j.Merk).Include(j => j.Neklijn).Include(j => j.Silhouette).Include(j => j.Stijl)
                         select j;
            //Filter merk
            if (filterModel.selectedMerken != null)
            {
                foreach (Merk merk in filterModel.selectedMerken)
                {
                    jurken = jurken.Where(j => j.Merk == merk);
                }
            }
            filterModel.filteredJurken = await jurken.ToListAsync();

            return View(filterModel);
        }
    }
}
