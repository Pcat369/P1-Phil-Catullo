using Models;
using System.Collections.Generic;

namespace DL
{
    public interface IRepo
    {
        public Store AddStore(Store store);

        List<Store> GetAllStores();

        List<Customer> GetAllCustomers();

        public Store GetOneStore(int id);

        Store UpdateStore(Store storeToUpdate);

        void RemoveStore(int id);

        Customer GetCustomer(int id);

        Customer AddCustomer(Customer newCustomer);

        void DeleteCustomer(int customerId);

        List<Customer> SearchCustomer(string queryStr);

        public Customer EditCustomer(Customer customerInfo);

        Inventory GetInventory(int id);

        public void DeleteInventory(int id);

        public Inventory AddInventory(Inventory inventory);

        public Inventory EditInventoryAmount(Inventory inventoryUpdateArg);

        public List<Inventory> GetInventoryByStoreID(int id);

        public Inventory GetInventoryByProductID(int id);

        //public Order AddOrder(int customerId, int productId, int storeId, int quantity);

        public Product AddProduct(Product product);

        public List<Product> GetProducts();

        public Product GetProduct(int id);

        public void DeleteProduct(int id);

        //public int SubtractInventoryFromProductId(int id);

        public List<Order> GetOrderByCustomer(int id);

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