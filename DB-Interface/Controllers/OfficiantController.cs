using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Entities;
using DAL;

namespace DB_Interface.Controllers
{
    public class OfficiantController : Controller
    {
        // GET: OfficiantController
        public ActionResult Index()
        {
            var list = OfficiantRepository.GetOfficiants();

            return View(list);
        }

        // GET: OfficiantController/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: OfficiantController/Create
        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Create(OfficiantView officiantView)
        {
            int result = OfficiantRepository.CreateOfficiant(officiantView);

            return RedirectToAction("Index");
        }

        // GET: OfficiantController/Edit/5
        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            var officiant = OfficiantRepository.GetOfficiant(id);

            return View(officiant);
        }

        // POST: OfficiantController/Edit/5
        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(OfficiantView view)
        {
            OfficiantRepository.EditOfficiant(view);

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult WrongPage()
        {
            return View();
        }

        // POST: OfficiantController/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            OfficiantRepository.DeleteOfficiant(id);

            return RedirectToAction("Index");
        }
    }
}
