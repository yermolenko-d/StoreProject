using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Store.MVC.Models;
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
            CakeListView model = new CakeListView
            {
                Cakes = cakeRepository.Cakes
                   .OrderBy(c => c.Id)
                   .Skip((page - 1) * pageSize)
                   .Take(pageSize),
                PagesInfo = new PageInfo
                {
                CurrentPage = page,
                ItemsPerPage = 4,
                TotalItems = cakeRepository.Cakes.Count()
                }
            };
            return View(model);
        }           
    }
        // GET: Cake
        //public ActionResult Index()
        //{
        //    return View();
        //}
}