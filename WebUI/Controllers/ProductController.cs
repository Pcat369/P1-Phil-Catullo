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
    public class ProductController : Controller
    {

        private IBL _bl;
        public ProductController(IBL bl)
        {
            _bl = bl;
        }
        // GET: ProductController1
        public ActionResult Index()
        {
            var model = _bl.GetProducts();
            return View(model);
        }

        // GET: ProductController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController1/Create
        public ActionResult Create(int? copyFrom = null, string returnUrl = null)
        {
            var model = new Product();

            if (copyFrom.HasValue == true)
            {
               var tempalte = _bl.GetProduct(copyFrom.Value);

                model.Name = "Copy of " + tempalte.Name;
                model.Description = tempalte.Description;
            }

            ViewBag.ReturnUrl = returnUrl;

            return View(model);
        }

        // POST: ProductController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product, string returnUrl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _bl.AddProduct(product);
                    if (string.IsNullOrEmpty(returnUrl) == false)
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController1/Edit/5
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

        // GET: ProductController1/Delete/5
        public ActionResult Delete(int id)
        {
            _bl.DeleteProduct(id);
            return RedirectToAction("index");
        }

        // POST: ProductController1/Delete/5
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
