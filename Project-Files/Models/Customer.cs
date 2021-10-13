using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [RegularExpression("^[a-zA-Z']+$", ErrorMessage = "Names can only contain alphabetical characters.")]
        public string Name{get; set;}

        [RegularExpression("^[0-9]+$", ErrorMessage = "Your Age can only contain numeric characters.")]
        public int Age{get; set;}

        [RegularExpression("^[a-zA-Z']+$", ErrorMessage = "City names can only contain alphanumeric characters.")]
        public string City{get; set;}

        [RegularExpression("^[a-zA-Z0-9 !?']+$", ErrorMessage = "Addresses can only contain alphanumeric characters, as well as !, ?, and '.")]
        public string Address { get; set; }

        public int CustomerID{get; set;}

        public override string ToString()
        {
            return $"Customer Name: {this.Name} \nAddress: {this.Address} \nCity: {this.City} \nAge: {this.Age} \n  ";
        }
    }
}
