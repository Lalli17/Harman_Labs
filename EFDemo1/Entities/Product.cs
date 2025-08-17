using System.ComponentModel.DataAnnotations.Schema;

namespace EFDemo1.Entities
{
    public class Product
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int Price { get; set; }

        public string? Brand { get; set; }

        public Category Category { get; set; }

        public List<Supplier> Suppliers { get; set; } = new List<Supplier>();


    }


    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }

    public class Supplier : Person
    {

        public string GSTNo { get; set; }
        public int Rating { get; set; }

        //public List<Product> Products { get; set; } = new List<Product>();
    }

    [ComplexType]
    public class Address
    {
        //public int AddressId { get; set;
        public string Area { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }

    abstract public class Person
    {

        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        //public Address Address { get; set; }

    }

    public class Customer : Person
    {
        public int Discount { get; set; }
    }
}


