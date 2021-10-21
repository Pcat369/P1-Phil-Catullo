using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using StoreBL;

namespace UI
{
    public class CustomerMenu : IMenu
    {
        private IBL _bl;

        private CustomerService _customerService;
        public CustomerMenu(IBL bl, CustomerService customerService)
        {
            _bl = bl;
            _customerService = customerService;
        }

        public void Start()
        {
            bool exit = false;
            string input = "";

            do
            {

            Console.WriteLine("What can I help you with?");
            Console.WriteLine("[0] New User.");
            Console.WriteLine("[1] Check Customers.");
            Console.WriteLine("[x] Back");

            input = Console.ReadLine();

            switch (input)
            {
            case "0":
                Console.WriteLine("Thank you for choosing to register with The Mage's Tower.");
                AddCustomer();
                break;
            case "1":
                ViewCustomer();
                break;
            case "x":
                Console.WriteLine("Back to the first page.");
                exit = true;
                break;
            default:
            Console.WriteLine("I'm sorry. I don't understand.");
            break;
            }

            }while(!exit);
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


        public Customer SelectACustomer(string prompt, List<Customer> listPick)
        {
            selectCustomer:
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
                goto selectCustomer;
            }
        }

        private void ViewCustomer()
        {
            Console.WriteLine("Please insert the ID for the customer you are looking for: ");
            Customer searchResult = _bl.GetCustomer(Convert.ToInt32(Console.ReadLine()));
            // if (searchResult == null || searchResult.Count == 0)
            // {
            //     Console.WriteLine("No Customers in the system.");
            //     return;
            // }
            // Customer selectedCustomer = _customerService.SelectACustomer("Pick a customer by ID", searchResult);

            // selectedCustomer = _bl.GetCustomer(selectedCustomer.CustomerID);
            Console.WriteLine(searchResult);
        }

        // private void ViewACustomer()
        // {
        //     List<Customer> anCust = new List<Customer>();
        //     anCust = _bl.GetAllStores();
        //     if(allStores.Count == 0)
        //     {
        //         Console.WriteLine("There are no other locations. My apologies.");
        //     }
        //     else
        //     {
        //         foreach (Store stores in allStores)
        //         {
        //             Console.WriteLine(stores.ToString());
        //         }
        //     }
        // }
    }
}