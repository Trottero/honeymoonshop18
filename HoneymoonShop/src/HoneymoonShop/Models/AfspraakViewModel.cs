using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HoneymoonShop.Models
{
    public class AfspraakViewModel
    {
        [Display(Name = "AfpstraakDatum")]
        public DateTime datum { get; set; }

        [Display(Name = "Afpstraak tijd")]
        public String tijd { get; set; }

        [Display(Name = "Voor- en achternaam")]
        public String naam { get; set; }

        [Display(Name = "Trouw datum")]
        public DateTime trouwDatum { get; set; }

        [Display(Name = "Telefoonnummer")]
        public String telefoon { get; set; }

        [Display(Name = "Email adres")]
        public string emailadres { get; set; }
    }
}
