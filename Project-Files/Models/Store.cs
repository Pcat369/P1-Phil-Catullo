using System;
using System.Collections.Generic;

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

        public string StoreName{get; set;}

        public string Address{get; set;}

        public string City { get; set; }

        public int StoreID { get; set; }

        public List<Inventory> Inventories { get; set; }
        
        public override string ToString()
        {
            return $"Store Name: {this.StoreName}. \nAddress: {this.Address}. \nCity: {this.City}. \nID: {this.StoreID}.";
        }

        public bool Equals(Store store)
        {
            return this.StoreID == store.StoreID && this.StoreName == store.StoreName && this.Address == store.Address && this.City == store.City;
        }
    }
}