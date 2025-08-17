using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_DEMO.Entities
{
    public class Product
    {
        public int ProductId { get; set; } //primary key
        //[MaxLength(100)]
        //[Required]
        public string ProductName { get; set; }
        //[Required]
        //[Range(1000,10000)]
        public int Price { get; set; }
        public string? Brand { get; set; }
        //[NotMapped]
        //public int Profit { get; set; }//ccalculatable and i dont want it to store in db

        public Category Category { get; set; }//has a relationship 
   
        public List<Supplier> Suppliers { get; set; } = new List<Supplier>(); //many to many relationship
    
    }

    // [Table("tbl_categories")]
    public class Category
    {
        public int CategoryId { get; set; }
        //[Column("name")]
        public string CategoryName { get; set; }

        public List<Product> Products { get; set; }= new List<Product>();

    }

    public class Supplier : Person
    {
        public string GSTno { get; set; }

        public int Rating { get; set; }
        public List<Product> products { get; set; } = new List<Product>();
    }



    //no need any dbset to address
    [ComplexType]
    public class Address
    {//no need of id since we dont need a table
        //public int AddressId { get; set; }
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

        public Address Address { get; set; }

    }

    public class Customer : Person
    {
        public int Discount { get; set; }
    }


    //public class  Student
    //{
    //    [Key]
    //    public int Rollno { get;set; }
    //    public string StudentName { get; set; }

    //}

}

