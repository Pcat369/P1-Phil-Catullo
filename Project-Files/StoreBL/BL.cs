using System;
using System.Collections.Generic;
using DL;
using Models;

namespace StoreBL
{
    public class BL : IBL
    {
        private IRepo _repo;
        //Dependency Injection
        public BL(IRepo repo)
        {
            _repo = repo;
        }

        public Customer AddCustomer(Customer newCustomer)
        {
            return _repo.AddCustomer(newCustomer);
        }

        public Store AddStore(Store store)
        {
            return _repo.AddStore(store);
        }

        public List<Store> GetAllStores()
        {

            return _repo.GetAllStores();
        }

        public Store GetOneStore(int id)
        {
            return _repo.GetOneStore(id);
        }

        public Customer GetCustomer(int id)
        {
            return _repo.GetCustomer(id);
        }

        public List<Customer> SearchCustomer(string queryStr)
        {
            return _repo.SearchCustomer(queryStr);
        }

        public List<Inventory> GetInventoryByStoreID(int id)
        {
            return _repo.GetInventoryByStoreID(id);
        }

        public Inventory GetInventoryByProductID(int id)
        {
            return _repo.GetInventoryByProductID(id);
        }

        public List<Product> GetProducts()
        {
            return _repo.GetProducts();
        }

        public Product GetProduct(int id)
        {
            return _repo.GetProduct(id);
        }

        public Order AddOrder(int customerId, int productId, int storeId, int quantity)
        {
            return _repo.AddOrder(customerId, productId, storeId, quantity);
        }

        public int SubstractInventoryFromProductId(int id)
        {
            return _repo.SubstractInventoryFromProductId(id);
        }

        public List<Order> GetOrderByCustomer(int id)
        {
            return _repo.GetOrderByCustomer(id);
        }

        
    }
}
