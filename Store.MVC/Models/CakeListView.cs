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

    //public class CakeListLogic
    //{
    //    private ICakeRepository cakeRepository { get; set; }
    //    public int pageSize = 4;


    //    public CakeListView Logic(CakeListView model, int pageSize, string category)
    //    {
    //        CakeListView model = new CakeListView
    //        {
    //            Cakes = cakeRepository.Cakes
    //                    .Where(c => category == null || c.Category == category)
    //                    .OrderBy(cake => cake.Id)
    //                    .Skip((page - 1) * pageSize)
    //                    .Take(pageSize),
    //            PagesInfo = new PageInfo
    //            {
    //                CurrentPage = page,
    //                ItemsPerPage = pageSize,
    //                TotalItems = category == null ? //???
    //             cakeRepository.Cakes.Count() :
    //             cakeRepository.Cakes.Where(cake => cake.Category == category)
    //                                 .Count()
    //            },
    //            CurrentCategory = category
    //        };
    //    };



    }
