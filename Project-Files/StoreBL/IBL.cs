using System;
using System.Collections.Generic;
using Models;

namespace StoreBL
{
    public interface IBL
    {
        List<Store> GetAllStores();
        public Customer GetCustomer(int id);

        public Customer AddCustomer(Customer newCustomer);

        public List<Customer> SearchCustomer(string queryStr);

        public List<Inventory> GetInventoryByStoreID(int id);

        public Inventory GetInventoryByProductID(int id);

        public List<Product> GetProducts();

        public Product GetProduct(int id);

        public Order AddOrder(int customerId, int productId, int storeId, int quantity);

        public int SubstractInventoryFromProductId(int id);

        public List<Order> GetOrderByCustomer(int id);

        public Store AddStore(Store store);

        public Store GetOneStore(int id);
    }
}