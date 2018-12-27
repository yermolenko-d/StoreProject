using StoreLogic.Abstract;
using StoreLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.MVC.Models
{
    public class CakeListView
    {
        public IEnumerable<Cake> Cakes { get; set; }
        public PageInfo PagesInfo { get; set; }
        public string CurrentCategory { get; set; }

    }

}
