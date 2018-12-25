using StoreLogic.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.MVC.Controllers
{
    public class AdminController : Controller
    {

        private ICakeRepository cakeRepository;

        public AdminController(ICakeRepository repository)
        {
            cakeRepository = repository;
        }

        // GET: Admin
        public ViewResult Index()
        {
            return View(cakeRepository.Cakes);
        }
    }
}