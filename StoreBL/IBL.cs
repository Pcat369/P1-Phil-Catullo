using System;
using System.Collections.Generic;
using Models;

namespace StoreBL
{
    public interface IBL
    {
        List<Store> GetAllStores();
        List<Customer> GetAllCustomers();
        public Customer GetCustomer(int id);

        public Customer AddCustomer(Customer newCustomer);

        public List<Customer> SearchCustomer(string queryStr);

        public List<Inventory> GetInventoryByStoreID(int id);

        public Inventory GetInventoryByProductID(int id);

        public Product AddProduct(Product product);

        public List<Product> GetProducts();

        public Product GetProduct(int id);

        public void DeleteProduct(int id);

        public Order AddOrder(int customerId, int productId, int storeId, int quantity);

        public Inventory GetInventory(int id);

        public Inventory AddInventory(Inventory inventory);

        public void DeleteInventory(int id);

        public Inventory EditInventoryAmount(Inventory inventoryUpdateArg);

        public int SubtractInventoryFromProductId(int id);

        public List<Order> GetOrderByCustomer(int id);

        public Store AddStore(Store store);

        public Store GetOneStore(int id);

        Store UpdateStore(Store storeToUpdate);

        public void DeleteStore(int id);

        public void DeleteCustomer(int id);

        public Customer EditCustomer(Customer customerInfo);

        int? GetOpenOrderId(int customerId);
        int CreateOrder(int customerId, int storeId, int productId);
        void AddProductOrder(int productId, int orderId);
        int SetLineItemQuanitity(int lineItemId, int quantity);

        int GetTotalItemAmountOnCards(int customerId);
        int? GetCardForCustomer(int customerId, int storeId);
        int CreateCard(int customerId, int storeId, int productId);
        Card GetCardByCustomer(int customerId, int storeId);
        List<Card> GetCustomerCards(int customerId);
        void AddItemToCard(int productId, int cardId);
        void UpdateQuantity(int productId, int cardId, int quantity);
        void RemoveItemFromCard(int productId, int cardId);
        int PlaceOrder(int cardId);
    }
}