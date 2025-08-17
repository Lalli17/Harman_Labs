using EFDbFirstApproachDemo.Models;

namespace EFDbFirstApproachDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            // Scaffold-DbContext "Data Source=(localdb)\mssqllocaldb;Initial Catalog=HarmansCoolProducts2025;Integrated Security=True;Pooling=False;Encrypt=True;Trust Server Certificate=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

            // add new product



            using (HarmansCoolProducts2025Context db = new HarmansCoolProducts2025Context())
            {
                var p = new Product { Name = "Hormans Speaker 2025", Brand = "Harman", Category = "Music System", InStock = true, Price = 76000 };

                db.Products.Add(p);
                db.SaveChanges();
            }

        }
    }
}
