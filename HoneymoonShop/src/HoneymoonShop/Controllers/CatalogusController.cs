﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HoneymoonShop.Data;

namespace HoneymoonShop.Controllers
{
    public class CatalogusController : Controller
    {
        ApplicationDbContext _context;

        public CatalogusController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var jurken = _context.Jurken;
            return View(jurken);
        }


        public IActionResult Newcollection()
        {
            var jurken = _context.Jurken;
            return View(jurken);
        }

        public IActionResult Details(int artikelnummer)
        {
            ViewData["artikelnummer"] = artikelnummer;
            var jurken = _context.Jurken;
            return View(jurken);
        }

    }
}