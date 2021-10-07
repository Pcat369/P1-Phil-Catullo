using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Models;

namespace UI
{
    public class CustomerService
    {
        public Customer SelectACustomer(string prompt, List<Customer> listPick)
        {
            selectCustomer:
            Console.WriteLine(prompt);
            for(int i = 0; i < listPick.Count; i++)
            {
                Console.WriteLine($"[{i}] {listPick}");
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
    }
}