using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HoneymoonShop.Data;
using Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Hosting;
using HoneymoonShop.Models.DressFinderModels;

namespace HoneymoonShop.Controllers
{
    public class JurkenController : Controller
    {
        private readonly ApplicationDbContext _context;
        private IHostingEnvironment _environment;

        public JurkenController(ApplicationDbContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        // GET: Jurken
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Jurken.Include(j => j.Categorie).Include(j => j.JurkKleuren).Include(j => j.Merk).Include(j => j.Neklijn).Include(j => j.Silhouette).Include(j => j.Stijl);
            foreach(var jurk in applicationDbContext)
            {
                foreach(var jurkkleur in jurk.JurkKleuren)
                {
                    jurkkleur.Jurk = _context.Jurken.Include(j => j.Categorie).Include(j => j.JurkKleuren).Include(j => j.Merk).Include(j => j.Neklijn).Include(j => j.Silhouette).Include(j => j.Stijl)
                                            .SingleOrDefault(m => m.JurkID == jurkkleur.JurkID);
                    jurkkleur.Kleur = _context.Kleuren.Include(j => j.JurkKleuren).SingleOrDefault(m => m.KleurID == jurkkleur.KleurID);
                }
            }
            
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Jurken/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jurk = await _context.Jurken.Include(j => j.Categorie).Include(j => j.JurkKleuren).Include(j => j.Merk).Include(j => j.Neklijn).Include(j => j.Silhouette).Include(j => j.Stijl)
                .SingleOrDefaultAsync(m => m.JurkID == id);
            if (jurk == null)
            {
                return NotFound();
            }

            foreach (var jurkkleur in jurk.JurkKleuren)
            {
                jurkkleur.Jurk = _context.Jurken.Include(j => j.Categorie).Include(j => j.JurkKleuren).Include(j => j.Merk).Include(j => j.Neklijn).Include(j => j.Silhouette).Include(j => j.Stijl)
                                        .SingleOrDefault(m => m.JurkID == jurkkleur.JurkID);
                jurkkleur.Kleur = _context.Kleuren.Include(j => j.JurkKleuren).SingleOrDefault(m => m.KleurID == jurkkleur.KleurID);
            }

            return View(jurk);
        }

        // GET: Jurken/Create
        public IActionResult Create()
        {
            ViewData["CategorieID"] = new SelectList(_context.Categorien, "CategorieID", "CategorieNaam");
            ViewData["KleurID"] = new SelectList(_context.Kleuren, "KleurID", "KleurNaam");
            ViewData["MerkID"] = new SelectList(_context.Merken, "MerkID", "MerkNaam");
            ViewData["NeklijnID"] = new SelectList(_context.Neklijnen, "NeklijnID", "NeklijnNaam");
            ViewData["SilhouetteID"] = new SelectList(_context.Silhouetten, "SilhouetteID", "SilhouetteNaam");
            ViewData["StijlID"] = new SelectList(_context.Stijlen, "StijlID", "StijlNaam");

            Jurk jurk = new Jurk();
            jurk.JurkKleuren = new List<JurkKleur>() { new JurkKleur(), new JurkKleur(), new JurkKleur()};

            return View(jurk);
        }

        // POST: Jurken/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Jurk jurk, IFormFile afbeelding1, IFormFile afbeelding2, IFormFile afbeelding3, IFormFile afbeelding4)

