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
    public class InventoryController : Controller
    {

        private IBL _bl;
        public InventoryController(IBL bl)
        {
            _bl = bl;
        }

        // GET: InventoryController
        public ActionResult Index(int id)
        {
            var store = new StoreVM(_bl.GetOneStore(id));
            TempData["storeId"] = id;
            var storeDTO = new PlaceOrderViewModel()
            {
                Address = store.Address,
                City = store.City,
                StoreID = store.StoreID,
                StoreName = store.StoreName,
                Inventories = new List<InventoryViewModel>()
            };
            foreach (var item in store.Inventories)
            {
                storeDTO.Inventories.Add(new InventoryViewModel()
                {
                    InventoryId = item.InventoryId,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    SaleQuantity = 0,
                    Product = new Product() { Description = item.Product.Description, Name = item.Product.Name, Price = item.Product.Price,
                    Manufacturer = item.Product.Manufacturer}
                });
            }
            return View(storeDTO);
        }

        // GET: InventoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InventoryController/Create
        public ActionResult Create(int StoreID)
        {
            var model = new Inventory
            {
                StoreId = StoreID,
            };

            return View(model);
        }

        // POST: InventoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Inventory inventory, int StoreID)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _bl.AddInventory(inventory);
                    return RedirectToAction(nameof(Index), new { id = StoreID });
                }
                return View(inventory);
            }
            catch
            {
                return View(inventory);
            }
        }

        // GET: InventoryController/Edit/5
        public ActionResult Edit(int id)
        {
            var inventory = _bl.GetInventoryByProductID(id);
            return View(inventory);
        }

        [HttpPost]
        public ActionResult Edit(Inventory inventory)
        {
            _bl.EditInventoryAmount(inventory);
            return RedirectToAction(nameof(Index), new { id = TempData["storeId"] });
        }

        // POST: InventoryController/Edit/5
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

        // GET: InventoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_bl.GetInventory(id));
        }

        // POST: InventoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            ActionResult res = null;
            Inventory item = _bl.GetInventory(id);
            int StoreID = item.StoreId;
            try
            {
                _bl.DeleteInventory(id);
            }
            catch(Exception ex)
            {
                //record exception
            }
            finally
            {
                res = RedirectToAction(nameof(Index), new { id = StoreID });
            }
            return res;
        }
    }
}
