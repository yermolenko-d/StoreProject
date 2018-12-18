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
        public int pageSize = 4;

        public CakeController(ICakeRepository repository)
        {
            cakeRepository = repository;
        }

        public ViewResult List(int page = 1)
        {   

            return View(cakeRepository.Cakes
                   .OrderBy(c => c.Id)
                   .Skip((page - 1)*pageSize)
                   .Take(pageSize));
        }
        // GET: Cake
        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}