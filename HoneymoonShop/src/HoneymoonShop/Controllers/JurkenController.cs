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
            var applicationDbContext = _context.Jurken.Include(j => j.Categorie).Include(j => j.Kleur).Include(j => j.Merk).Include(j => j.Neklijn).Include(j => j.Silhouette).Include(j => j.Stijl);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Jurken/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jurk = await _context.Jurken.SingleOrDefaultAsync(m => m.JurkID == id);
            if (jurk == null)
            {
                return NotFound();
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
            return View();
        }

        // POST: Jurken/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JurkID,AfbeeldingNaam1,AfbeeldingNaam2,AfbeeldingNaam3,AfbeeldingNaam4,ArtikelNr,CategorieID,KleurID,MerkID,NeklijnID,Omschrijving,Prijs,SilhouetteID,StijlID")] Jurk jurk, 
            IFormFile afbeelding1, IFormFile afbeelding2, IFormFile afbeelding3, IFormFile afbeelding4)
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
                    if (file.Length > 0 && (file.Name.EndsWith(".jpg") || file.Name.EndsWith(".png")))
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

                //Add jurk to DbContext
                _context.Add(jurk);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            ViewData["CategorieID"] = new SelectList(_context.Categorien, "CategorieID", "CategorieNaam", jurk.CategorieID);
            ViewData["KleurID"] = new SelectList(_context.Kleuren, "KleurID", "KleurNaam", jurk.KleurID);
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

            var jurk = await _context.Jurken.SingleOrDefaultAsync(m => m.JurkID == id);
            if (jurk == null)
            {
                return NotFound();
            }
            ViewData["CategorieID"] = new SelectList(_context.Categorien, "CategorieID", "CategorieNaam", jurk.CategorieID);
            ViewData["KleurID"] = new SelectList(_context.Kleuren, "KleurID", "KleurNaam", jurk.KleurID);
            ViewData["MerkID"] = new SelectList(_context.Merken, "MerkID", "MerkNaam", jurk.MerkID);
            ViewData["NeklijnID"] = new SelectList(_context.Neklijnen, "NeklijnID", "NeklijnNaam", jurk.NeklijnID);
            ViewData["SilhouetteID"] = new SelectList(_context.Silhouetten, "SilhouetteID", "SilhouetteNaam", jurk.SilhouetteID);
            ViewData["StijlID"] = new SelectList(_context.Stijlen, "StijlID", "StijlNaam", jurk.StijlID);
            return View(jurk);
        }

        // POST: Jurken/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("JurkID,AfbeeldingNaam1,AfbeeldingNaam2,AfbeeldingNaam3,AfbeeldingNaam4,ArtikelNr,CategorieID,KleurID,MerkID,NeklijnID,Omschrijving,Prijs,SilhouetteID,StijlID")] Jurk jurk)
        {
            if (id != jurk.JurkID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jurk);
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
            ViewData["KleurID"] = new SelectList(_context.Kleuren, "KleurID", "KleurNaam", jurk.KleurID);
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

            var jurk = await _context.Jurken.SingleOrDefaultAsync(m => m.JurkID == id);
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
