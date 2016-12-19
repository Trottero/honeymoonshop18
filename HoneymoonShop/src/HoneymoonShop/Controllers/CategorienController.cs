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
    public class CategorienController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategorienController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Categorien
        public async Task<IActionResult> Index()
        {
            return View(await _context.Categorien.ToListAsync());
        }

        // GET: Categorien/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorie = await _context.Categorien.SingleOrDefaultAsync(m => m.CategorieID == id);
            if (categorie == null)
            {
                return NotFound();
            }

            return View(categorie);
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
        public async Task<IActionResult> Create([Bind("CategorieID,CategorieNaam")] Categorie categorie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categorie);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(categorie);
        }

        // GET: Categorien/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorie = await _context.Categorien.SingleOrDefaultAsync(m => m.CategorieID == id);
            if (categorie == null)
            {
                return NotFound();
            }
            return View(categorie);
        }

        // POST: Categorien/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategorieID,CategorieNaam")] Categorie categorie)
        {
            if (id != categorie.CategorieID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categorie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategorieExists(categorie.CategorieID))
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
            return View(categorie);
        }

        // GET: Categorien/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorie = await _context.Categorien.SingleOrDefaultAsync(m => m.CategorieID == id);
            if (categorie == null)
            {
                return NotFound();
            }

            return View(categorie);
        }

        // POST: Categorien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categorie = await _context.Categorien.SingleOrDefaultAsync(m => m.CategorieID == id);
            _context.Categorien.Remove(categorie);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CategorieExists(int id)
        {
            return _context.Categorien.Any(e => e.CategorieID == id);
        }
    }
}
