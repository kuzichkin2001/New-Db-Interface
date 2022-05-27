using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Entities;
using DAL;

namespace DB_Interface.Controllers
{
    public class ClientController : Controller
    {
        // GET: ClientController
        public ActionResult Index()
        {
            var list = ClientRepository.GetClients();

            return View(list);
        }

        // GET: ClientController/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientController/Create
        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Create(ClientView view)
        {
            int result = ClientRepository.CreateClient(view);

            return RedirectToAction("Index");
        }

        // GET: ClientController/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClientController/Edit/5
        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id, ClientView view)
        {
            int result = ClientRepository.EditClient(view);

            return RedirectToAction("Index");
        }

        public ActionResult WrongPage()
        {
            return View();
        }

        // POST: ClientController/Delete/5
        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            int result = ClientRepository.DeleteClient(id);

            if (result == 0)
            {
                return RedirectToAction("WrongPage");
            }

            return RedirectToAction("Index");
        }
    }
}
