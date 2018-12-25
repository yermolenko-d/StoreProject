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
        private IOrderProcessor orderProcessor;

        public BasketController(ICakeRepository repo, IOrderProcessor processor)
        {
            repository = repo;
            orderProcessor = processor;
        }

        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }


        [HttpPost]
        public ViewResult Checkout(Basket basket, ShippingDetails shippingDetails)
        {
            if (basket.Show.Count() == 0)
            {
                ModelState.AddModelError("", "Извините, корзина пуста.");
            }
            if (ModelState.IsValid)
            {
                orderProcessor.ProcessOrder(basket, shippingDetails);
                basket.Clear();
                return View("Complete");
            }
            else
            {
                return View(shippingDetails);
            }
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

        public PartialViewResult Summary(Basket basket)
        {
            return PartialView(basket);
        }
        // GET: Basket
        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}