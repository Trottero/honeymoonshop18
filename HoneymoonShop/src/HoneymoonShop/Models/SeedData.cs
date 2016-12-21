using HoneymoonShop.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Models;
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
               
                //clearJurken(context); //Verwijder alle jurken in Db
                SeedMerken(context);
                SeedCategorien(context);
                SeedStijlen(context);
                SeedNeklijnen(context);
                SeedSilhouetten(context);
                SeedKleuren(context);
                context.SaveChanges();

                SeedJurken(context);
                //context.SaveChanges();
            }
        }

        private static void clearJurken(ApplicationDbContext context)
        {
            context.Database.ExecuteSqlCommand("delete from Jurken");
        }

        private static void SeedMerken(ApplicationDbContext context)
        {
            if (context.Merken.Any())
            {
                return;
            }
            IList<String> merkenSeedList = new List<string>() { "Ladybird", "Diane Legrand", "Pronovias", "Maggie Sottero", "Badgley & Mischka", "Eddy K.", "Blue by Enzoani", "Modeca" };
            foreach(string merk in merkenSeedList)
            {
                context.Merken.Add(new Merk() { MerkNaam = merk } );
            }
        }

        private static void SeedCategorien(ApplicationDbContext context)
        {
            if (context.Categorien.Any())
            {
                return;
            }
            IList<String> catoegorienSeedList = new List<string>() { "Summer SALE", "Nieuwe Collectie", "Winter SALE"};
            foreach (string categorie in catoegorienSeedList)
            {
                context.Categorien.Add(new Categorie() { CategorieNaam = categorie });
            }
        }

        private static void SeedKleuren(ApplicationDbContext context)
        {
            if (context.Kleuren.Any())
            {
                return;
            }
            IList<String> kleurenSeedList = new List<string>() { "Ivoor/Wit", "Ivoor met kleur", "Gekleurd" };
            foreach (string kleur in kleurenSeedList)
            {
                context.Kleuren.Add(new Kleur() { KleurNaam = kleur });
            }
        }

        private static void SeedStijlen(ApplicationDbContext context)
        {
            if (context.Stijlen.Any())
            {
                return;
            }
            IList<String> stijlenSeedList = new List<string>() { "Kant", "Klassieke Bruid", "Princes Bruid", "Ruches Rok", "Modieuze Bruid" };
            foreach (string stijl in stijlenSeedList)
            {
                context.Stijlen.Add(new Stijl() { StijlNaam = stijl });
            }
        }

        private static void SeedNeklijnen(ApplicationDbContext context)
        {
            if (context.Neklijnen.Any())
            {
                return;
            }
            IList<string> neklijnenSeedList = new List<string>() { "Schouderbandjes", "Neklijn2" };
            foreach (string neklijn in neklijnenSeedList)
            {
                context.Neklijnen.Add(new Neklijn() { NeklijnNaam = neklijn });
            }
        }

        private static void SeedSilhouetten(ApplicationDbContext context)
        {
            if (context.Silhouetten.Any())
            {
                return;
            }
            IList<string> silhouetteSeedList = new List<string>() { "Lage Rug", "Fishtail" };
            foreach (string silhouette in silhouetteSeedList)
            {
                context.Silhouetten.Add(new Silhouette() { SilhouetteNaam = silhouette });
            }
        }

        private static void SeedJurken(ApplicationDbContext context)
        {
            if(context.Jurken.Any())
            {
                return;
            }
            List<Jurk> jurkenSeedList = new List<Jurk>()
            {
                new Jurk() {
                    ArtikelNr = 1,
                    CategorieID = 3,
                    MerkID = 2,
                    NeklijnID = 1,
                    SilhouetteID = 1,
                    Prijs= 1500,
                    KleurID = 1,
                    StijlID = 2,
                    Omschrijving = "Leuke jurk ",
                    AfbeeldingNaam1 ="jurk2.jpg",
                    AfbeeldingNaam2 ="jurk2.jpg",
                    AfbeeldingNaam3 ="jurk3.jpg",
                    AfbeeldingNaam4 ="jurk4.jpg",
                },
                new Jurk() {
                    ArtikelNr = 2,
                    CategorieID = 3,
                    MerkID = 2,
                    NeklijnID = 1,
                    SilhouetteID = 1,
                    Prijs= 1500,
                    KleurID = 1,
                    StijlID = 2,
                    Omschrijving = "Leuke jurk ",
                    AfbeeldingNaam1 ="jurk1.jpg",
                    AfbeeldingNaam2 ="jurk2.jpg",
                    AfbeeldingNaam3 ="jurk3.jpg",
                    AfbeeldingNaam4 ="jurk4.jpg",
                },
                new Jurk() {
                    ArtikelNr = 3,
                    CategorieID = 3,
                    MerkID = 2,
                    NeklijnID = 1,
                    SilhouetteID = 1,
                    Prijs= 1500,
                    KleurID = 1,
                    StijlID = 2,
                    Omschrijving = "Leuke jurk ",
                    AfbeeldingNaam1 ="jurk4.jpg",
                    AfbeeldingNaam2 ="jurk2.jpg",
                    AfbeeldingNaam3 ="jurk3.jpg",
                    AfbeeldingNaam4 ="jurk4.jpg",
                },
                new Jurk() {
                    ArtikelNr = 4,
                    CategorieID = 3,
                    MerkID = 2,
                    NeklijnID = 1,
                    SilhouetteID = 1,
                    Prijs= 1500,
                    KleurID = 1,
                    StijlID = 2,
                    Omschrijving = "Leuke jurk ",
                    AfbeeldingNaam1 ="jurk2.jpg",
                    AfbeeldingNaam2 ="jurk2.jpg",
                    AfbeeldingNaam3 ="jurk3.jpg",
                    AfbeeldingNaam4 ="jurk4.jpg",
                },
                new Jurk() {
                    ArtikelNr = 5,
                    CategorieID = 3,
                    MerkID = 2,
                    NeklijnID = 1,
                    SilhouetteID = 1,
                    Prijs= 1500,
                    KleurID = 1,
                    StijlID = 2,
                    Omschrijving = "Leuke jurk ",
                    AfbeeldingNaam1 ="jurk1.jpg",
                    AfbeeldingNaam2 ="jurk2.jpg",
                    AfbeeldingNaam3 ="jurk3.jpg",
                    AfbeeldingNaam4 ="jurk4.jpg",
                },
                new Jurk() {
                    ArtikelNr = 6,
                    CategorieID = 3,
                    MerkID = 2,
                    NeklijnID = 1,
                    SilhouetteID = 1,
                    Prijs= 1500,
                    KleurID = 1,
                    StijlID = 2,
                    Omschrijving = "Leuke jurk ",
                    AfbeeldingNaam1 ="jurk1.jpg",
                    AfbeeldingNaam2 ="jurk2.jpg",
                    AfbeeldingNaam3 ="jurk3.jpg",
                    AfbeeldingNaam4 ="jurk4.jpg",
                },
                new Jurk() {
                    ArtikelNr = 7,
                    CategorieID = 3,
                    MerkID = 2,
                    NeklijnID = 1,
                    SilhouetteID = 1,
                    Prijs= 1500,
                    KleurID = 1,
                    StijlID = 2,
                    Omschrijving = "Leuke jurk ",
                    AfbeeldingNaam1 ="jurk1.jpg",
                    AfbeeldingNaam2 ="jurk2.jpg",
                    AfbeeldingNaam3 ="jurk3.jpg",
                    AfbeeldingNaam4 ="jurk4.jpg",
                },
                new Jurk() {
                    ArtikelNr = 8,
                    CategorieID = 3,
                    MerkID = 2,
                    NeklijnID = 1,
                    SilhouetteID = 1,
                    Prijs= 1500,
                    KleurID = 1,
                    StijlID = 2,
                    Omschrijving = "Leuke jurk ",
                    AfbeeldingNaam1 ="jurk3.jpg",
                    AfbeeldingNaam2 ="jurk2.jpg",
                    AfbeeldingNaam3 ="jurk3.jpg",
                    AfbeeldingNaam4 ="jurk4.jpg",
                },
                new Jurk() {
                    ArtikelNr = 9,
                    CategorieID = 3,
                    MerkID = 2,
                    NeklijnID = 1,
                    SilhouetteID = 1,
                    Prijs= 1500,
                    KleurID = 1,
                    StijlID = 2,
                    Omschrijving = "Leuke jurk ",
                    AfbeeldingNaam1 ="jurk3.jpg",
                    AfbeeldingNaam2 ="jurk2.jpg",
                    AfbeeldingNaam3 ="jurk1.jpg",
                    AfbeeldingNaam4 ="jurk4.jpg",
                },
                new Jurk() {
                    ArtikelNr = 10,
                    CategorieID = 2,
                    MerkID = 2,
                    NeklijnID = 1,
                    SilhouetteID = 1,
                    Prijs= 1500,
                    KleurID = 1,
                    StijlID = 2,
                    Omschrijving = "Leuke jurk ",
                    AfbeeldingNaam1 ="jurk3.jpg",
                    AfbeeldingNaam2 ="jurk2.jpg",
                    AfbeeldingNaam3 ="jurk3.jpg",
                    AfbeeldingNaam4 ="jurk4.jpg",
                },
                new Jurk() {
                    ArtikelNr = 11,
                    CategorieID = 1,
                    MerkID = 2,
                    NeklijnID = 1,
                    SilhouetteID = 1,
                    Prijs= 1500,
                    KleurID = 1,
                    StijlID = 2,
                    Omschrijving = "Leuke jurk ",
                    AfbeeldingNaam1 ="jurk4.jpg",
                    AfbeeldingNaam2 ="jurk2.jpg",
                    AfbeeldingNaam3 ="jurk3.jpg",
                    AfbeeldingNaam4 ="jurk1.jpg",
                },
                new Jurk() {
                    ArtikelNr = 12,
                    CategorieID = 1,
                    MerkID = 2,
                    NeklijnID = 1,
                    SilhouetteID = 1,
                    Prijs= 1500,
                    KleurID = 1,
                    StijlID = 2,
                    Omschrijving = "Leuke jurk ",
                    AfbeeldingNaam1 ="jurk1.jpg",
                    AfbeeldingNaam2 ="jurk2.jpg",
                    AfbeeldingNaam3 ="jurk3.jpg",
                    AfbeeldingNaam4 ="jurk4.jpg",
                },
                new Jurk() {
                    ArtikelNr = 13,
                    CategorieID = 1,
                    MerkID = 2,
                    NeklijnID = 1,
                    SilhouetteID = 1,
                    Prijs= 1500,
                    KleurID = 1,
                    StijlID = 2,
                    Omschrijving = "Leuke jurk ",
                    AfbeeldingNaam1 ="jurk1.jpg",
                    AfbeeldingNaam2 ="jurk2.jpg",
                    AfbeeldingNaam3 ="jurk3.jpg",
                    AfbeeldingNaam4 ="jurk4.jpg",
                },
                new Jurk() {
                    ArtikelNr = 14,
                    CategorieID = 2,
                    MerkID = 2,
                    NeklijnID = 1,
                    SilhouetteID = 1,
                    Prijs= 1500,
                    KleurID = 1,
                    StijlID = 2,
                    Omschrijving = "Leuke jurk ",
                    AfbeeldingNaam1 ="jurk1.jpg",
                    AfbeeldingNaam2 ="jurk2.jpg",
                    AfbeeldingNaam3 ="jurk3.jpg",
                    AfbeeldingNaam4 ="jurk4.jpg",
                },
                new Jurk() {
                    ArtikelNr = 15,
                    CategorieID = 2,
                    MerkID = 2,
                    NeklijnID = 1,
                    SilhouetteID = 1,
                    Prijs= 1500,
                    KleurID = 1,
                    StijlID = 2,
                    Omschrijving = "Leuke jurk ",
                    AfbeeldingNaam1 ="jurk1.jpg",
                    AfbeeldingNaam2 ="jurk2.jpg",
                    AfbeeldingNaam3 ="jurk3.jpg",
                    AfbeeldingNaam4 ="jurk4.jpg",
                },
                new Jurk() {
                    ArtikelNr = 16,
                    CategorieID = 1,
                    MerkID = 2,
                    NeklijnID = 1,
                    SilhouetteID = 1,
                    Prijs= 1500,
                    KleurID = 1,
                    StijlID = 2,
                    Omschrijving = "Leuke jurk ",
                    AfbeeldingNaam1 ="jurk1.jpg",
                    AfbeeldingNaam2 ="jurk2.jpg",
                    AfbeeldingNaam3 ="jurk3.jpg",
                    AfbeeldingNaam4 ="jurk4.jpg",
                },
                new Jurk() {
                    ArtikelNr = 17,
                    CategorieID = 3,
                    MerkID = 2,
                    NeklijnID = 1,
                    SilhouetteID = 1,
                    Prijs= 1500,
                    KleurID = 1,
                    StijlID = 2,
                    Omschrijving = "Leuke jurk ",
                    AfbeeldingNaam1 ="jurk1.jpg",
                    AfbeeldingNaam2 ="jurk2.jpg",
                    AfbeeldingNaam3 ="jurk3.jpg",
                    AfbeeldingNaam4 ="jurk4.jpg",
                },
                new Jurk() {
                    ArtikelNr = 18,
                    CategorieID = 3,
                    MerkID = 2,
                    NeklijnID = 1,
                    SilhouetteID = 1,
                    Prijs= 1500,
                    KleurID = 1,
                    StijlID = 2,
                    Omschrijving = "Leuke jurk ",
                    AfbeeldingNaam1 ="jurk1.jpg",
                    AfbeeldingNaam2 ="jurk2.jpg",
                    AfbeeldingNaam3 ="jurk3.jpg",
                    AfbeeldingNaam4 ="jurk4.jpg",
                },
                new Jurk() {
                    ArtikelNr = 19,
                    CategorieID = 3,
                    MerkID = 2,
                    NeklijnID = 1,
                    SilhouetteID = 1,
                    Prijs= 1500,
                    KleurID = 1,
                    StijlID = 2,
                    Omschrijving = "Leuke jurk ",
                    AfbeeldingNaam1 ="jurk1.jpg",
                    AfbeeldingNaam2 ="jurk2.jpg",
                    AfbeeldingNaam3 ="jurk3.jpg",
                    AfbeeldingNaam4 ="jurk4.jpg",
                },
                new Jurk() {
                    ArtikelNr = 20,
                    CategorieID = 3,
                    MerkID = 2,
                    NeklijnID = 1,
                    SilhouetteID = 1,
                    Prijs= 1500,
                    KleurID = 1,
                    StijlID = 2,
                    Omschrijving = "Leuke jurk ",
                    AfbeeldingNaam1 ="jurk1.jpg",
                    AfbeeldingNaam2 ="jurk2.jpg",
                    AfbeeldingNaam3 ="jurk3.jpg",
                    AfbeeldingNaam4 ="jurk4.jpg",
                }
            };
            context.Jurken.AddRange(jurkenSeedList);
            context.SaveChanges();
        }
    }
}