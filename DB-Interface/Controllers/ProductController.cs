using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Entities;
using DAL;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DB_Interface.Controllers
{
    public class ProductController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            var products = ProductRepository.GetProducts();
            return View(products);
        }

        // GET: /<controller>/Create
        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /<controller>/Create
        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Create(ProductView productView)
        {
            int result = ProductRepository.CreateProduct(productView);

            var temp = result;

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Edit(int id)
        {
            var product = ProductRepository.GetProduct(id);

            return View(product);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Edit(ProductView view)
        {
            ProductRepository.EditProduct(view);

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            ProductRepository.DeleteProduct(id);

            return RedirectToAction("Index");
        }
    }
}

