using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreLogic.Abstract;
using StoreLogic.Entities;

namespace Store.MVC.Controllers
{
    public class CakeController : Controller
    {
        private ICakeRepository cakeRepository;

        public CakeController(ICakeRepository repository)
        {
            cakeRepository = repository;
        }

        public ViewResult List()
        {
            return View(cakeRepository.Cakes);
        }
        // GET: Cake
        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}