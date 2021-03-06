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
    public class SilhouettenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SilhouettenController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Silhouetten
        public async Task<IActionResult> Index()
        {
            return View(await _context.Silhouetten.ToListAsync());
        }

        // GET: Silhouetten/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var silhouette = await _context.Silhouetten.SingleOrDefaultAsync(m => m.SilhouetteID == id);
            if (silhouette == null)
            {
                return NotFound();
            }

            return View(silhouette);
        }

        // GET: Silhouetten/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Silhouetten/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SilhouetteID,SilhouetteNaam")] Silhouette silhouette)
        {
            if (ModelState.IsValid)
            {
                _context.Add(silhouette);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(silhouette);
        }

        // GET: Silhouetten/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var silhouette = await _context.Silhouetten.SingleOrDefaultAsync(m => m.SilhouetteID == id);
            if (silhouette == null)
            {
                return NotFound();
            }
            return View(silhouette);
        }

        // POST: Silhouetten/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SilhouetteID,SilhouetteNaam")] Silhouette silhouette)
        {
            if (id != silhouette.SilhouetteID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(silhouette);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SilhouetteExists(silhouette.SilhouetteID))
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
            return View(silhouette);
        }

        // GET: Silhouetten/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var silhouette = await _context.Silhouetten.SingleOrDefaultAsync(m => m.SilhouetteID == id);
            if (silhouette == null)
            {
                return NotFound();
            }

            return View(silhouette);
        }

        // POST: Silhouetten/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var silhouette = await _context.Silhouetten.SingleOrDefaultAsync(m => m.SilhouetteID == id);
            _context.Silhouetten.Remove(silhouette);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool SilhouetteExists(int id)
        {
            return _context.Silhouetten.Any(e => e.SilhouetteID == id);
        }
    }
}
