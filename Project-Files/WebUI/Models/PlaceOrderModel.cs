using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{

    public class InventoryViewModel
    {
        public int InventoryId { get; set; }

        [Required]
        public int Quantity { get; set; }

        public int StoreId { get; set; }

        public int ProductId { get; set; }

        public int SaleQuantity { get; set; }

        //[Required]
        public Product Product { get; set; }
    }

    public class PlaceOrderViewModel
    {
        [Display(Name = "Store Name")]
        [Required]
        [RegularExpression("^[a-zA-Z0-9 !?']+$", ErrorMessage = "Store names can only contain alphanumeric characters, as well as !, ?, and '.")]
        public string StoreName { get; set; }

        [RegularExpression("^[a-zA-Z0-9 !?']+$", ErrorMessage = "Street ames can only contain alphanumeric characters, as well as !, ?, and '.")]
        public string Address { get; set; }

        [RegularExpression("^[a-zA-Z0-9 !?']+$", ErrorMessage = "City names can only contain alphanumeric characters, as well as !, ?, and '.")]
        public string City { get; set; }

        public int StoreID { get; set; }

        public List<InventoryViewModel> Inventories { get; set; }
    }
}
