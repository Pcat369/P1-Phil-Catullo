using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using StoreBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models;

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
            List<StoreVM> allStore = _bl.GetAllStores().Select(s => new StoreVM(s)).ToList();
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
        public ActionResult Create(StoreVM store)
        {
            try
            {
                //Data in this form is valid
                if(ModelState.IsValid)
                {
                    _bl.AddStore(store.ToModel());
                    return RedirectToAction(nameof(Index));
                }
                return View();
            }
            catch (Exception)
            {
                return View();
            }
        }

        // GET: StoreController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(new StoreVM(_bl.GetOneStore(id)));
        }

        // POST: StoreController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StoreVM store)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _bl.UpdateStore(store.ToModel());
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Edit));
            }
            catch
            {
                return RedirectToAction(nameof(Edit));
            }
        }

        // GET: StoreController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(new StoreVM(_bl.GetOneStore(id)));
        }

        // POST: StoreController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete([FromRoute(Name = "id")]int myIdName,bool delete)
        {
            if(delete == true)
            {
                try
                {
                    _bl.DeleteStore(myIdName);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }

           
        }
    }
}
