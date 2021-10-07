using System;
using System.Collections.Generic;
using Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public Customer GetCustomer(int id)
        {
            Customer customerById = _context.Customers.FirstOrDefault(c => c.CustomerID == id);

            return new Customer(){
                CustomerID = customerById.CustomerID,
                Name = customerById.Name,
                Age = customerById.Age,
                Address = customerById.Address,
                City = customerById.City,
            };
        }
        
        public Order AddOrder(int customerId, int productId, int storeId, int quantity)
        {
            Order orderAdd = new Order() {
                CustomerID = customerId,
                Quantity = quantity,
                ProductID = productId,
                StoreID = storeId
            };

            orderAdd = _context.Add(orderAdd).Entity;

            _context.SaveChanges();

            _context.ChangeTracker.Clear();

            return new Order()
            {
                OrderID = orderAdd.OrderID,
                Quantity = (int) orderAdd.Quantity,
            };
        }

        public Customer AddCustomer(Customer newCustomer)
        {
            Customer customerAdd = new Customer(){
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

        public List<Customer> SearchCustomer(string queryStr)
        {
            return _context.Customers.Where(
                customer => customer.Name.Contains(queryStr) || customer.City.Contains(queryStr) || customer.Address.Contains(queryStr)
            ).Select(
                c => new Customer(){
                    CustomerID = c.CustomerID,
                    Name = c.Name,
                    City = c.City,
                    Address = c.Address,
                    Age = c.Age
                }
            ).ToList();
        }


        //Contains DBContext.
        //These methods will get data from the db and persist to db.

        public List<Store> GetAllStores()
        {
            //Similar to * in SQL.
            //Select() always takes an argument.
            //Gets Entites.Store and we convert it to Model.Store
            return _context.Stores.Select(
                    store => new Store(){
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
                s => new Store(){
                    StoreID = s.StoreID,
                    StoreName = s.StoreName,
                    City = s.City,
                    Address = s.Address
                }
            ).ToList();
        }

        public Store GetOneStore(int id)
        {
            Store storeById = _context.Stores.Include(s => s.Inventories).FirstOrDefault(s => s.StoreID == id);

            return new Store(){
                StoreID  = storeById.StoreID,
                StoreName = storeById.StoreName,
                Address = storeById.Address,
                City = storeById.City
            };
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

        public List<Order> GetOrderByCustomer(int id)
        {
            return _context.Orders.Where(o => o.CustomerID == id).Select(order => new Order()
            {
                CustomerID = order.CustomerID,
                OrderID = order.OrderID
            }).ToList();
        }

        public Inventory GetInventoryByProductID(int id)
        {
            Inventory invent = _context.Inventories.Where(i => i.ProductId == id).FirstOrDefault();
            return new Inventory()
            {
                InventoryId = invent.InventoryId,
                Quantity = invent.Quantity,
                ProductId = invent.ProductId,
                StoreId = invent.StoreId
            };
        }

        public int SubstractInventoryFromProductId(int id)
        {
            Inventory inventory = _context.Inventories.Where(i => i.ProductId == id).FirstOrDefault();
            int quantity = inventory.Quantity - 1;
            inventory.Quantity = quantity;
            
            _context.Inventories.Update(inventory);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();

            return quantity;
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


        
    }
}