using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Entities;
using DAL;

namespace DB_Interface.Controllers
{
    public class ProductListController : Controller
    {
        public IActionResult Index()
        {
            var list = ProductListRepository.GetProductLists();

            return View(list);
        }
    }
}
