using System;
using System.Collections.Generic;
using Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
//using Entity = DL.Entities;

namespace DL
{
    public class DBRepo : IRepo
    {

        //DB Context.
        private StoreDBContext _context;

        public DBRepo(StoreDBContext context)
        {
            _context = context;
        }


        //CUSTOMER METHODS
        //CUSTOMER METHODS
        //CUSTOMER METHODS

        public Customer GetCustomer(int id)
        {
            return _context.Customers.FirstOrDefault(c => c.CustomerID == id);
        }

        public List<Customer> GetAllCustomers()
        {
            //Similar to * in SQL.
            //Select() always takes an argument.
            //Gets Entites.Store and we convert it to Model.Store
            return _context.Customers.ToList();
        }

        public void DeleteCustomer(int customerId)
        {
            _context.Customers.Remove(GetCustomer(customerId));
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }

        public Customer AddCustomer(Customer newCustomer)
        {
            Customer customerAdd = new Customer()
            {
                Name = newCustomer.Name,
                Address = newCustomer.Address,
                City = newCustomer.City,
                Age = newCustomer.Age

            };

            customerAdd = _context.Add(customerAdd).Entity;

            _context.SaveChanges();

            _context.ChangeTracker.Clear();

            return new Customer()
            {
                CustomerID = customerAdd.CustomerID,
                Name = customerAdd.Name,
                Address = customerAdd.Name,
                City = customerAdd.City,
                Age = customerAdd.Age
            };

        }

        public Customer EditCustomer(Customer customerInfo)
        {
            Customer updateCustomer = new Customer()
            {
                CustomerID = customerInfo.CustomerID,
                Name = customerInfo.Name,
                Address = customerInfo.Address,
                City = customerInfo.City
            };

            updateCustomer = _context.Customers.Update(updateCustomer).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Customer()
            {
                CustomerID = updateCustomer.CustomerID,
                Name = updateCustomer.Name,
                Address = updateCustomer.Address,
                City = updateCustomer.City
            };
        }

        public List<Customer> SearchCustomer(string queryStr)
        {
            return _context.Customers.Where(
                customer => customer.Name.Contains(queryStr) || customer.City.Contains(queryStr) || customer.Address.Contains(queryStr)
            ).Select(
                c => new Customer()
                {
                    CustomerID = c.CustomerID,
                    Name = c.Name,
                    City = c.City,
                    Address = c.Address,
                    Age = c.Age
                }
            ).ToList();
        }

        public void RemoveCustomer(int id)
        {
            _context.Customers.Remove(GetCustomer(id));
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }


        //Contains DBContext.
        //These methods will get data from the db and persist to db.


        //STORE METHODS
        //STORE METHODS
        //STORE METHODS

        public List<Store> GetAllStores()
        {
            //Similar to * in SQL.
            //Select() always takes an argument.
            //Gets Entites.Store and we convert it to Model.Store
            return _context.Stores.Select(
                    store => new Store()
                    {
                        StoreID = store.StoreID,
                        StoreName = store.StoreName,
                        Address = store.Address,
                        City = store.City,

                    }
            ).ToList();
        }

        public Store AddStore(Store store)
        {
            store = _context.Add(store).Entity;

            _context.SaveChanges();

            _context.ChangeTracker.Clear();

            return store;
        }

        public List<Store> SearchStores(string queryStr)
        {
            return _context.Stores.Where(
                store => store.StoreName.Contains(queryStr) || store.City.Contains(queryStr) || store.Address.Contains(queryStr)
            ).Select(
                s => new Store()
                {
                    StoreID = s.StoreID,
                    StoreName = s.StoreName,
                    City = s.City,
                    Address = s.Address
                }
            ).ToList();
        }

        public Store GetOneStore(int id)
        {
            var test = _context.Stores.AsNoTracking().Include(i => i.Inventories).ThenInclude(x => x.Product).FirstOrDefault(s => s.StoreID == id);
            return _context.Stores.AsNoTracking().Include(i => i.Inventories).ThenInclude(x => x.Product).FirstOrDefault(s => s.StoreID == id);
            //Store storeById = _context.Stores.Include(s => s.Inventories).FirstOrDefault(s => s.StoreID == id);

            //return new Store(){
            //    StoreID  = storeById.StoreID,
            //    StoreName = storeById.StoreName,
            //    Address = storeById.Address,
            //    City = storeById.City
            //};
        }

