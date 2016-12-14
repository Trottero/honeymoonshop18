using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HoneymoonShop.Data;
using HoneymoonShop.Models;

namespace HoneymoonShop.Controllers
{
    public class BruidsJurkenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BruidsJurkenController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: DressFinder
        public async Task<IActionResult> Index()
        {
            return View(await _context.BruidsJurken.ToListAsync());
        }

        // GET: DressFinder/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bruidsJurk = await _context.BruidsJurken.SingleOrDefaultAsync(m => m.ID == id);
            if (bruidsJurk == null)
            {
                return NotFound();
            }

            return View(bruidsJurk);
        }

        // GET: DressFinder/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DressFinder/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ArtikelNr,Merk,Naam,Omschrijving,Prijs,Stijl")] BruidsJurk bruidsJurk)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bruidsJurk);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(bruidsJurk);
        }

        // GET: DressFinder/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bruidsJurk = await _context.BruidsJurken.SingleOrDefaultAsync(m => m.ID == id);
            if (bruidsJurk == null)
            {
                return NotFound();
            }
            return View(bruidsJurk);
        }

        // POST: DressFinder/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ArtikelNr,Merk,Naam,Omschrijving,Prijs,Stijl")] BruidsJurk bruidsJurk)
        {
            if (id != bruidsJurk.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bruidsJurk);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BruidsJurkExists(bruidsJurk.ID))
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
            return View(bruidsJurk);
        }

        // GET: DressFinder/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bruidsJurk = await _context.BruidsJurken.SingleOrDefaultAsync(m => m.ID == id);
            if (bruidsJurk == null)
            {
                return NotFound();
            }

            return View(bruidsJurk);
        }

        // POST: DressFinder/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bruidsJurk = await _context.BruidsJurken.SingleOrDefaultAsync(m => m.ID == id);
            _context.BruidsJurken.Remove(bruidsJurk);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool BruidsJurkExists(int id)
        {
            return _context.BruidsJurken.Any(e => e.ID == id);
        }
    }
}
