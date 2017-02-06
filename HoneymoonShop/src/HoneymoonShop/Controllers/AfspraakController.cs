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
        public AfspraakViewModel afspraakModel;
        ApplicationDbContext _context;

        public AfspraakController(ApplicationDbContext context)
        {
            _context = context;
        }
        //standaard CRUD

        // GET: Jurken
        public async Task<IActionResult> Index()
        {
            return View(_context.Afpsraken2.ToList());
        }

        // GET: Categorien/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var afspraak = await _context.Afpsraken2.SingleOrDefaultAsync(m => m.ID == id);
            if (afspraak == null)
            {
                return NotFound();
            }

            return View(afspraak);
        }

        // GET: Categorien/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categorien/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ID,Datum,Tijd,KlantID")] Afspraak afspraak)
        {
                _context.Add(afspraak);
                _context.SaveChanges();
                return RedirectToAction("Index");
        }

        // GET: Klant/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var afspraak = await _context.Afpsraken2.SingleOrDefaultAsync(m => m.ID == id);
            if (afspraak == null)
            {
                return NotFound();
            }
            return View(afspraak);
        }

        // POST: Categorien/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ID,Datum,Tijd,KlantID")] Afspraak afspraak)
        {
            if (id != afspraak.ID)
            {
                return NotFound();
            }
                try
                {
                    _context.Update(afspraak);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AfspraakExists(afspraak.ID))
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


        private bool AfspraakExists(int id)
        {
            return _context.Afpsraken2.Any(e => e.ID == id);
        }


        // GET: Categorien/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var afspraak = await _context.Afpsraken2.SingleOrDefaultAsync(m => m.ID == id);
            if (afspraak == null)
            {
                return NotFound();
            }

            return View(afspraak);
        }

        // POST: Categorien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var afspraak = _context.Afpsraken2.SingleOrDefault(m => m.ID == id);
            _context.Afpsraken2.Remove(afspraak);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        //klant afspraak maken
        public IActionResult Datum()
        {
            AfspraakViewModel viewModel = new AfspraakViewModel();

            return View(viewModel);
        }
        public IActionResult Gegevens(AfspraakViewModel viewModel)
        {
            return View(viewModel);
        }
        public IActionResult Bevestig(AfspraakViewModel viewModel)
        {
            afspraakModel = viewModel;
            return View(viewModel);
        }
    
        public async Task<IActionResult> success(AfspraakViewModel viewModel)
        {
            Klant klant = new Klant();
            klant.Naam = viewModel.naam;
            klant.Emailadres = viewModel.emailadres;
            klant.Telefoonnummer = viewModel.telefoon;
            klant.Trouwdatum = viewModel.trouwDatum;

            _context.Add(klant);
            await _context.SaveChangesAsync();

            Afspraak afspraak = new Afspraak();
            afspraak.Datum = viewModel.datum;
            afspraak.Tijd = viewModel.tijd;
            afspraak.KlantID = klant.KlantID;

            _context.Add(afspraak);
            await _context.SaveChangesAsync();

            return View("~/Views/Home/Index.cshtml");
        }
    }
}