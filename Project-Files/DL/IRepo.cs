using Models;
using System.Collections.Generic;
using Model = Models;

namespace DL
{
    public interface IRepo
    {
        public Store AddStore(Store store);

        List<Model.Store> GetAllStores();

        public Store GetOneStore(int id);

        Model.Customer GetCustomer(int id);

        Model.Customer AddCustomer(Model.Customer newCustomer);

        List<Model.Customer> SearchCustomer(string queryStr);

        public List<Model.Inventory> GetInventoryByStoreID(int id);

        public Model.Inventory GetInventoryByProductID(int id);

        public Model.Order AddOrder(int customerId, int productId, int storeId, int quantity);

        public List<Model.Product> GetProducts();

        public Model.Product GetProduct(int id);

        public int SubstractInventoryFromProductId(int id);

        public List<Model.Order> GetOrderByCustomer(int id);
    }
}