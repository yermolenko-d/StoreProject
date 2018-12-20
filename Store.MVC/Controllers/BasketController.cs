using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreLogic.Abstract;
using StoreLogic.Entities;

namespace Store.MVC.Controllers
{
    public class BasketController : Controller
    {
        private ICakeRepository repository;
        public BasketController(ICakeRepository repo)
        {
            repository = repo;
        }

        

        // GET: Basket
        public ActionResult Index()
        {
            return View();
        }
    }
}