using System;
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        public DbSet<Jurk> Jurk { get; set; }

        public DbSet<Merk> Merk { get; set; }

        public DbSet<Categorie> Categorie { get; set; }

        public DbSet<Stijl> Stijl { get; set; }

        public DbSet<Kleur> Kleur { get; set; }

        public DbSet<Neklijn> Neklijn { get; set; }

        public DbSet<Silhouette> Silhouette { get; set; }

        

        
    }
}
