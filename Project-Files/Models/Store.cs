using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Store
    {

        public Store()
        {
            this.Inventories = new List<Inventory>();
        }

        

        public Store(string storename)
        {
            this.StoreName = storename;
        }

        public Store(string storename, string address) : this(storename)
        {
            this.Address = address;
        }

        public Store(string storename, string address, int storeID) : this(storename, address)
        {
            this.StoreID = storeID;
        }

        [Required]
        [RegularExpression("^[a-zA-Z0-9 !?']+$", ErrorMessage = "Store names can only contain alphanumeric characters, as well as !, ?, and '.")]
        public string StoreName{get; set;}

        [RegularExpression("^[a-zA-Z0-9 !?']+$", ErrorMessage = "Street ames can only contain alphanumeric characters, as well as !, ?, and '.")]
        public string Address{get; set;}

        [RegularExpression("^[a-zA-Z0-9 !?']+$", ErrorMessage = "City names can only contain alphanumeric characters, as well as !, ?, and '.")]
        public string City { get; set; }

        public int StoreID { get; set; }

        public List<Inventory> Inventories { get; set; }
        
        public override string ToString()
        {
            return $"Store Name: {this.StoreName}. \nAddress: {this.Address}. \nCity: {this.City}. \nID: {this.StoreID}.";
        }
    }
}