using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
// using System.Collections.IEnumerable;
using Model = Models;

namespace DL
{
    public class TempRepo
    {
        public Model.Customer AddCustomer(Model.Customer newCustomer)
        {
            throw new NotImplementedException();
        }

        public List<Model.Store> GetAllStores()
        {
            return new List<Model.Store>()
            {

            };
        }

        public Model.Customer GetCustomer()
        {
            return new Model.Customer()
            {
                
            };
        }

        public Customer GetCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public List<Inventory> GetInventoryByStoreID(int id)
        {
            throw new NotImplementedException();
        }

        public Product GetProduct(int id)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProducts()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetProductsByStoreID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> SearchCustomer(string queryStr)
        {
            throw new NotImplementedException();
        }
    }
}