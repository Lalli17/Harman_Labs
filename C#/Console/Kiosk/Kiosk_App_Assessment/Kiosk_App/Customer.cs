using System;
using System.Collections.Generic;

namespace Kiosk_App
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string ShippingAddress { get; set; }
        public Dictionary<string, object> Preferences { get; set; } // For computer requirements

        public Customer(int id, string name, int age, string gender, string shippingAddress)
        {
            Id = id;
            Name = name;
            Age = age;
            Gender = gender;
            ShippingAddress = shippingAddress;
            Preferences = new Dictionary<string, object>();
        }

        public void Display()
        {
            Console.WriteLine($"Customer ID: {Id}, Name: {Name}, Age: {Age}, Gender: {Gender}, Address: {ShippingAddress}");
        }
    }
} 