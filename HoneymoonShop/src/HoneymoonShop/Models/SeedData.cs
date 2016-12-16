using HoneymoonShop.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HoneymoonShop.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.BruidsJurken.Any())
                {
                    return;
                }

                context.BruidsJurken.AddRange(
                    new BruidsJurk
                    {
                        ArtikelNr = 1,
                        Merk = "Ladybird",
                        Omschrijving = "Jurk van ladybird",
                        Stijl = "Klassiek",
                        Prijs = 7500,
                        AfbeeldingUrl = "jurk1.jpg"
                    },
                    new BruidsJurk
                    {
                        ArtikelNr = 2,
                        Merk = "Ladybird",
                        Omschrijving = "Andere Jurk van ladybird",
                        Prijs = 10500,
                        Stijl = "Klassiek",
                        AfbeeldingUrl = "jurk2.jpg"
                    },
                    new BruidsJurk
                    {
                        ArtikelNr = 3,
                        Merk = "Pronovias",
                        Omschrijving = "Jurk van Pronovias",
                        Prijs = 1500,
                        Stijl = "Princess",
                        AfbeeldingUrl = "jurk3.jpg"
                    },
                    new BruidsJurk
                    {
                        ArtikelNr = 4,
                        Merk = "Pronovias",
                        Omschrijving = "Andere jurk van ladybird",
                        Prijs = 7500,
                        Stijl = "Princess",
                        AfbeeldingUrl = "jurk4.jpg"
                    },
                    new BruidsJurk
                    {
                        ArtikelNr = 5,
                        Merk = "Maggie Sottero",
                        Omschrijving = "Jurk van Maggie Sottero",
                        Prijs = 7500,
                        Stijl = "Princess",
                        AfbeeldingUrl = "jurk5.jpg"
                    },
                                        new BruidsJurk
                                        {
                                            ArtikelNr = 6,
                                            Merk = "Maggie Sottero",
                                            Omschrijving = "Jurk van Maggie Sottero",
                                            Prijs = 7500,
                                            Stijl = "Princess",
                                            AfbeeldingUrl = "jurk5.jpg"
                                        }
                                        ,
                                                            new BruidsJurk
                                                            {
                                                                ArtikelNr = 7,
                                                                Merk = "Maggie Sottero",
                                                                Omschrijving = "Jurk van Maggie Sottero",
                                                                Prijs = 7500,
                                                                Stijl = "Princess",
                                                                AfbeeldingUrl = "jurk5.jpg"
                                                            }
                                                            , new BruidsJurk
                                                            {
                                                                ArtikelNr = 8,
                                                                Merk = "Maggie Sottero",
                                                                Omschrijving = "Jurk van Maggie Sottero",
                                                                Prijs = 7500,
                                                                Stijl = "Princess",
                                                                AfbeeldingUrl = "jurk5.jpg"
                                                            }
                                                            , new BruidsJurk
                                                            {
                                                                ArtikelNr = 9,
                                                                Merk = "Maggie Sottero",
                                                                Omschrijving = "Jurk van Maggie Sottero",
                                                                Prijs = 7500,
                                                                Stijl = "Princess",
                                                                AfbeeldingUrl = "jurk5.jpg"
                                                            },
                                                                    new BruidsJurk
                                                                                {
                                                                                    ArtikelNr = 10 ,
                                                                                    Merk = "Maggie Sottero",
                                                                                    Omschrijving = "Jurk van Maggie Sottero",
                                                                                    Prijs = 7500,
                                                                                    Stijl = "Princess",
                                                                                    AfbeeldingUrl = "jurk5.jpg"
                                                                                },
                                                                    new BruidsJurk
                                                                    {
                                                                        ArtikelNr = 11,
                                                                        Merk = "Maggie Sottero",
                                                                        Omschrijving = "Jurk van Maggie Sottero",
                                                                        Prijs = 7500,
                                                                        Stijl = "Princess",
                                                                        AfbeeldingUrl = "jurk5.jpg"
                                                                    },
                                                                    new BruidsJurk
                                                                    {
                                                                        ArtikelNr = 12,
                                                                        Merk = "Maggie Sottero",
                                                                        Omschrijving = "Jurk van Maggie Sottero",
                                                                        Prijs = 7500,
                                                                        Stijl = "Princess",
                                                                        AfbeeldingUrl = "jurk5.jpg"
                                                                    },
                                                                    new BruidsJurk
                                                                    {
                                                                        ArtikelNr = 13,
                                                                        Merk = "Maggie Sottero",
                                                                        Omschrijving = "Jurk van Maggie Sottero",
                                                                        Prijs = 7500,
                                                                        Stijl = "Princess",
                                                                        AfbeeldingUrl = "jurk5.jpg"
                                                                    },
                                                                    new BruidsJurk
                                                                    {
                                                                        ArtikelNr = 14,
                                                                        Merk = "Maggie Sottero",
                                                                        Omschrijving = "Jurk van Maggie Sottero",
                                                                        Prijs = 7500,
                                                                        Stijl = "Princess",
                                                                        AfbeeldingUrl = "jurk5.jpg"
                                                                    }
                );

                context.SaveChanges();
                 

                    
            }
        }
    }
}
