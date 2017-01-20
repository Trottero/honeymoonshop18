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

            //alle property van IQueryable correct toekennen
            mockDbSetCategorien.As<IQueryable<Categorie>>().Setup(m => m.Provider).Returns(dummyData.Provider);
            mockDbSetCategorien.As<IQueryable<Categorie>>().Setup(m => m.Expression).Returns(dummyData.Expression);
            mockDbSetCategorien.As<IQueryable<Categorie>>().Setup(m => m.ElementType).Returns(dummyData.ElementType);
            mockDbSetCategorien.As<IQueryable<Categorie>>().Setup(m => m.GetEnumerator()).Returns(dummyData.GetEnumerator());

            mockDbContext.Setup(x => x.Categorien).Returns(mockDbSetCategorien.Object);

            CategorienController c = new CategorienController(mockDbContext.Object);
            var result = c.Index();

            //result moet een view zijn
            var viewResult = Assert.IsType<ViewResult>(result);

            var model = (List<Categorie>)viewResult.Model;

            Assert.Equal("Summer Sales", model.ElementAt(0).CategorieNaam);
        }

        [Fact]
        public void CreateCategorieIfValidInCategorienController()
        {
            var mockDbContext = new Mock<ApplicationDbContext>();
            var mockDbSetCategorien = new Mock<DbSet<Categorie>>();

            Categorie c = new Categorie() { CategorieID = 1, CategorieNaam = "Summer Sales" };

            mockDbContext.Setup(x => x.Categorien).Returns(mockDbSetCategorien.Object);

            CategorienController s = new CategorienController(mockDbContext.Object);


            var newCategorie = new Categorie() { CategorieID = 2, CategorieNaam = "Winter Sales"};
            var result = s.Create(newCategorie);

            Assert.True(s.ModelState.IsValid);

            //mockDbSetCategorien.Verify(m => m.Add(It.Is<Categorie>()), Times.Once());
            mockDbContext.Verify(m => m.SaveChanges(), Times.Once());

        }
    }
}
