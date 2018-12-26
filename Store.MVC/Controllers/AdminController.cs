using StoreLogic.Abstract;
using StoreLogic.Entities;
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

        public ViewResult Edit(int Id)
        {
            Cake cake = cakeRepository.Cakes
                .FirstOrDefault(c => c.Id == Id);

            return View(cake);
        }

        //POST method для изменения данных
        [HttpPost]
        public ActionResult Edit(Cake cake)
        {
            if (ModelState.IsValid)
            {
                cakeRepository.SaveChange(cake);
                //TempData - насколько я понял - это что-то вроде ViewBag, только данные удаляются в конце запроса
                //ViewBag мы использовать не можем, тк юзаем RedirectToAction, соответственно - данные удалятся
                //в процессе перенаправления.
                TempData["Message"] = $"Изменения в продукте {cake.Name} успешно сохранены";
                return RedirectToAction("Index");
            }
            else
            {
                //If something wrong with data values
                return View(cake);
            }
        }
    }
}