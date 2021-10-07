using System.Collections.Generic;
using Models;

namespace StoreBL
{
    public class CurrentCustomer
    {
        public static Customer Customer { get; set; }
        public static List<LineItem> ShoppingCart {get; set;}
    }
}