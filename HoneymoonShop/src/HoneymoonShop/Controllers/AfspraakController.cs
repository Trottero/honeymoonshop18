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
        ApplicationDbContext _context;

        public AfspraakController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
                AfspraakViewModel viewModel = new AfspraakViewModel();

                return View(viewModel);
        }

        public IActionResult Bevestig(AfspraakViewModel viewModel)
        {
            return View(viewModel);
        }
    

        public IActionResult Success(AfspraakViewModel viewModel)
        {
            Klant klant = new Klant();
            klant.Naam = viewModel.naam;
            klant.Emailadres = viewModel.emailadres;
            klant.Telefoonnummer = viewModel.telefoon;
            klant.Trouwdatum = viewModel.trouwDatum;
            klant.KlantID = 1;

            _context.Add(klant);
            _context.SaveChangesAsync();

            Afspraak afspraak = new Afspraak();
            afspraak.Datum = viewModel.datum;
            afspraak.Tijd = viewModel.tijd;
            afspraak.KlantID = klant.KlantID;

            _context.Add(afspraak);
            _context.SaveChangesAsync();

            return View("~/Views/Home/Index.cshtml");
        }
    }
}