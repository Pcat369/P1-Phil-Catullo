using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public enum OrderStates
    {
        Open,
        Closed,
    }

    public class Order
    {
        public Order() { }

        //public Order(int orderIdent) : this()
        //{
        //    this.OrderID = orderIdent;
        //}

        public Order(Card card)
        {
            CustomerID = card.CustomerId;
            StoreID = card.StoreId;

            Items = new List<LineItem>();
            foreach (var item in card.Items)
            {
                Items.Add(new LineItem(item.ProductId, item.Quantity, this));
            }
        }

        //not needed
        public Order(int customerId, int storeId, int productId) : this()
        {
            this.CustomerID = customerId;
            this.StoreID = storeId;
            State = OrderStates.Open;

            Items = new List<LineItem>();
            AddProduct(productId);
        }

        //public Order(int orderIdent, int customerIdent, int quantity) : this(orderIdent, customerIdent)
        //{
        //    this.Quantity = quantity;
        //}


        //public int ProductID { get; set; }
        public OrderStates State { get; set; } // no needed anymore
        public int StoreID { get; set; }

        public Store Store { get; set; }

        public Customer Customer { get; set; }
        [Key]
        public int OrderID { get; set; }

        public int CustomerID { get; set; }

        public virtual List<LineItem> Items { get; set; }

        public void AddProduct(int productId)
        {
            Items.Add(new LineItem(productId, 1, this));
        }

        public decimal TotalPrice { get; set; }
    }
}