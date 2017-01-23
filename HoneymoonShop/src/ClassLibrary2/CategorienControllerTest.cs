using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HoneymoonShop.Controllers;
using Moq;
using Xunit;
using HoneymoonShop.Data;
using Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace CategorienControllerTest
{
    public class CategorienControllerTest
    {
        [Fact]
        public void showAllCategoriesInCategorienController()
        {
            var mockDbContext = new Mock<ApplicationDbContext>();
            var mockDbSetCategorien = new Mock<DbSet<Categorie>>();

            var dummyData = new List<Categorie>() { new Categorie() { CategorieID = 1, CategorieNaam = "Summer Sales" } }.AsQueryable();


            mockDbSetCategorien.As<IQueryable<Categorie>>().Setup(m => m.Provider).Returns(dummyData.Provider);
            mockDbSetCategorien.As<IQueryable<Categorie>>().Setup(m => m.Expression).Returns(dummyData.Expression);
            mockDbSetCategorien.As<IQueryable<Categorie>>().Setup(m => m.ElementType).Returns(dummyData.ElementType);
            mockDbSetCategorien.As<IQueryable<Categorie>>().Setup(m => m.GetEnumerator()).Returns(dummyData.GetEnumerator());

            mockDbContext.Setup(x => x.Categorien).Returns(mockDbSetCategorien.Object);

            CategorienController c = new CategorienController(mockDbContext.Object);
            var result = c.Index();


            var viewResult = Assert.IsType<ViewResult>(result);

            var model = (List<Categorie>)viewResult.Model;

            Assert.Equal("Summer Sales", model.ElementAt(0).CategorieNaam);
        }

        [Fact]
        public void UpdateCategorieInCategorienController()
        {
            var mockDbContext = new Mock<ApplicationDbContext>();
            var mockDbSetCategorien = new Mock<DbSet<Categorie>>();

            var oldCategorie = new Categorie { CategorieID = 1, CategorieNaam = "Summer Sales" };

            var newCategorie = new Categorie { CategorieID = 1, CategorieNaam = "Winter Sales" };

            var queryable = new List<Categorie> { newCategorie }.AsQueryable();
            mockDbSetCategorien.As<IQueryable<Categorie>>().Setup(x => x.Provider).Returns(queryable.Provider);
            mockDbSetCategorien.As<IQueryable<Categorie>>().Setup(x => x.Expression).Returns(queryable.Expression);
            mockDbSetCategorien.As<IQueryable<Categorie>>().Setup(x => x.ElementType).Returns(queryable.ElementType);
            mockDbSetCategorien.As<IQueryable<Categorie>>().Setup(x => x.GetEnumerator()).Returns(queryable.GetEnumerator());


            mockDbSetCategorien.Setup(x => x.Update(newCategorie)).Verifiable();
            mockDbContext.Setup(x => x.SaveChanges()).Verifiable();

        }

        [Fact]
        public void DeleteCategorieInCategorienController()
        {
            var mockDbContext = new Mock<ApplicationDbContext>();
            var mockDbSetCategorien = new Mock<DbSet<Categorie>>();

            var categorie = new Categorie { CategorieID = 1, CategorieNaam = "Summer Sales" };

            var queryable = new List<Categorie> { categorie }.AsQueryable();
            mockDbSetCategorien.As<IQueryable<Categorie>>().Setup(x => x.Provider).Returns(queryable.Provider);
            mockDbSetCategorien.As<IQueryable<Categorie>>().Setup(x => x.Expression).Returns(queryable.Expression);
            mockDbSetCategorien.As<IQueryable<Categorie>>().Setup(x => x.ElementType).Returns(queryable.ElementType);
            mockDbSetCategorien.As<IQueryable<Categorie>>().Setup(x => x.GetEnumerator()).Returns(queryable.GetEnumerator());

            mockDbSetCategorien.Setup(x => x.Remove(categorie)).Verifiable();
            mockDbContext.Setup(x => x.SaveChanges()).Verifiable();


        }
    }
}
