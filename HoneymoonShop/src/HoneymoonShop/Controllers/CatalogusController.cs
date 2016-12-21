using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HoneymoonShop.Data;
using Models;
using Microsoft.EntityFrameworkCore;

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
            var jurken = _context.Jurken;
            return View(jurken);
        }


        public IActionResult Newcollection()
        {
            var jurken = _context.Jurken;
            return View(jurken);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jurk = await _context.Jurken.Include(j => j.Categorie).Include(j => j.Kleur).Include(j => j.Merk).Include(j => j.Neklijn).Include(j => j.Silhouette).Include(j => j.Stijl)
                .SingleOrDefaultAsync(m => m.JurkID == id);
            if (jurk == null)
            {
                return NotFound();
            }

            return View(jurk);
        }
        /*
        public async Task<IActionResult> Collection(String collection)
        {
            /*
            collection = "Summer SALE";

            if (collection == null || collection.Equals(""))
            {
                return NotFound();
            }


            var jurk = await _context.Jurken.Include(j => j.Categorie).Include(j => j.Kleur).Include(j => j.Merk).Include(j => j.Neklijn).Include(j => j.Silhouette).Include(j => j.Stijl).Select(m => m.Categorie.CategorieNaam.Equals(collection));
            if (jurk == null)
            {
                return NotFound();
            }

            return View(jurk);
            
        }*/
    }
}