        {
            if (ModelState.IsValid)
            {
                //Upload attached images
                var path = Path.Combine(_environment.WebRootPath, "images");

                //Create List of attached files, only add file to list if file != null
                IList<IFormFile> images = (new List<IFormFile>() { afbeelding1, afbeelding2, afbeelding3, afbeelding4 }).
                    Where(x => (x != null)).ToList();

                foreach (IFormFile file in images)
                {                    
                    if (file.Length > 0) // && (file.Name.EndsWith(".jpg") || file.Name.EndsWith(".png")))
                    {
                        using (var fileStream = new FileStream(Path.Combine(path, file.FileName), FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream);
                        }
                    }
                }

                //Add images filenames to Jurk class, VERY UGLY CODE!!, TODO: Make Image model class if there's time left
                int index = 1;
                foreach(var image in images)
                {
                    if(index == 1) { jurk.AfbeeldingNaam1 = image.FileName; }
                    else if(index == 2) { jurk.AfbeeldingNaam2 = image.FileName; }
                    else if(index == 3) { jurk.AfbeeldingNaam3 = image.FileName; }
                    else if(index == 4) { jurk.AfbeeldingNaam4 = image.FileName; }
                    index++;
                }

                List<JurkKleur> JurkKleuren = new List<JurkKleur>();
                foreach(var jurkkleur in jurk.JurkKleuren)
                {
                    if(jurkkleur.selected)
                    {
                        JurkKleur JurkKleur = new JurkKleur();
                        JurkKleur.Jurk = _context.Jurken.Include(j => j.Categorie).Include(j => j.JurkKleuren).Include(j => j.Merk).Include(j => j.Neklijn).Include(j => j.Silhouette).Include(j => j.Stijl)
                                            .SingleOrDefault(m => m.JurkID == jurkkleur.JurkID);
                        JurkKleur.Kleur = _context.Kleuren.Include(j => j.JurkKleuren).SingleOrDefault(m => m.KleurID == jurkkleur.KleurID);
                        JurkKleuren.Add(JurkKleur);
                    }
                }
                //Add jurk to DbContext
                jurk.JurkKleuren = JurkKleuren;
                _context.Add(jurk);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            ViewData["CategorieID"] = new SelectList(_context.Categorien, "CategorieID", "CategorieNaam", jurk.CategorieID);
            ViewData["KleurID"] = new SelectList(_context.Kleuren, "KleurID", "KleurNaam", jurk.JurkKleuren);
            ViewData["MerkID"] = new SelectList(_context.Merken, "MerkID", "MerkNaam", jurk.MerkID);
            ViewData["NeklijnID"] = new SelectList(_context.Neklijnen, "NeklijnID", "NeklijnNaam", jurk.NeklijnID);
            ViewData["SilhouetteID"] = new SelectList(_context.Silhouetten, "SilhouetteID", "SilhouetteNaam", jurk.SilhouetteID);
            ViewData["StijlID"] = new SelectList(_context.Stijlen, "StijlID", "StijlNaam", jurk.StijlID);
            return View(jurk);
        }

        // GET: Jurken/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jurk = await _context.Jurken.Include(j => j.Categorie).Include(j => j.JurkKleuren).Include(j => j.Merk).Include(j => j.Neklijn).Include(j => j.Silhouette).Include(j => j.Stijl).
                SingleOrDefaultAsync(m => m.JurkID == id);
            if (jurk == null)
            {
                return NotFound();
            }
            ViewData["CategorieID"] = new SelectList(_context.Categorien, "CategorieID", "CategorieNaam", jurk.CategorieID);
            ViewData["KleurID"] = new SelectList(_context.Kleuren, "KleurID", "KleurNaam", jurk.JurkKleuren);
            ViewData["MerkID"] = new SelectList(_context.Merken, "MerkID", "MerkNaam", jurk.MerkID);
            ViewData["NeklijnID"] = new SelectList(_context.Neklijnen, "NeklijnID", "NeklijnNaam", jurk.NeklijnID);
            ViewData["SilhouetteID"] = new SelectList(_context.Silhouetten, "SilhouetteID", "SilhouetteNaam", jurk.SilhouetteID);
            ViewData["StijlID"] = new SelectList(_context.Stijlen, "StijlID", "StijlNaam", jurk.StijlID);

            jurk.JurkKleuren = new List<JurkKleur>() { new JurkKleur(), new JurkKleur(), new JurkKleur() };
            return View(jurk);
        }

