using System;
using StoreBL;
using DL;
using System.Collections.Generic;
using Models;
using System.Linq;

namespace UI
{
    public class ItemsMenu : IMenu
    {

        private IBL _bl;
        public ItemsMenu(IBL bl)
        {
            _bl = bl;
        }

        public void Start()
        {
            string input = "";
            bool exit = false;

            

        do
        {
            Console.WriteLine("Tell me what you're looking for.");
            Console.WriteLine("[0] New Order.");
            Console.WriteLine("[1] View Inventories");
            Console.WriteLine("[x] Back.");

            input = Console.ReadLine();

            switch (input)
            {
            case "0":
                Console.WriteLine($"Lets set you up with some items, shall we?");
                Console.WriteLine("Enter the product id: ");
                Console.WriteLine("Or enter 'Cancel' to stop ordering.");
                input = Console.ReadLine();
                if (input == "Cancel")
                {
                    break;
                }
                // get the item by id
                // foreach (LineItem item in CurrentCustomer.ShoppingCart) {

                // }
                Product product = ViewItem(input);
                Console.WriteLine(product.Name);
                        // check inventory
                Inventory inventory = ViewInventory(input);
                if (inventory.Quantity > 0)
                {
                    Console.WriteLine($"There are {inventory.Quantity} {product.Name}s left.");
                            // then place the order
                int orderId = AddOrder(CurrentCustomer.Customer.CustomerID, product.ProductID, inventory.StoreId);
                Console.WriteLine($"Order placed! Your order id is: {orderId}");
                            // and substract from inventory
                int stockLeft = SubstractInventoryFromProductId(product.ProductID);
                Console.WriteLine($"The new item stock is: {stockLeft}");
                } else
                {
                    Console.WriteLine("Out of stock");
                }
                break;
            case "1":
                Console.WriteLine($"Here are our other locations.");
                ViewInventoryItems();
                break;
            case "x": 
                Console.WriteLine("Returning to main menu.");
                MenuFactory.GetMenu("main").Start();
                //new MainMenu(new BL(new TempRepo())).Start();
                exit = true;
                break;
            default:
            Console.WriteLine("I'm sorry. I don't know what you mean.");
            break;
            }
        } while(!exit);
        }

        public int SubstractInventoryFromProductId(int id)
        {
            int quantity = _bl.SubstractInventoryFromProductId(id);
            return quantity;
        }

        private int AddOrder(int customerId, int productId, int storeId)
        {
            Order order = _bl.AddOrder(customerId, productId, storeId);
            return order.OrderID;
        }

        private Product ViewItem(string itemId) {
            Product product = _bl.GetProduct(int.Parse(itemId));
            return product;
        }

        private Inventory ViewInventory(string itemId) 
        {
            Inventory inventory = _bl.GetInventoryByProductID(int.Parse(itemId));
            return inventory;
        }

        private void ViewAllItems()
        {
            List<Store> allStores = new List<Store>();
            allStores = _bl.GetAllStores();
            if(allStores.Count == 0)
            {
                Console.WriteLine("There are no other locations. My apologies.");
            }
            else
            {
                foreach (Store stores in allStores)
                {
                    Console.WriteLine("");
                    Console.WriteLine(stores.ToString());
                }
            }
        }

        public Inventory SelectAnInventory(string prompt, List<Inventory> listPick)
        {
            SelectInventory:
            Console.WriteLine(prompt);
            for(int i = 0; i < listPick.Count; i++)
            {
                Console.WriteLine("Code here");
                Console.WriteLine($"[{i}] {listPick[i]}");
            }
            string input = Console.ReadLine();
            int parseInput;

            bool parseSucceed = Int32.TryParse(input, out parseInput);

            if(parseSucceed && parseInput >= 0 && parseInput < listPick.Count)
            {
                return listPick[parseInput];
            }
            else
            {
                Console.WriteLine("I don't understand, please try again.");
                goto SelectInventory;
            }
        }

        // private void ViewInventory()
        // {
           
        //     foreach (var item in searchResult)
        //     {
        //         Console.WriteLine(item);
        //     }
        // }

        private void ViewAllStores()
        {
            
            List<Store> allStores = new List<Store>();
            allStores = _bl.GetAllStores();
            if(allStores.Count == 0)
            {
                Console.WriteLine("There are no other locations. My apologies.");
            }
            else
            {
                foreach (Store stores in allStores)
                {
                    Console.WriteLine(stores.ToString());
                }
            }
        }
    
        private void ViewInventoryItems()
        {
            ViewAllStores();
            Console.WriteLine("Please put in the store number whose inventory you would like: ");
            int storeId = Convert.ToInt32(Console.ReadLine());
            List<Inventory> storeItems = _bl.GetInventoryByStoreID(storeId);
            List<Product> myProducts = _bl.GetProducts();

            var tempInvent = from m1 in storeItems
            join m2 in myProducts on m1.ProductId equals m2.ProductID
            select new {m1.ProductId, m2.Name, m1.Quantity, m2.Description, m2.Price};

            foreach (var item in tempInvent)
            {
                Console.WriteLine("");
             Console.WriteLine($"Product ID: {item.ProductId} \nProduct Name: {item.Name} \nProduct Description: {item.Description} \nPrice: {item.Price}");   
            }
        }

    }
}