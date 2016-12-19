using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using HoneymoonShop.Data;

namespace HoneymoonShop.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HoneymoonShop.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Models.Categorie", b =>
                {
                    b.Property<int>("CategorieID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategorieNaam")
                        .IsRequired();

                    b.HasKey("CategorieID");

                    b.ToTable("Categorien");
                });

            modelBuilder.Entity("Models.Jurk", b =>
                {
                    b.Property<int>("JurkID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AfbeeldingNaam1");

                    b.Property<string>("AfbeeldingNaam2");

                    b.Property<string>("AfbeeldingNaam3");

                    b.Property<string>("AfbeeldingNaam4");

                    b.Property<int>("ArtikelNr");

                    b.Property<int>("CategorieID");

                    b.Property<int>("KleurID");

                    b.Property<int>("MerkID");

                    b.Property<int>("NeklijnID");

                    b.Property<string>("Omschrijving")
                        .IsRequired();

                    b.Property<int>("Prijs");

                    b.Property<int>("SilhouetteID");

                    b.Property<int>("StijlID");

                    b.HasKey("JurkID");

                    b.HasIndex("CategorieID");

                    b.HasIndex("KleurID");

                    b.HasIndex("MerkID");

                    b.HasIndex("NeklijnID");

                    b.HasIndex("SilhouetteID");

                    b.HasIndex("StijlID");

                    b.ToTable("Jurken");
                });

            modelBuilder.Entity("Models.Kleur", b =>
                {
                    b.Property<int>("KleurID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("KleurNaam")
                        .IsRequired();

                    b.HasKey("KleurID");

                    b.ToTable("Kleuren");
                });

            modelBuilder.Entity("Models.Merk", b =>
                {
                    b.Property<int>("MerkID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("MerkNaam")
                        .IsRequired();

                    b.HasKey("MerkID");

                    b.ToTable("Merk");
                });

            modelBuilder.Entity("Models.Neklijn", b =>
                {
                    b.Property<int>("NeklijnID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("NeklijnNaam")
                        .IsRequired();

                    b.HasKey("NeklijnID");

                    b.ToTable("Neklijnen");
                });

            modelBuilder.Entity("Models.Silhouette", b =>
                {
                    b.Property<int>("SilhouetteID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("SilhouetteNaam")
                        .IsRequired();

                    b.HasKey("SilhouetteID");

                    b.ToTable("Silhouette");
                });

            modelBuilder.Entity("Models.Stijl", b =>
                {
                    b.Property<int>("StijlID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("StijlNaam")
                        .IsRequired();

                    b.HasKey("StijlID");

                    b.ToTable("Stijlen");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("HoneymoonShop.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("HoneymoonShop.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HoneymoonShop.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Models.Jurk", b =>
                {
                    b.HasOne("Models.Categorie", "Categorie")
                        .WithMany("Jurken")
                        .HasForeignKey("CategorieID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Models.Kleur", "Kleur")
                        .WithMany("Jurken")
                        .HasForeignKey("KleurID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Models.Merk", "Merk")
                        .WithMany("Jurken")
                        .HasForeignKey("MerkID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Models.Neklijn", "Neklijn")
                        .WithMany("Jurken")
                        .HasForeignKey("NeklijnID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Models.Silhouette", "Silhouette")
                        .WithMany("Jurken")
                        .HasForeignKey("SilhouetteID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Models.Stijl", "Stijl")
                        .WithMany("Jurken")
                        .HasForeignKey("StijlID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
