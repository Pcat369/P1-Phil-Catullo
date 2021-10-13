using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreBL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class CardController : Controller
    {

        private IBL _bl;
        public CardController(IBL bl)
        {
            _bl = bl;
        }

        [HttpPost]
        public ActionResult AddToCard(PlaceOrderViewModel placeOrder)
        {
            var customerId = HttpContext.Session.GetInt32("UserId");
            var cardId = _bl.GetCardForCustomer(customerId.Value, placeOrder.StoreID);
            if (cardId.HasValue == false)
            {
                cardId = _bl.CreateCard(customerId.Value, placeOrder.StoreID, placeOrder.Inventories.First().ProductId);
            }

            foreach (var item in placeOrder.Inventories)
            {
                _bl.AddItemToCard(item.ProductId, cardId.Value);
                _bl.UpdateQuantity(item.ProductId, cardId.Value, item.SaleQuantity);
            }

            return RedirectToAction(nameof(Details),new { id = placeOrder.StoreID });
        }


        // GET: CardController
        public ActionResult Index()
        {
            var customerId = HttpContext.Session.GetInt32("UserId");

            var cards = _bl.GetCustomerCards(customerId.Value);

            return View(cards);
        }

        // GET: CardController/Details/5
        public ActionResult Details([FromRoute(Name ="id")]int storeId)
        {
            var customerId = HttpContext.Session.GetInt32("UserId");

            var card = _bl.GetCardByCustomer(customerId.Value, storeId);

            return View(card);
        }

        //// GET: CardController1/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: CardController1/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: CardController1/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: CardController1/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: CardController1/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: CardController1/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
