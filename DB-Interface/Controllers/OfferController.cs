using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Entities;
using DAL;

namespace DB_Interface.Controllers
{
    public class OfferController : Controller
    {
        // GET: OfferController
        public ActionResult Index()
        {
            var list = OfferRepository.GetOffers();

            return View(list);
        }

        // GET: OfferController/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: OfferController/Create
        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Create(OfferView view)
        {
            int result = OfferRepository.CreateOffer(view);

            return RedirectToAction("Index");
        }

        // GET: OfferController/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OfferController/Edit/5
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Edit(int id, OfferView view)
        {
            int result = OfferRepository.EditOffer(view);

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin")]
        public ActionResult WrongPage()
        {
            return View();
        }

        // POST: OfferController/Delete/5
        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            int result = OfferRepository.DeleteOffer(id);

            if (result == 0)
            {
                return RedirectToAction("WrongPage");
            }

            return RedirectToAction("Index");
        }
    }
}
