using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using StoreBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    public class StoreController : Controller
    {
        private IBL _bl;
        public StoreController(IBL bl)
        {
            _bl = bl;
        }

        // GET: StoreController
        public ActionResult Index()
        {
            List<Store> allStore = _bl.GetAllStores();
            return View(allStore);
        }

        //// GET: StoreController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: StoreController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StoreController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Store store)
        {
            try
            {
                //Data in this form is valid
                if(ModelState.IsValid)
                {
                    _bl.AddStore(store);
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: StoreController/Edit/5
        public ActionResult Edit(int id)
        {
            _bl.GetOneStore(id);
            return View();
        }

        // POST: StoreController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StoreController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StoreController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
