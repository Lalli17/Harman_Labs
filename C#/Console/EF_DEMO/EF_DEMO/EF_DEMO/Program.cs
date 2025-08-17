using EF_DEMO.Data;
using EF_DEMO.Entities;
using Microsoft.EntityFrameworkCore;

namespace EF_DEMO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //manage products : CRUD 


            //User story 1: Save product details into database table
            //step 1: UI is consle app , DB, MS SQL Server, FW: EF , code first approach 
            //Step 2: Create Product entity class
            //step 3: download and install EF core From nuget
            //step 4: Configure database and mapp classes with tables //imp**** -> data access layer
            //step 5: data migration- each time context or entity classes are modified -> package manager console / CLI

            //step 6: Save products details into database


            //SaveProduct();
            //GetALL();
            //Delete();

            // Update();

            // ProductCategorySave();


            //add new product into existing category
            // ProductIntoExistingCategory();

            //get product name along with category name and display
            // categoryproduct();

            


            //using (ProductsDbContext db = new ProductsDbContext())
            //{
            //    //add new customer and new suplier into db

            //    var c = new Customer { Name = "Customer 1", Email = "customer1@gmail.com", Discount = 10, Mobile = "11233444", Address = new Address { Area = "A1", City = "Bangalore", Country = "India" } };

            //    var s= new Supplier { Name = "Supplier 1", Email = "supplier1@gmail.com",GSTno="33eeff44", Rating = 5, Mobile = "112334", Address = new Address { Area = "A2", City = "Delhi", Country = "India" } };
            //    db.People.Add(c);
            //    db.People.Add(s);

            //    //db.Customers.Add(c);
            //    //db.Suppliers.Add(s);

            //     db.SaveChanges();

            //    //var customer = from c1 in db.Customers
            //    //               select c1; ;

            //    //foreach (var item in customer)
            //    //{
            //    //    Console.WriteLine(item.Name);
            //    //}

            //   // var customers = db.Customers.ToList();

            //}

            using (ProductsDbContext db = new ProductsDbContext())
            {
                //var categories=db.Categories.ToList();
                //foreach (var c in categories)
                //{
                //    c.CategoryName=c.CategoryName.ToUpper();
                //}
                //db.SaveChanges();
                //bulk updates
                //use sql queries directly for multiple updates and multiple deletes
                db.Database.ExecuteSqlRaw("update categories set categoryname=Upper(CategoryName)");
            }


        }

        private static void categoryproduct()
        {
            using (ProductsDbContext db = new ProductsDbContext())
            {
                var products = from p in db.Products.Include("Category") //category id is only stored in products table and not the name thereby null reference 
                                                                         //just like joins in SQL using property names and join all tables 
                               select p;

                foreach (var item in products)
                {
                    Console.WriteLine($"{item.ProductName}\t{item.Category.CategoryName}");
                }
            }
        }

        private static void ProductIntoExistingCategory()
        {
            using (ProductsDbContext db = new ProductsDbContext())
            {
                var existingCategory = db.Categories.Find(1);//extracting the category and then adding to the new product
                var newProduct = new Product { ProductName = "Samsung galaxy S24 pro", Price = 95000, Brand = "Samsung", Category = existingCategory };
                db.Products.Add(newProduct);
                db.SaveChanges();
                //  db.Dispose();

                //dispose via runtime automatically via using() 
                //if manually then use try catch block and then write in fianlly block and stuffs
            }
        }

        private static void ProductCategorySave()
        {//add new product to the new category
            ProductsDbContext db = new ProductsDbContext();
            Product p = new Product { ProductName = "I phone 16", Price = 99000, Brand = "Apple" };
            Category c = new Category { CategoryName = "Mobiles" };
            p.Category = c;
            db.Products.Add(p);
            db.SaveChanges();
        }

        private static void Update()
        {
            //update
            ProductsDbContext db = new ProductsDbContext();
            var productToEdit = db.Products.Find(2);
            productToEdit.Price += 1000;
            db.SaveChanges();
        }

        private static void Delete()
        {

            //DELETE

            ProductsDbContext db = new ProductsDbContext();
            //Linq to entities
            var productToDelete = (from p in db.Products
                                   where p.ProductId == 1
                                   select p).FirstOrDefault();
            db.Products.Remove(productToDelete);
            db.SaveChanges();
        }

        private static void GetALL()
        {
            ProductsDbContext db = new ProductsDbContext();
            //Linq to entities
            var allproducts = from p in db.Products
                              select p;
            foreach (var product in allproducts)
            {
                Console.WriteLine($"{product.ProductId}\t{product.ProductName}\t{product.Price}\t{product.Brand}");
            }
        }

        private static void SaveProduct()
        {
            Product p = new Product();
            Console.WriteLine("enter the product name");
            p.ProductName = Console.ReadLine();
            Console.WriteLine("enter the price");
            p.Price = int.Parse(Console.ReadLine());
            Console.WriteLine("enter the brand name");
            p.Brand = Console.ReadLine();

            ProductsDbContext db = new ProductsDbContext();
            db.Products.Add(p);
            db.SaveChanges();
        }
    }
}
