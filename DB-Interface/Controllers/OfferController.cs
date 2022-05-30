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
            var offer = OfferRepository.GetOffer(id);

            return View(offer);
        }

        // POST: OfferController/Edit/5
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Edit(OfferView view)
        {
            OfferRepository.EditOffer(view);

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin")]
        public ActionResult WrongPage()
        {
            return View();
        }

        // POST: OfferController/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            OfferRepository.DeleteOffer(id);

            return RedirectToAction("Index");
        }
    }
}
