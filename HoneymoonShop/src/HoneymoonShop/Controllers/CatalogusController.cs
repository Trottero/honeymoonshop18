using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HoneymoonShop.Data;
using Microsoft.EntityFrameworkCore;
using Models;

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
            return View(list);
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
            var jurken = from j in _context.Jurken.Include(j => j.Categorie).Include(j => j.Kleur).Include(j => j.Merk).Include(j => j.Neklijn).Include(j => j.Silhouette).Include(j => j.Stijl)
                         select j;
            if (id == null || id.Equals(""))
            {
                return View(jurken);
            }
            id = Uri.UnescapeDataString(id);
            jurken = jurken.Where(j => j.Categorie.CategorieNaam == id);
            if (jurken == null)
            {
                return NotFound();
            }

            return View(jurken);
        }
    }
}