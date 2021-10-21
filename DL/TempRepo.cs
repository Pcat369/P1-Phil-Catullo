using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
// using System.Collections.IEnumerable;


namespace DL
{
    public class TempRepo
    {
        public Customer AddCustomer(Customer newCustomer)
        {
            throw new NotImplementedException();
        }



        public List<Store> GetAllStores()
        {
            return new List<Store>()
            {

            };
        }

        public Customer GetCustomer()
        {
            return new Customer()
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