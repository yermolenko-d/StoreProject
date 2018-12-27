using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Store.MVC.Controllers;
using Store.MVC.Models;
using StoreLogic.Abstract;
using StoreLogic.Entities;

namespace Store.UnitTests
{   
    
    //Тест разбиения на категории

    [TestClass]
    public class CategoryFilter
    {
        public List<Cake> CakListView { get; private set; }

        [TestMethod]
        public void Category_filter()
        {
            Mock<ICakeRepository> mock = new Mock<ICakeRepository>();
            mock.Setup(m => m.Cakes).Returns(new List<Cake>
            {
                new Cake{Id = 1, Category="Category1" ,Name ="Cake1" },
                new Cake{Id = 2, Category="Category2", Name ="Cake2" },
                new Cake{Id = 3, Category="Category2", Name ="Cake3" },
                new Cake{Id = 4, Category="Category3", Name ="Cake4" },
                new Cake{Id = 5, Category="Category1" ,Name ="Cake5" },
            });
            CakeController controller = new CakeController(mock.Object);
            controller.pageSize = 3;

            //Action
            List<Cake> result = ((CakeListView)controller.List("Category1", 1).Model)
            .Cakes.ToList();

            Assert.AreEqual(result.Count(), 2);
            Assert.IsTrue(result[0].Category == "Category1" && result[0].Name == "Cake1");
            Assert.IsTrue(result[1].Category == "Category1" && result[1].Name == "Cake5");
        }
    }
}
