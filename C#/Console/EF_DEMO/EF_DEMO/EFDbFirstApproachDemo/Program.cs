using EFDbFirstApproachDemo.Models;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EFDbFirstApproachDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Scaffold-DbContext "Data Source=(localdb)\mssqllocaldb;Initial Catalog=EfNewTable;Integrated Security=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

            // add new product

            using (EfNewTableContext db = new EfNewTableContext())
            {

               var p = new Product { Name = "Harmans Speaker 2025", Brand = "Harman", Category = "Music System", InStock = true, Price = 7600 };
                db.Products.Add(p);
                db.SaveChanges();
            }
        }
    }
}
