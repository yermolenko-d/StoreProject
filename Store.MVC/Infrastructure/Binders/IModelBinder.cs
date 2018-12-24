using StoreLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Store.MVC.Infrastructure.Binders
{
    public interface IModelBinder
    {
        object BindModel(ControllerContext controllerContext,
                    ModelBindingContext modelBindingContext);
    }

    public class ModelBinder : IModelBinder
    {
        private const string sessionKey = "Basket";

        public object BindModel(
                    ControllerContext controllerContext,
                    ModelBindingContext modelBindingContext)
        {
            //Получаем объект Basket из сеанса
            Basket basket = null;
            if (controllerContext.HttpContext.Session != null)
            {
                basket = (Basket)controllerContext.HttpContext.Session[sessionKey];
            }
            //Если нет объекта Basket в сессии - получить новый
            if (basket == null)
            {
                basket = new Basket();
                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[sessionKey] = basket;
                }
            }

            return basket;
        }



    }
}