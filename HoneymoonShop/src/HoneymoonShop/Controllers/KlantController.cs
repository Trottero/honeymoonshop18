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
    public class KlantController : Controller
    {
        public AfspraakViewModel afspraakModel;
        ApplicationDbContext _context;

        public KlantController(ApplicationDbContext context)
        {
            _context = context;
        }
        //standaard CRUD

        // GET: Jurken
        public async Task<IActionResult> Index()
        {
            return View(_context.Klanten2.ToList());
        }

        // GET: Categorien/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klant = await _context.Klanten2.SingleOrDefaultAsync(m => m.KlantID == id);
            if (klant == null)
            {
                return NotFound();
            }

            return View(klant);
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
        public IActionResult Create([Bind("KlantID,Naam,Trouwdatum,Telefoonnummer,Emailadres")] Klant Klant)
        {
                _context.Add(Klant);
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

            var klant = await _context.Klanten2.SingleOrDefaultAsync(m => m.KlantID == id);
            if (klant == null)
            {
                return NotFound();
            }
            return View(klant);
        }

        // POST: Categorien/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("KlantID,Naam,Trouwdatum,Telefoonnummer,Emailadres")] Klant klant)
        {
            if (id != klant.KlantID)
            {
                return NotFound();
            }
                try
                {
                    _context.Update(klant);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KlantExists(klant.KlantID))
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


        private bool KlantExists(int id)
        {
            return _context.Klanten2.Any(e => e.KlantID == id);
        }


        // GET: Categorien/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var klant = await _context.Klanten2.SingleOrDefaultAsync(m => m.KlantID == id);
            if (klant == null)
            {
                return NotFound();
            }

            return View(klant);
        }

        // POST: Categorien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var klant = _context.Klanten2.SingleOrDefault(m => m.KlantID == id);
            _context.Klanten2.Remove(klant);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}