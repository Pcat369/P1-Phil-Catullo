using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class LineItem
    {
        public LineItem()
        {

        }
        public LineItem(int productId, int quantity, Order order)
        {
            ProductID = productId;
            Order = order;
            Quantity = quantity;
        }

        public int Quantity { get; set; }

        [ForeignKey(nameof(ProductID))]
        public Product Item { get; set; }

        [ForeignKey(nameof(OrderID))]
        public Order Order { get; set; }

        public int OrderID { get; set; }

        public int ProductID { get; set; }

        [Key]
        public int LineItemID { get; set; }

    }
}