        // POST: Jurken/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Jurk jurk,
            IFormFile afbeelding1, IFormFile afbeelding2, IFormFile afbeelding3, IFormFile afbeelding4)
        {
            if (id != jurk.JurkID)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
                try
                {
                    var path = Path.Combine(_environment.WebRootPath, "images");

                    //Create List of attached files, only add file to list if file != null
                    IList<IFormFile> images = (new List<IFormFile>() { afbeelding1, afbeelding2, afbeelding3, afbeelding4 }).
                        Where(x => (x != null)).ToList();

                    foreach (IFormFile file in images)
                    {
                        if (file.Length > 0) // && (file.Name.EndsWith(".jpg") || file.Name.EndsWith(".png")))
                        {
                            using (var fileStream = new FileStream(Path.Combine(path, file.FileName), FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                            }
                        }
                    }

                    //Add images filenames to Jurk class, VERY UGLY CODE!!, TODO: Make Image model class if there's time left
                    int index = 1;
                    foreach (var image in images)
                    {
                        if (index == 1) { jurk.AfbeeldingNaam1 = image.FileName; }
                        else if (index == 2) { jurk.AfbeeldingNaam2 = image.FileName; }
                        else if (index == 3) { jurk.AfbeeldingNaam3 = image.FileName; }
                        else if (index == 4) { jurk.AfbeeldingNaam4 = image.FileName; }
                        index++;
                    }
                    List<JurkKleur> JurkKleuren = new List<JurkKleur>();
                    foreach (var jurkkleur in jurk.JurkKleuren)
                    {
                        if (jurkkleur.selected)
                        {
                            JurkKleur JurkKleur = new JurkKleur();
                            JurkKleur.Jurk = _context.Jurken.Include(j => j.Categorie).Include(j => j.JurkKleuren).Include(j => j.Merk).Include(j => j.Neklijn).Include(j => j.Silhouette).Include(j => j.Stijl)
                                                .SingleOrDefault(m => m.JurkID == jurkkleur.JurkID);
                            JurkKleur.Kleur = _context.Kleuren.Include(j => j.JurkKleuren).SingleOrDefault(m => m.KleurID == jurkkleur.KleurID);
                            JurkKleuren.Add(JurkKleur);
                        }
                    }
                    
                    //Add jurk to DbContext
                    jurk.JurkKleuren = JurkKleuren;
                    string sqlComm = "delete from JurkKleur where JurkID = " + jurk.JurkID;
                    string sqlComm2 = "delete from Jurken where JurkID = " + jurk.JurkID;
                    _context.Database.ExecuteSqlCommand(sqlComm);
                    _context.Database.ExecuteSqlCommand(sqlComm2);
                    _context.SaveChanges();
                    _context.Add(jurk);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JurkExists(jurk.JurkID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["CategorieID"] = new SelectList(_context.Categorien, "CategorieID", "CategorieNaam", jurk.CategorieID);
            ViewData["KleurID"] = new SelectList(_context.Kleuren, "KleurID", "KleurNaam", jurk.JurkKleuren);
            ViewData["MerkID"] = new SelectList(_context.Merken, "MerkID", "MerkNaam", jurk.MerkID);
            ViewData["NeklijnID"] = new SelectList(_context.Neklijnen, "NeklijnID", "NeklijnNaam", jurk.NeklijnID);
            ViewData["SilhouetteID"] = new SelectList(_context.Silhouetten, "SilhouetteID", "SilhouetteNaam", jurk.SilhouetteID);
            ViewData["StijlID"] = new SelectList(_context.Stijlen, "StijlID", "StijlNaam", jurk.StijlID);
            return View(jurk);
        }

        // GET: Jurken/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jurk = await _context.Jurken.Include(j => j.Categorie).Include(j => j.JurkKleuren).Include(j => j.Merk).Include(j => j.Neklijn).Include(j => j.Silhouette).Include(j => j.Stijl)
                .SingleOrDefaultAsync(m => m.JurkID == id);
            foreach (var jurkkleur in jurk.JurkKleuren)
            {
                jurkkleur.Jurk = _context.Jurken.Include(j => j.Categorie).Include(j => j.JurkKleuren).Include(j => j.Merk).Include(j => j.Neklijn).Include(j => j.Silhouette).Include(j => j.Stijl)
                                        .SingleOrDefault(m => m.JurkID == jurkkleur.JurkID);
                jurkkleur.Kleur = _context.Kleuren.Include(j => j.JurkKleuren).SingleOrDefault(m => m.KleurID == jurkkleur.KleurID);
            }
            if (jurk == null)
            {
                return NotFound();
            }

            return View(jurk);
        }

        // POST: Jurken/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jurk = await _context.Jurken.SingleOrDefaultAsync(m => m.JurkID == id);
            _context.Jurken.Remove(jurk);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool JurkExists(int id)
        {
            return _context.Jurken.Any(e => e.JurkID == id);
        }
    }
}
