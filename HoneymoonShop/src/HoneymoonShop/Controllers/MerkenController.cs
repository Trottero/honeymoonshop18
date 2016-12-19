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
    public class MerkenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MerkenController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Merken
        public async Task<IActionResult> Index()
        {
            return View(await _context.Merken.ToListAsync());
        }

        // GET: Merken/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var merk = await _context.Merken.SingleOrDefaultAsync(m => m.MerkID == id);
            if (merk == null)
            {
                return NotFound();
            }

            return View(merk);
        }

        // GET: Merken/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Merken/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MerkID,MerkNaam")] Merk merk)
        {
            if (ModelState.IsValid)
            {
                _context.Add(merk);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(merk);
        }

        // GET: Merken/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var merk = await _context.Merken.SingleOrDefaultAsync(m => m.MerkID == id);
            if (merk == null)
            {
                return NotFound();
            }
            return View(merk);
        }

        // POST: Merken/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MerkID,MerkNaam")] Merk merk)
        {
            if (id != merk.MerkID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(merk);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MerkExists(merk.MerkID))
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
            return View(merk);
        }

        // GET: Merken/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var merk = await _context.Merken.SingleOrDefaultAsync(m => m.MerkID == id);
            if (merk == null)
            {
                return NotFound();
            }

            return View(merk);
        }

        // POST: Merken/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var merk = await _context.Merken.SingleOrDefaultAsync(m => m.MerkID == id);
            _context.Merken.Remove(merk);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool MerkExists(int id)
        {
            return _context.Merken.Any(e => e.MerkID == id);
        }
    }
}
