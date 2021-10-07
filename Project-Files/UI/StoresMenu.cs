using System;
using System.Collections.Generic;
using StoreBL;
using Models;


namespace UI
{
    public class StoresMenu : IMenu
    {
        private IBL _bl;
        public StoresMenu(IBL bl)
        {
            _bl = bl;
        }

        public void Start()
        {
            bool exit = false;
            string input = "";

            do
            {

            Console.WriteLine("Stores Menu");
            Console.WriteLine("[0] Item Order.");
            Console.WriteLine("[1] Check Stores.");
            Console.WriteLine("[x] Back");

            input = Console.ReadLine();

            switch (input)
            {
            case "0":
            MenuFactory.GetMenu("items").Start();
                break;
            case "1":
                ViewAllStores();
                break;
            case "x":
                Console.WriteLine("Returning to main menu.");
                exit = true;
                break;
            default:
            Console.WriteLine("I'm sorry. I don't understand.");
            break;
            }

            }while(!exit);
        }

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
    }
}