using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HoneymoonShop.Models;
using Models;
using HoneymoonShop.Models.DressFinderModels;

namespace HoneymoonShop.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
           
        }

        public ApplicationDbContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<JurkKleur>()
                .HasKey(t => new { t.JurkID, t.KleurID });

            builder.Entity<JurkKleur>()
                .HasOne(pt => pt.Jurk)
                .WithMany(p => p.JurkKleuren)
                .HasForeignKey(pt => pt.JurkID);

            builder.Entity<JurkKleur>()
                .HasOne(pt => pt.Kleur)
                .WithMany(t => t.JurkKleuren)
                .HasForeignKey(pt => pt.KleurID);
        }
    
        public DbSet<Review> Reviews { get; set; }

        public DbSet<Jurk> Jurken { get; set; }

        public DbSet<Merk> Merken { get; set; }

        public virtual DbSet<Categorie> Categorien { get; set; }

        public DbSet<Stijl> Stijlen { get; set; }

        public DbSet<Kleur> Kleuren { get; set; }

        public DbSet<Neklijn> Neklijnen { get; set; }

        public DbSet<Silhouette> Silhouetten { get; set; }




    }
}
