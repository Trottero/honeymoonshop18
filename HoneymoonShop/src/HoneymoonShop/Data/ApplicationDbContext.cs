﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HoneymoonShop.Models;
using Models;

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
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<Klant>().ToTable("Klanten2");
            builder.Entity<Afspraak>().ToTable("Afspraken2");
        }
        public DbSet<Review> Reviews { get; set; }

        public DbSet<Jurk> Jurken { get; set; }

        public DbSet<Merk> Merken { get; set; }

        public virtual DbSet<Categorie> Categorien { get; set; }

        public DbSet<Stijl> Stijlen { get; set; }

        public DbSet<Kleur> Kleuren { get; set; }

        public DbSet<Neklijn> Neklijnen { get; set; }

        public DbSet<Silhouette> Silhouetten { get; set; }

        public DbSet<Klant> Klanten2 { get; set; }
        public DbSet<Afspraak> Afpsraken2 { get; set; }




    }
}
