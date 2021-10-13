using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    [Table("CardItems")]
    public class CardItem
    {
        public CardItem()
        {

        }
        public CardItem(int productId, int quantity, Card card)
        {
            ProductId = productId;
            Quantity = quantity;
            Card = card;
        }

        [Key]
        public int Id { get; set; }

        public int CardId { get; set; }

        [ForeignKey(nameof(CardId))]
        public Card Card { get; set; }

        public int ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; }

        public int Quantity { get; set; }

    }
}
