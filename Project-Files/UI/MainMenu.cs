using System;
using Models;
using StoreBL;

namespace UI
{
    public class MainMenu : IMenu
    {
        private IBL _bl;
        public MainMenu(IBL bl)
        {
            _bl = bl;
        }
        public void Start()
        {

            bool exit = false;
            string input = "";

            do
            {

            Console.WriteLine($"What can I help you with {CurrentCustomer.Customer.Name}?");
            Console.WriteLine("[0] Item Order.");
            Console.WriteLine("[1] Check Stores.");
            Console.WriteLine("[2] Customer Options.");
            Console.WriteLine("[x] Leave...");

            input = Console.ReadLine();

            switch (input)
            {
            case "0":
                MenuFactory.GetMenu("items").Start();
                break;
            case "1":
                MenuFactory.GetMenu("Stores").Start();
                break;
            case "2":
                MenuFactory.GetMenu("customer").Start();
                break;
            case "x":
                Console.WriteLine("Have a splendid day!");
                exit = true;
                break;
            default:
            Console.WriteLine("I'm sorry. I don't understand.");
            break;
            }
            
            }while(!exit);
            
        }
    }
}