        public Store UpdateStore(Store storeToUpdate)
        {
            Store updateStore = new Store()
            {
                StoreID = storeToUpdate.StoreID,
                StoreName = storeToUpdate.StoreName,
                Address = storeToUpdate.Address,
                City = storeToUpdate.City
            };

            updateStore = _context.Stores.Update(updateStore).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Store()
            {
                StoreID = updateStore.StoreID,
                StoreName = updateStore.StoreName,
                Address = updateStore.Address,
                City = updateStore.City
            };
        }

        public void RemoveStore(int id)
        {
            _context.Stores.Remove(GetOneStore(id));
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }


        //INVENTORY METHODS
        //INVENTORY METHODS
        //INVENTORY METHODS

        public Inventory GetInventory(int id)
        {
            return _context.Inventories.FirstOrDefault(c => c.InventoryId == id);
        }

        public Inventory AddInventory(Inventory inventory)
        {
            inventory = _context.Add(inventory).Entity;

            _context.SaveChanges();

            _context.ChangeTracker.Clear();

            return inventory;
        }

        public List<Inventory> GetInventoryByStoreID(int id)
        {
            return _context.Inventories.Where(i => i.StoreId == id).Select(invent => new Models.Inventory()
            {
                InventoryId = invent.InventoryId,
                Quantity = invent.Quantity,
                ProductId = invent.ProductId,
                StoreId = invent.StoreId
            }).ToList();

        }

        public Inventory GetInventoryByProductID(int id)
        {
            Inventory invent = _context.Inventories.Where(i => i.InventoryId == id).FirstOrDefault();
            return new Inventory()
            {
                InventoryId = invent.InventoryId,
                Quantity = invent.Quantity,
                ProductId = invent.ProductId,
                StoreId = invent.StoreId
            };
        }

        public Inventory EditInventoryAmount(Inventory inventoryUpdateArg)
        {
            var inventoryUpdateObj = _context.Inventories.FirstOrDefault(x => x.InventoryId == inventoryUpdateArg.InventoryId);
            inventoryUpdateObj.Quantity = inventoryUpdateArg.Quantity;
            inventoryUpdateObj = _context.Inventories.Update(inventoryUpdateObj).Entity;
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return new Inventory()
            {
                Quantity = inventoryUpdateObj.Quantity
            };
        }

        public void DeleteInventory(int id)
        {
            _context.Inventories.Remove(GetInventory(id));
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }

        //PRODUCT METHODS
        //PRODUCT METHODS
        //PRODUCT METHODS

        public Product AddProduct(Product product)
        {
            product = _context.Add(product).Entity;

            _context.SaveChanges();

            _context.ChangeTracker.Clear();

            return product;
        }

        public List<Product> GetProducts()
        {
            return _context.Products.Select(product => new Models.Product()
            {
                Name = product.Name,
                ProductID = product.ProductID,
                Description = product.Description,
                Manufacturer = product.Manufacturer,
                Price = product.Price
            }).ToList();
        }

        public Product GetProduct(int id)
        {
            Product product = _context.Products.Where(p => p.ProductID == id).FirstOrDefault();
            return new Product()
            {
                Name = product.Name,
                Description = product.Description,
                Manufacturer = product.Manufacturer,
                Price = product.Price,
                ProductID = product.ProductID
            };
        }

        public void DeleteProduct(int id)
        {
            _context.Products.Remove(GetProduct(id));
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
        }

        //ORDER METHODS
        //ORDER METHODS
        //ORDER METHODS

        //public Order AddOrder(int customerId, int productId, int storeId, int quantity)
        //{
        //    Order orderAdd = new Order()
        //    {
        //        CustomerID = customerId,
        //        Quantity = quantity,
        //        ProductID = productId,
        //        StoreID = storeId
        //    };

        //    orderAdd = _context.Add(orderAdd).Entity;

        //    _context.SaveChanges();

        //    _context.ChangeTracker.Clear();

        //    return new Order()
        //    {
        //        OrderID = orderAdd.OrderID,
        //        Quantity = (int)orderAdd.Quantity,
        //    };
        //}

        public List<Order> GetOrderByCustomer(int id)
        {
            return _context.Orders
                .Where(o => o.CustomerID == id)
                .Include(z => z.Customer).Include(f => f.Store)
                .Include(x => x.Items).ThenInclude(x => x.Item)
                .ToList();
        }

