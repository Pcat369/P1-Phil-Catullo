using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class OrderController : Controller
    {
        private IBL _bl;
        public OrderController(IBL bl)
        {
            _bl = bl;
        }

        // GET: OrderController
        public ActionResult Index()
        {
            var customerId = HttpContext.Session.GetInt32("UserId");
            if (customerId.HasValue == false)
            {
                return new BadRequestResult();
            }

            var orders = _bl.GetOrderByCustomer(customerId.Value);

            return View(orders);
        }

        [HttpPost]
        public ActionResult Add(PlaceOrderViewModel placeOrder)
        {
            var customerId = HttpContext.Session.GetInt32("UserId");
            HttpContext.Session.SetString("cart", JsonSerializer.Serialize(placeOrder));
            if (customerId.HasValue == false)
            {
                return new BadRequestResult();
            }

            //int? orderId = _bl.GetOpenOrderId(customerId.Value);
            //if(orderId.HasValue == false)
            //{
            //    orderId = _bl.CreateOrder(customerId.Value, storeId, productId);
            //}
            //else
            //{
            //    _bl.AddProductOrder(productId, orderId.Value);
            //}
            return RedirectToAction("ViewCart");
            // return RedirectToAction(nameof(Details),new { id = orderId.Value });
        }

        public IActionResult ViewCart()
        {
            var cart = HttpContext.Session.GetString("cart");
            if (!string.IsNullOrEmpty(cart))
            {
                var cartObject = JsonSerializer.Deserialize<PlaceOrderViewModel>(cart);
                return View(cartObject);
            }
            else
            {
                return RedirectToAction("index");
            }
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            var customerId = HttpContext.Session.GetInt32("UserId");
            if (customerId.HasValue == false)
            {
                return new BadRequestResult();
            }

            var orders = _bl.GetOrderByCustomer(customerId.Value);
            var order = orders.Where(x => x.OrderID == id).FirstOrDefault();
            return View(order);
        }

        //Add Card Controller


        // GET: OrderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int id)
        {
            var customerId = HttpContext.Session.GetInt32("UserId");
            var card = _bl.GetCardByCustomer(customerId.Value, id);

            var orderId = _bl.PlaceOrder(card.Id);

            return RedirectToAction(nameof(Details), new { id = orderId });
        }

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderController/Edit/5
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

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderController/Delete/5
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

        public ActionResult ListAllOrders([FromQuery]int customerId)
        {
            try
            {
                return View(_bl.GetOrderByCustomer(customerId));
            }
            catch
            {
                return View();
            }
        }
    }
}
