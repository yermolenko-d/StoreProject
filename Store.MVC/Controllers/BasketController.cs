using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store.MVC.Models;
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

        public ViewResult Index(Basket basket,string urlReturn)
        {
            return View(new BasketIndexView
            {
                Basket = basket,
                UrlReturn = urlReturn
            });

        }

        public RedirectToRouteResult AddToBasket(Basket basket, int id, string urlReturn)
        {
            Cake cake = repository.Cakes
                .FirstOrDefault(c => c.Id == id);

            if (cake != null)
            {
                basket.Add(cake, 1);
            }

            return RedirectToAction("Index", new { urlReturn });
        }

        public RedirectToRouteResult RemoveFromBasket(Basket basket,int id, string urlReturn)
        {
            Cake cake = repository.Cakes
                .FirstOrDefault(c => c.Id == id);

            if (cake != null)
            {
                basket.RemoveLine(cake);
            }

            return RedirectToAction("Index", new { urlReturn });
        }
        // GET: Basket
        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}