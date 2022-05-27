using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DAL;
using Entities;

namespace DB_Interface.Controllers
{
    public class KitchenController : Controller
    {
        // GET: KitchenController
        public IActionResult Index()
        {
            var list = KitchenRepository.GetKitchens();

            return View(list);
        }

        public IActionResult Details(int id)
        {
            var list = KitchenRepository.GetDishesByKitchenId(id);

            return View(list);
        }

        // GET: KitchenController/Create
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: KitchenController/Create
        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Create(KitchenView kitchenView)
        {
            int result = KitchenRepository.CreateKitchen(kitchenView);

            return RedirectToAction("Index");
        }

        // GET: KitchenController/Edit/5
        [Authorize(Roles = "admin")]
        public IActionResult Edit(int id)
        {
            return View();
        }

        // POST: KitchenController/Edit/5
        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Edit(int id, KitchenView kitchenView)
        {
            int result = KitchenRepository.EditKitchen(kitchenView);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult WrongPage()
        {
            return View();
        }

        // POST: KitchenController/Delete/5
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            if (KitchenRepository.DeleteKitchen(id) == 0)
            {
                return RedirectToAction("WrongPage");
            }
            
            return RedirectToAction("Index");
        }
    }
}
