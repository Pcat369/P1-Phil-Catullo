using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using StoreBL;
using System.Text.RegularExpressions;

namespace UI
{
    //Regex reg = new Regex("^[a-zA-Z0-9 !?]+$");
    public class LoginMenu : IMenu
    {
        int customer;
        private IBL _bl;

        public LoginMenu(IBL bl)
        {
            _bl = bl;
        }
        
        public void Start()
        {
            bool exit = false;
            string input = "";

            do {
                Console.WriteLine($"Hello, and welcome to The Mage's Tower!");
                Console.WriteLine("Is this your first time shopping with us? [y/n]");

                input = Console.ReadLine();

                if(input == "y")
                {
                    Customer customer = AddCustomer();
                    CurrentCustomer.Customer = customer;
                    exit = true;
                }
        
                else if (input == "n")
                {
                    Console.WriteLine("Thank you for once again choosing The Mage's Tower for your adventuring and wizardry needs.");
                    Customer customer = SelectACustomer();
                    CurrentCustomer.Customer = customer;
                    Console.WriteLine($"Welcome back {customer.Name}!");
                    exit = true;
                }

                else {
                    Console.WriteLine("Please answer with Y or N");
                }
            } while(!exit);

            MenuFactory.GetMenu("main").Start();
        }


        private Customer AddCustomer()
        {

            Customer newCust = new Customer();

            inputName:

            Console.WriteLine("Please enter your first and last name.");

            Console.WriteLine("");

            string custName = Console.ReadLine();

            newCust.Name = custName;
            
            Console.WriteLine($"Thank you {newCust.Name}. We will also need your street address.");

            string custAddress = Console.ReadLine();
            
            newCust.Address = custAddress;

            Console.WriteLine($"{newCust.Address} hmm? What city is that in? ");

            string custCity = Console.ReadLine();
            
            newCust.City = custCity;

            Console.WriteLine("");

            Console.WriteLine("Thank you. Lastly, I will need your age, please.");

            int custAge = Convert.ToInt32(Console.ReadLine());

            newCust.Age = custAge;

            Console.WriteLine("");

            Console.WriteLine($"Very well, let me read that back to you.");

            Console.WriteLine($"You are {newCust.Name}. From {newCust.City} at {newCust.Address}, and you are {newCust.Age} years old.");

            Console.WriteLine("Is that correct? [y/n]");

            string input = Console.ReadLine();

            if (input == "y")
            {
                Console.WriteLine("Splendid, thank you for registering with us!");
                Customer custmerAdd = _bl.AddCustomer(newCust);
                Console.WriteLine(newCust);
            return newCust;
            }
            else
            {
                Console.WriteLine("Oh dear! I'm sorry about that. Lets try again, shall we?");
                goto inputName;
            }
        }

        public Customer SelectACustomer()
        {
            Console.WriteLine("Please confirm ID selection: ");
            Customer searchResult = _bl.GetCustomer(Convert.ToInt32(Console.ReadLine()));
            return searchResult;
        }
    }
}