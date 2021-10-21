using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace WebUI.Models
{
    public class StoreVM
    {
        public StoreVM() { }
        public StoreVM(Store store)
        {
            this.StoreID = store.StoreID;
            this.StoreName = store.StoreName;
            this.Address = store.Address;
            this.City = store.City;
            this.Inventories = store.Inventories;

        }

        [Display(Name = "Store Name")]
        [Required]
        [RegularExpression("^[a-zA-Z0-9 !?']+$", ErrorMessage = "Store names can only contain alphanumeric characters, as well as !, ?, and '.")]
        public string StoreName { get; set; }

        [RegularExpression("^[a-zA-Z0-9 !?']+$", ErrorMessage = "Street names can only contain alphanumeric characters, as well as !, ?, and '.")]
        public string Address { get; set; }

        [RegularExpression("^[a-zA-Z0-9 !?']+$", ErrorMessage = "City names can only contain alphanumeric characters, as well as !, ?, and '.")]
        public string City { get; set; }

        public int StoreID { get; set; }

        public List<Inventory> Inventories { get; set; }

        public Store ToModel()
        {
            Store newStore;
            try
            {
                newStore = new Store
                {
                    StoreID = this.StoreID,
                    StoreName = this.StoreName ?? "",
                    Address = this.Address,
                    City = this.City

                };

            }
            catch
            {
                throw;
            }
            return newStore;
        }
    }
}
