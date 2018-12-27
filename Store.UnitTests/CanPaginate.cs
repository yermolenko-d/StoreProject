using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using StoreLogic.Abstract;
using StoreLogic.Entities;
using Store.MVC.Controllers;
using Store.MVC.Models;

namespace Store.UnitTests
{
    [TestClass]
    public class CanPaginate
    {   
        [TestMethod]
        public void Can_Paginate()
        {   
            //Мокаем данные
            Mock<ICakeRepository> mock = new Mock<ICakeRepository>();
            mock.Setup(m => m.Cakes).Returns(new List<Cake>
            {
                new Cake{Id = 1, Name ="Cake1" },
                new Cake{Id = 2, Name ="Cake2" },
                new Cake{Id = 3, Name ="Cake3" },
                new Cake{Id = 4, Name ="Cake4" },
                new Cake{Id = 5, Name ="Cake5" },
            });
            CakeController controller = new CakeController(mock.Object);
            controller.pageSize = 3;

            //action
            CakeListView result = (CakeListView)controller.List(null,2).Model;
            
            //asserts
            List<Cake> cakes = result.Cakes.ToList();
            Assert.IsTrue(cakes.Count() == 2);
            Assert.AreEqual(cakes[0].Name, "Cake4");
            Assert.AreEqual(cakes[1].Name, "Cake5");

        }
    }
}
