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
    public class StijlenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StijlenController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Stijlen
        public async Task<IActionResult> Index()
        {
            return View(await _context.Stijlen.ToListAsync());
        }

        // GET: Stijlen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stijl = await _context.Stijlen.SingleOrDefaultAsync(m => m.StijlID == id);
            if (stijl == null)
            {
                return NotFound();
            }

            return View(stijl);
        }

        // GET: Stijlen/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stijlen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StijlID,StijlNaam")] Stijl stijl)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stijl);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(stijl);
        }

        // GET: Stijlen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stijl = await _context.Stijlen.SingleOrDefaultAsync(m => m.StijlID == id);
            if (stijl == null)
            {
                return NotFound();
            }
            return View(stijl);
        }

        // POST: Stijlen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StijlID,StijlNaam")] Stijl stijl)
        {
            if (id != stijl.StijlID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stijl);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StijlExists(stijl.StijlID))
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
            return View(stijl);
        }

        // GET: Stijlen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stijl = await _context.Stijlen.SingleOrDefaultAsync(m => m.StijlID == id);
            if (stijl == null)
            {
                return NotFound();
            }

            return View(stijl);
        }

        // POST: Stijlen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stijl = await _context.Stijlen.SingleOrDefaultAsync(m => m.StijlID == id);
            _context.Stijlen.Remove(stijl);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool StijlExists(int id)
        {
            return _context.Stijlen.Any(e => e.StijlID == id);
        }
    }
}
