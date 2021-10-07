using System;
using System.Collections.Generic;

namespace Models
{
    public class Customer
    {
        public Customer() {}

        //Constructor overloading
        public Customer(string name) : this()
        {
            this.Name = name;
        }

        //Constructor chaining, not necessary, but good for accounting if customer doesnt have some data like age.
        public Customer(string name, int age) : this(name) 
        {
            this.Age = age;
        }

        public Customer(string name, int age, string city) : this(name, age)
        {   /*Call Setter*/
            this.City = city;
        }

        public Customer(string name, int age, string city, string address) : this(name, age, city)
        {   /*Call Setter*/
            this.Address = address;
        }

        public List<Order> Orders { get; set; }

        //We can interact with properties like fields.
        //They have getters and setters built in.
        public string Name{get; set;}

        public int Age{get; set;}

        public string City{get; set;}

        public string Address { get; set; }

        public int CustomerID{get; set;}

        public override string ToString()
        {
            return $"Customer Name: {this.Name} \nAddress: {this.Address} \nCity: {this.City} \nAge: {this.Age} \n  ";
        }
    }
}
