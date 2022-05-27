using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DB_Interface.Models;
using Entities;
using DAL;

namespace DB_Interface.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult GetContentsOfDish()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> GetContentsOfDish_List(int id)
    {
        var list = await DishContentsRepository.GetDishContentsById(id);

        return View(list);
    }

    [HttpPost]
    public IActionResult GetContentsOfDish(IFormCollection formCollection)
    {
        int content_id = int.Parse(formCollection["Id_Product"]);

        return RedirectToAction("GetContentsOfDish_List", new { id = content_id });
    }

    [HttpGet]
    public async Task<IActionResult> GetTotalCosts()
    {
        var list = await OfficiantCostsRepository.GetAll();

        return View(list);
    }

    [HttpGet]
    public IActionResult GetRestaurantMenu()
    {
        var list = RestaurantMenuRepository.GetMenu();

        return View(list);
    }

    [HttpGet]
    public IActionResult GetEmployeesList(string searchString)
    {
        var list = EmployeesRepository.GetEmployees();

        if (!String.IsNullOrEmpty(searchString))
        {
            list = list.Where(item => item.Name.ToLower().Contains(searchString.ToLower()));
        }

        return View(list);
    }

    [HttpPost]
    public IActionResult FilterEmployeesList(string searchString)
    {
        return RedirectToAction("GetEmployeeList", "Home", new { searchString = searchString });
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

