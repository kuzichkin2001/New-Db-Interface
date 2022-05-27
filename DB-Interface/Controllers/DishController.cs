using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Entities;
using DAL;

namespace DB_Interface.Controllers
{
    public class DishController : Controller
    {
        // GET: DishController
        public ActionResult Index()
        {
            var list = DishRepository.GetDishes();

            return View(list);
        }

        // GET: DishController/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: DishController/Create
        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Create(DishView view)
        {
            int result = DishRepository.CreateDish(view);

            return RedirectToAction("Index");
        }

        // GET: DishController/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DishController/Edit/5
        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id, DishView view)
        {
            int result = DishRepository.EditDish(view);

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin")]
        public ActionResult WrongPage()
        {
            return View();
        }

        // POST: DishController/Delete/5
        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            int result = DishRepository.DeleteDish(id);

            if (result == 0)
            {
                return RedirectToAction("WrongPage");
            }

            return RedirectToAction("Index");
        }
    }
}
