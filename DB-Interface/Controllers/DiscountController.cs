﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Entities;
using DAL;

namespace DB_Interface.Controllers
{
    public class DiscountController : Controller
    {
        // GET: DiscountController
        public ActionResult Index()
        {
            var list = DiscountRepository.GetDiscounts();
            
            return View(list);
        }

        // GET: DiscountController/<id>
        public ActionResult Details(int id)
        {
            var list = DiscountRepository.GetClientsByDiscountId(id);

            return View(list);
        }

        // GET: DiscountController/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: DiscountController/Create
        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Create(DiscountView discountView)
        {
            int result = DiscountRepository.CreateDiscount(discountView);

            return RedirectToAction("Index");
        }

        // GET: DiscountController/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DiscountController/Edit/5
        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id, DiscountView discountView)
        {
            int result = DiscountRepository.EditDiscount(discountView);

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin")]
        public ActionResult WrongPage()
        {
            return View();
        }

        // POST: DiscountController/Delete/5
        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            int result = DiscountRepository.DeleteDiscount(id);

            if (result == 0)
            {
                return RedirectToAction("WrongPage");
            }

            return RedirectToAction("Index");
        }
    }
}
