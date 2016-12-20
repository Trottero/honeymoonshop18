using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HoneymoonShop.Data;
using HoneymoonShop.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HoneymoonShop.Controllers
{
    public class CatalogusFilterController : Controller
    {
        ApplicationDbContext _context;

        public CatalogusFilterController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            CatalogusFilterModel filterModel = new CatalogusFilterModel();
            filterModel.alleMerken = new SelectList(_context.Merken.ToList());
            filterModel.huidigeJurken = _context.Jurken.ToList();
            return View(filterModel);
        }
    }
}
