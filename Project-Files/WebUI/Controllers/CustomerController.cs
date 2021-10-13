using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class CustomerController : Controller
    {

        private IBL _bl;
        public CustomerController(IBL bl)
        {
            _bl = bl;
        }

        //login
        [HttpGet]
        public ActionResult Login()
        {
            return View(new CustomerLoginModel());
        }

        [HttpPost]
        public ActionResult Login(CustomerLoginModel customerLogin)
        {
            var customer = _bl.GetCustomer(customerLogin.CustomerId);
            if (customer != null)
            {
                HttpContext.Session.SetInt32("UserId", customerLogin.CustomerId);
                
                return RedirectToAction("index");
            }else
            {
                ModelState.AddModelError("CustomerId", "No customer found with the customer id");
                return View();
            }
        }

        //Get
        [HttpPost]
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            //return Redirect("/");
            return RedirectToAction(nameof(HomeController.Index),"Home");
        }

        public ActionResult GetCustomer()
        {
            var customerId = HttpContext.Session.GetInt32("UserId");
            return View(new List<Customer> {_bl.GetCustomer(customerId.Value) });

        }



        // GET: CustomerController1
        public ActionResult Index()
        {
            var customerId = HttpContext.Session.GetInt32("UserId");
            if(customerId.HasValue == false)
            {
            return View(_bl.GetAllCustomers());

            }
            else
            {
                return RedirectToAction(nameof(GetCustomer));
            }
        }

        // GET: CustomerController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            try
            {
                _bl.AddCustomer(customer);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_bl.GetCustomer(id));
        }

        // POST: CustomerController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {
            try
            {
                _bl.EditCustomer(customer);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController1/Delete/5
        public ActionResult Delete(int id)
        {
            _bl.DeleteCustomer(id);
            return RedirectToAction("index");
        }

        // POST: CustomerController1/Delete/5
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
