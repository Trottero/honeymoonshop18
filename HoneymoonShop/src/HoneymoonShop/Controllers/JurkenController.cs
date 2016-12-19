using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HoneymoonShop.Data;
using Models;

namespace HoneymoonShop.Controllers
{
    public class JurkenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JurkenController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Jurken
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Jurk.Include(j => j.Categorie).Include(j => j.Kleur).Include(j => j.Merk).Include(j => j.Neklijn).Include(j => j.Silhouette).Include(j => j.Stijl);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Jurken/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jurk = await _context.Jurk.SingleOrDefaultAsync(m => m.ArtikelNr == id);
            if (jurk == null)
            {
                return NotFound();
            }

            return View(jurk);
        }

        // GET: Jurken/Create
        public IActionResult Create()
        {
            ViewData["CategorieID"] = new SelectList(_context.Categorie, "CategorieID", "CategorieNaam");
            ViewData["KleurID"] = new SelectList(_context.Kleur, "KleurID", "KleurNaam");
            ViewData["MerkID"] = new SelectList(_context.Merk, "MerkID", "MerkNaam");
            ViewData["NeklijnID"] = new SelectList(_context.Neklijn, "NeklijnID", "NeklijnID");
            ViewData["SilhouetteID"] = new SelectList(_context.Silhouette, "SilhouetteID", "SilhouetteNaam");
            ViewData["StijlID"] = new SelectList(_context.Stijl, "StijlID", "StijlNaam");
            return View();
        }

        // POST: Jurken/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArtikelNr,AfbeeldingNaam,CategorieID,KleurID,MerkID,NeklijnID,Omschrijving,Prijs,SilhouetteID,StijlID")] Jurk jurk)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jurk);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["CategorieID"] = new SelectList(_context.Categorie, "CategorieID", "CategorieNaam", jurk.CategorieID);
            ViewData["KleurID"] = new SelectList(_context.Kleur, "KleurID", "KleurNaam", jurk.KleurID);
            ViewData["MerkID"] = new SelectList(_context.Merk, "MerkID", "MerkNaam", jurk.MerkID);
            ViewData["NeklijnID"] = new SelectList(_context.Neklijn, "NeklijnID", "NeklijnID", jurk.NeklijnID);
            ViewData["SilhouetteID"] = new SelectList(_context.Silhouette, "SilhouetteID", "SilhouetteNaam", jurk.SilhouetteID);
            ViewData["StijlID"] = new SelectList(_context.Stijl, "StijlID", "StijlNaam", jurk.StijlID);
            return View(jurk);
        }

        // GET: Jurken/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jurk = await _context.Jurk.SingleOrDefaultAsync(m => m.ArtikelNr == id);
            if (jurk == null)
            {
                return NotFound();
            }
            ViewData["CategorieID"] = new SelectList(_context.Categorie, "CategorieID", "CategorieNaam", jurk.CategorieID);
            ViewData["KleurID"] = new SelectList(_context.Kleur, "KleurID", "KleurNaam", jurk.KleurID);
            ViewData["MerkID"] = new SelectList(_context.Merk, "MerkID", "MerkNaam", jurk.MerkID);
            ViewData["NeklijnID"] = new SelectList(_context.Neklijn, "NeklijnID", "NeklijnID", jurk.NeklijnID);
            ViewData["SilhouetteID"] = new SelectList(_context.Silhouette, "SilhouetteID", "SilhouetteNaam", jurk.SilhouetteID);
            ViewData["StijlID"] = new SelectList(_context.Stijl, "StijlID", "StijlNaam", jurk.StijlID);
            return View(jurk);
        }

        // POST: Jurken/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArtikelNr,AfbeeldingNaam,CategorieID,KleurID,MerkID,NeklijnID,Omschrijving,Prijs,SilhouetteID,StijlID")] Jurk jurk)
        {
            if (id != jurk.ArtikelNr)
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
                    if (!JurkExists(jurk.ArtikelNr))
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
            ViewData["CategorieID"] = new SelectList(_context.Categorie, "CategorieID", "CategorieNaam", jurk.CategorieID);
            ViewData["KleurID"] = new SelectList(_context.Kleur, "KleurID", "KleurNaam", jurk.KleurID);
            ViewData["MerkID"] = new SelectList(_context.Merk, "MerkID", "MerkNaam", jurk.MerkID);
            ViewData["NeklijnID"] = new SelectList(_context.Neklijn, "NeklijnID", "NeklijnID", jurk.NeklijnID);
            ViewData["SilhouetteID"] = new SelectList(_context.Silhouette, "SilhouetteID", "SilhouetteNaam", jurk.SilhouetteID);
            ViewData["StijlID"] = new SelectList(_context.Stijl, "StijlID", "StijlNaam", jurk.StijlID);
            return View(jurk);
        }

        // GET: Jurken/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jurk = await _context.Jurk.SingleOrDefaultAsync(m => m.ArtikelNr == id);
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
            var jurk = await _context.Jurk.SingleOrDefaultAsync(m => m.ArtikelNr == id);
            _context.Jurk.Remove(jurk);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool JurkExists(int id)
        {
            return _context.Jurk.Any(e => e.ArtikelNr == id);
        }
    }
}
