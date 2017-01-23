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
                //clearAll(context); //Verwijder alle entries in database
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                //Seed merken
                IList<string> merkenSeedList = new List<string>() { "Ladybird", "Diane Legrand", "Pronovias", "Maggie Sottero", "Badgley & Mischka",
                    "Eddy K.", "Blue by Enzoani", "Modeca" };
                SeedMerken(context, merkenSeedList);

                //Seed Categorien
                IList<string> catoegorienSeedList = new List<string>() { "Summer SALE", "Nieuwe Collectie", "Winter SALE"};
                SeedCategorien(context, catoegorienSeedList);

                //Seed Stijlen
                IList<string> stijlenSeedList = new List<string>() { "Kant", "Klassieke Bruid", "Princes Bruid", "Ruches Rok", "Modieuze Bruid" };
                SeedStijlen(context, stijlenSeedList);

                //Seed neklijnen
                IList<string> neklijnenSeedList = new List<string>() { "Schouderbandjes", "Neklijn2" };
                SeedNeklijnen(context, neklijnenSeedList);

                //Seed silhouettes
                IList<string> silhouetteSeedList = new List<string>() { "Lage Rug", "Fishtail" };
                SeedSilhouetten(context, silhouetteSeedList);

                //Seed kleuren
                IList<String> kleurenSeedList = new List<string>() { "Ivoor/Wit", "Ivoor met kleur", "Gekleurd" };
                SeedKleuren(context, kleurenSeedList);

                context.SaveChanges();

                //Seed jurken
                SeedJurken(context, 100);
               
            }
        }

        private static void clearAll(ApplicationDbContext context)
        {
            context.Database.ExecuteSqlCommand("delete from Jurken");
            context.Database.ExecuteSqlCommand("delete from Merken");
            context.Database.ExecuteSqlCommand("delete from Kleuren");
            context.Database.ExecuteSqlCommand("delete from Neklijnen");
            context.Database.ExecuteSqlCommand("delete from Silhouetten");
            context.Database.ExecuteSqlCommand("delete from Stijlen");
            context.Database.ExecuteSqlCommand("delete from Categorien");

        }

        private static void SeedMerken(ApplicationDbContext context, IList<string> merkenSeedList)
        {
            if (context.Merken.Any())
            {
                return;
            }
            
            foreach(string merk in merkenSeedList)
            {
                context.Merken.Add(new Merk() { MerkNaam = merk } );
            }
        }

        private static void SeedCategorien(ApplicationDbContext context, IList<string> catoegorienSeedList)
        {
            if (context.Categorien.Any())
            {
                return;
            }
            
            foreach (string categorie in catoegorienSeedList)
            {
                context.Categorien.Add(new Categorie() { CategorieNaam = categorie });
            }
        }

        private static void SeedKleuren(ApplicationDbContext context, IList<string> kleurenSeedList)
        {
            if (context.Kleuren.Any())
            {
                return;
            }
            
            foreach (string kleur in kleurenSeedList)
            {
                context.Kleuren.Add(new Kleur() { KleurNaam = kleur });
            }
        }

        private static void SeedStijlen(ApplicationDbContext context, IList<string> stijlenSeedList)
        {
            if (context.Stijlen.Any())
            {
                return;
            }
            
            foreach (string stijl in stijlenSeedList)
            {
                context.Stijlen.Add(new Stijl() { StijlNaam = stijl });
            }
        }

        private static void SeedNeklijnen(ApplicationDbContext context, IList<string> neklijnenSeedList)
        {
            if (context.Neklijnen.Any())
            {
                return;
            }
            
            foreach (string neklijn in neklijnenSeedList)
            {
                context.Neklijnen.Add(new Neklijn() { NeklijnNaam = neklijn });
            }
        }

        private static void SeedSilhouetten(ApplicationDbContext context, IList<string> silhouetteSeedList)
        {
            if (context.Silhouetten.Any())
            {
                return;
            }
            
            foreach (string silhouette in silhouetteSeedList)
            {
                context.Silhouetten.Add(new Silhouette() { SilhouetteNaam = silhouette });
            }
        }

        private static void SeedJurken(ApplicationDbContext context, int jurkAantal)
        {
            if(context.Jurken.Any())
            {
                return;
            }

            //List containing all FK variables from Jurk
            var categorien = context.Categorien.ToList();
            var kleuren = context.Kleuren.ToList();
            var neklijnen = context.Neklijnen.ToList();
            var merken = context.Merken.ToList();
            var silhouetten = context.Silhouetten.ToList();
            var stijlen = context.Stijlen.ToList();

            var jurken = new List<string>() { "jurk1.jpg", "jurk2.jpg", "jurk3.jpg", "jurk4.jpg", "jurk5.jpg", "jurk6.jpg",
                "jurk7.jpg", "jurk8.jpg", "jurk9.jpg", "jurk10.jpg", "jurk11.jpg" };
            var omschrijvingen = new List<string>() {
                "Trouwjurk van het merk Ladybird gemaakt van kant. De top is strapless met een sweetheart lijn. De rok heeft een A-lijn met een sleep.",
                "Trouwjurk van het merk Ladybird gemaakt van kant. De top heeft een v-hals met schouderbanden en een laag uitgesneden rug, welke doorloopt tot de voorzijde en afgewerkt wordt met kanten applicaties. De rok heeft een fishtail model met een sleep.",
                "Trouwjurk van Ronald Joyce model Paphos, Glamour japon uitgevoerd in ivoor kleurig organza met rijke bewerking. De volle rok van organza heeft een lange sleep en is onbewerkt. De strapless sweetheart top is volledig bewerkt met steentjes pareltjes en lovertjes. De jurk sluit met een rijgsluiting." };

            var rand = new Random();
            for (int i=0; i<jurkAantal; i++)
            {

                Jurk jurk = new Jurk()
                {
                    //For each property get a random existing value
                    ArtikelNr = i +1,
                    Categorie = categorien[rand.Next(categorien.Count)],
                    Kleur = kleuren[rand.Next(kleuren.Count)],
                    Neklijn = neklijnen[rand.Next(neklijnen.Count)],
                    Merk = merken[rand.Next(merken.Count)],
                    Silhouette = silhouetten[rand.Next(silhouetten.Count)],
                    Stijl = stijlen[rand.Next(stijlen.Count)],
                    Prijs = rand.Next(10000),
                    AfbeeldingNaam1 = jurken[rand.Next(jurken.Count)],
                    AfbeeldingNaam2 = jurken[rand.Next(jurken.Count)],
                    AfbeeldingNaam3 = jurken[rand.Next(jurken.Count)],
                    AfbeeldingNaam4 = jurken[rand.Next(jurken.Count)],
                    Omschrijving = omschrijvingen[rand.Next(omschrijvingen.Count)]
                };
                context.Jurken.Add(jurk);
                context.SaveChanges();
            }
        }
    }
}