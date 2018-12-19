using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StoreLogic.Abstract;

namespace Store.MVC.Controllers
{
    public class NavigationController : Controller
    {
        private ICakeRepository cakeRepository;

        public NavigationController (ICakeRepository cakeRepo)
        {
            cakeRepository = cakeRepo;
        }

        public PartialViewResult Menu()
        {
            IEnumerable<string> categories = cakeRepository.Cakes
                .Select(cake => cake.Category)
                .Distinct()
                .OrderBy(x => x);
            return PartialView(categories);
        }

        // GET: Navigation
        //public string Index()
        //{
        //    return "TESTING";
        //}
    }
}