using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HoneymoonShop.Controllers
{
    public class CatalogusController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Newcollection(int page)
        {
            ViewData["Page"] = page;
            return View();
        }
    }
}