        //how do I know, if there is an order for a customer
        public int? GetOpenOrderId(int customerId)
        {
            int? orderId = _context.Orders
                  .Where(x => x.CustomerID == customerId && x.State == OrderStates.Open)
                  .Select(x => x.OrderID)
                  .FirstOrDefault();

            return orderId == 0 ? new int?() : orderId;
        }

        public int CreateOrder(int customerId, int storeId, int productId)
        {
            var order = new Order(customerId, storeId, productId);

            _context.Orders.Add(order);

            _context.SaveChanges();

            return order.OrderID;
        }

        //there is already an order, I want to add another product
        public void AddProductOrder(int productId, int orderId)
        {
            var order = _context.Orders.Include(x => x.Items).FirstOrDefault(x => x.OrderID == orderId);
            order.AddProduct(productId);

            _context.SaveChanges();
        }

        public int SetLineItemQuanitity(int lineItemId, int quantity)
        {
            var lineItem = _context.LineItems.Where(i => i.LineItemID == lineItemId).FirstOrDefault();
            //lineItem.SetQuantity(quantity);
            lineItem.Quantity = quantity;

            _context.SaveChanges();

            return lineItem.Quantity;
        }
























        //is there a card?
        //createing  a card!
        //what is on my card?
        //adding an item!
        //updating quanity!
        //removing item!

        public int GetTotalItemAmountOnCards(int customerId)
        {
            var result = _context.Cards.Where(x => x.CustomerId == customerId).Sum(x => x.Items.Sum(y => y.Quantity));
            return result;
        }

        public int? GetCardForCustomer(int customerId, int storeId)
        {
            var cardId = _context.Cards
                 .Where(x => x.CustomerId == customerId && x.StoreId == storeId)
                 .Select(x => x.Id)
                 .FirstOrDefault();

            return cardId == default ? new int?() : cardId;

            //if(cardId == default)
            //{
            //    return new int?();
            //}
            //else
            //{
            //    return cardId;
            //}
        }

        public int CreateCard(int customerId, int storeId, int productId)
        {
            Card card = new Card(customerId, storeId, productId);

            _context.Cards.Add(card);
            _context.SaveChanges();

            return card.Id;
        }

        public Card GetCardByCustomer(int customerId, int storeId)
        {
            var card = _context.Cards
                .Include(x => x.Customer)
                .Include(x => x.Store)
                .Include(x => x.Items).ThenInclude(x => x.Product)
                .First(x => x.CustomerId == customerId && x.StoreId == storeId);

            return card;
        }

        public List<Card> GetCustomerCards(int customerId)
        {
            var card = _context.Cards
                .Include(x => x.Customer)
                .Include(x => x.Store)
                .Include(x => x.Items).ThenInclude(x => x.Product)
                .Where(x => x.CustomerId == customerId);

            return card.ToList();
        }

        public void AddItemToCard(int productId, int cardId)
        {
            Card card = _context.Cards.Include(x => x.Items).First(x => x.Id == cardId);
            
            if(card.Items.Any(x => x.ProductId == productId) == true)
            {
                return;
            }

            CardItem item = new CardItem(productId, 1, card);

            _context.CardItems.Add(item);

            _context.SaveChanges();
        }

        public void UpdateQuantity(int productId, int cardId, int quantity)
        {
            CardItem item = _context.CardItems.First(x => x.CardId == cardId && x.ProductId == productId);
            item.Quantity = quantity;

            _context.SaveChanges();
        }

        public void RemoveItemFromCard(int productId, int cardId)
        {
            CardItem item = _context.CardItems.First(x => x.CardId == cardId && x.ProductId == productId);

            _context.CardItems.Remove(item);
            _context.SaveChanges();
        }

        public int PlaceOrder(int cardId)
        {
            Card card = _context.Cards
                .Include(x => x.Customer)
                .Include(x => x.Items).ThenInclude(x => x.Product)
                .First(x => x.Id == cardId);
            decimal orderTotal = 0;
            foreach (var item in card.Items)
            {
                var inventory = _context.Inventories.First(x => x.ProductId == item.ProductId
                && x.StoreId == card.StoreId);

                if (inventory.Quantity < item.Quantity)
                {
                    throw new Exception();
                }
                orderTotal += item.Product.Price * item.Quantity;
                inventory.Quantity -= item.Quantity;
            }
            Order order = new Order(card);
            order.TotalPrice = orderTotal;
            _context.Orders.Add(order);
            _context.Cards.Remove(card);

            _context.SaveChanges();

            return order.OrderID;
        }

    }
}