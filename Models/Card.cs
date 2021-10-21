using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("Cards")]
    public class Card
    {
        [Key]
        public int Id { get; set; }

        public int StoreId { get; set; }

        [ForeignKey(nameof(StoreId))]
        public Store Store { get; set; }

        public int CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }

        public List<CardItem> Items { get; set; }
        public Card()
        {

        }

        public Card(int customerId, int storeId, int firstProductId)
        {
            CustomerId = customerId;
            StoreId = storeId;

            Items = new List<CardItem>();
            Items.Add(new CardItem(firstProductId, 1, this));
        }

    }
}
