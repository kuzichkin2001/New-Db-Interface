using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DAL;
using Entities;

namespace DB_Interface.Controllers
{
    public class DishListController : Controller
    {
        public IActionResult Index()
        {
            var list = DishListRepository.GetDishLists();

            return View(list);
        }
    }
}
