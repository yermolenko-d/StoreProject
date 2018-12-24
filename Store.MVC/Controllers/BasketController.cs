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

        public ViewResult Index(string urlReturn)
        {
            return View(new BasketIndexView
            {
                Basket = GetBasket(),
                UrlReturn = urlReturn
            });

        }

        public RedirectToRouteResult AddToBasket(int id, string urlReturn)
        {
            Cake cake = repository.Cakes
                .FirstOrDefault(c => c.Id == id);

            if (cake != null)
            {
                GetBasket().Add(cake, 1);
            }

            return RedirectToAction("Index", new { urlReturn });
        }

        public RedirectToRouteResult RemoveFromBasket(int id, string urlReturn)
        {
            Cake cake = repository.Cakes
                .FirstOrDefault(c => c.Id == id);

            if (cake != null)
            {
                GetBasket().RemoveLine(cake);
            }

            return RedirectToAction("Index", new { urlReturn });
        }


        public Basket GetBasket()
        {
            Basket basket = (Basket)Session["Basket"];
            if (basket == null)
            {
                basket = new Basket();
                Session["Basket"] = basket;
            }
            return basket;

        }


        // GET: Basket
        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}