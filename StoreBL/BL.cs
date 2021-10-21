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

        public void DeleteCustomer(int customerId)
        {
            _repo.DeleteCustomer(customerId);
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

        public Store UpdateStore(Store updateStore)
        {
            return _repo.UpdateStore(updateStore);
        }

        public void DeleteStore(int id)
        {
            _repo.RemoveStore(id);
        }

        public Customer GetCustomer(int id)
        {
            return _repo.GetCustomer(id);
        }

        public List<Customer> SearchCustomer(string queryStr)
        {
            return _repo.SearchCustomer(queryStr);
        }
        public Inventory GetInventory(int id)
        {
            return _repo.GetInventory(id);
        }
        public Inventory AddInventory(Inventory inventory)
        {
            return _repo.AddInventory(inventory);
        }

        public Inventory EditInventoryAmount(Inventory inventoryUpdateObj)
        {
            return _repo.EditInventoryAmount(inventoryUpdateObj);
        }

        public List<Inventory> GetInventoryByStoreID(int id)
        {
            return _repo.GetInventoryByStoreID(id);
        }

        public Inventory GetInventoryByProductID(int id)
        {
            return _repo.GetInventoryByProductID(id);
        }

        public void DeleteInventory(int id)
        {
            _repo.DeleteInventory(id);
        }

        public Product AddProduct(Product product)
        {
            return _repo.AddProduct(product);
        }

        public List<Product> GetProducts()
        {
            return _repo.GetProducts();
        }

        public Product GetProduct(int id)
        {
            return _repo.GetProduct(id);
        }

        public void DeleteProduct(int id)
        {
            _repo.DeleteProduct(id);
        }

        public Order AddOrder(int customerId, int productId, int storeId, int quantity)
        {
            return null;
            //return _repo.AddOrder(customerId, productId, storeId, quantity);
        }

        public int SubtractInventoryFromProductId(int id)
        {
            return 0;
            //return _repo.SubtractInventoryFromProductId(id);
        }

        public List<Order> GetOrderByCustomer(int id)
        {
            return _repo.GetOrderByCustomer(id);
        }

        public List<Customer> GetAllCustomers()
        {
            return _repo.GetAllCustomers();
        }

        public Customer EditCustomer(Customer updateCustomer)
        {
            return _repo.EditCustomer(updateCustomer);
        }

        public int? GetOpenOrderId(int customerId)
        {
            return _repo.GetOpenOrderId(customerId);
        }

        public int CreateOrder(int customerId, int storeId, int productId)
        {
            return _repo.CreateOrder(customerId, storeId, productId);
        }

        public void AddProductOrder(int productId, int orderId)
        {
            _repo.AddProductOrder(productId, orderId);
        }

        public int SetLineItemQuanitity(int lineItemId, int quantity)
        {
            return _repo.SetLineItemQuanitity(lineItemId, quantity);
        }

        public int GetTotalItemAmountOnCards(int customerId)
        {
            return _repo.GetTotalItemAmountOnCards(customerId);

        }
        public int? GetCardForCustomer(int customerId, int storeId)
        {
            return _repo.GetCardForCustomer(customerId, storeId);

        }
        public int CreateCard(int customerId, int storeId, int productId)
        {
            return _repo.CreateCard(customerId, storeId, productId);

        }
        public Card GetCardByCustomer(int customerId, int storeId)
        {
            return _repo.GetCardByCustomer(customerId, storeId);

        }
        public List<Card> GetCustomerCards(int customerId)
        {
            return _repo.GetCustomerCards(customerId);

        }
        public void AddItemToCard(int productId, int cardId)
        {
            _repo.AddItemToCard(productId, cardId);

        }
        public void UpdateQuantity(int productId, int cardId, int quantity)
        {
            _repo.UpdateQuantity(productId, cardId, quantity);

        }
        public void RemoveItemFromCard(int productId, int cardId)
        {
            _repo.RemoveItemFromCard(productId, cardId);

        }
        public int PlaceOrder(int cardId)
        {
            return _repo.PlaceOrder(cardId);

        }
    }
}
