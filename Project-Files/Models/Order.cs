using System.Collections.Generic;

namespace Models
{
    public class Order
    {
        public Order(){}

        public Order(int orderIdent) : this()
        {
            this.OrderID = orderIdent;
        }

        
        public Order(int orderIdent, int customerIdent) : this(orderIdent)
        {
            this.CustomerID = customerIdent;
        }

        public Order(int orderIdent, int customerIdent, int quantity) : this(orderIdent, customerIdent)
        {
            this.Quantity = quantity;
        }


        public int ProductID { get; set; }

        public int StoreID { get; set; }

        public int OrderID { get; set; }

        public int CustomerID { get; set; }

        public int Quantity { get; set; }
    }
}