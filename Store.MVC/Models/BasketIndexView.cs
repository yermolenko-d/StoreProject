using StoreLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.MVC.Models
{
    public class BasketIndexView
    {
        public Basket  Basket { get; set; }
        public string UrlReturn { get; set; }
    }
}