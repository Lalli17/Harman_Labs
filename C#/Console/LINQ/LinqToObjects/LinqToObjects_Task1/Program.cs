namespace LinqToObjects_Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
                List<Product> products = ProductsDB.GetProducts();

                // 1. List all products whose price is between 50K to 80K
                var productsBetween50And80K = products
                    .Where(p => p.Price >= 50000 && p.Price <= 80000);
                Console.WriteLine("1.Products between 50K and 80K:");
                foreach (var product in productsBetween50And80K)
                {
                    Console.WriteLine($"- {product.Name}, Price: {product.Price}");
                }
                Console.WriteLine();

                // 2. Extract all products belonging to Laptops category
                var laptops = products.Where(p => p.Catagory.Name == "Laptops");
                Console.WriteLine("2.Laptops:");
                foreach (var laptop in laptops)
                {
                    Console.WriteLine($"- {laptop.Name}");
                }
                Console.WriteLine();

                // 3. Extract/Show Product Name and Category Name only
                var productNamesAndCategories = products
                    .Select(p => new { ProductName = p.Name, CategoryName = p.Catagory.Name });
                Console.WriteLine("3.Product Name and Category Name:");
                foreach (var item in productNamesAndCategories)
                {
                    Console.WriteLine($"- {item.ProductName}, Category: {item.CategoryName}");
                }
                Console.WriteLine();

                // 4. Show the costliest product name
                var costliestProduct = products.OrderByDescending(p => p.Price).First();
                Console.WriteLine($"4.Costliest product: {costliestProduct.Name}");
                Console.WriteLine();

                // 5. Show the cheapest product name and its price
                var cheapestProduct = products.OrderBy(p => p.Price).First();
                Console.WriteLine($"5.Cheapest product: {cheapestProduct.Name}, Price: {cheapestProduct.Price}");
                Console.WriteLine();

                // 6. Show the 2nd and 3rd product details
                var secondAndThirdProducts = products.Skip(1).Take(2);
                Console.WriteLine("6. 2nd and 3rd product details:");
                foreach (var product in secondAndThirdProducts)
                {
                    Console.WriteLine($"- {product.Name}, Price: {product.Price}, Category: {product.Catagory.Name}");
                }
                Console.WriteLine();

                // 7. List all products in ascending order of their price
                var productsAscendingOrder = products.OrderBy(p => p.Price);
                Console.WriteLine("7. Products in ascending order of price:");
                foreach (var product in productsAscendingOrder)
                {
                    Console.WriteLine($"- {product.Name}, Price: {product.Price}");
                }
                Console.WriteLine();

                // 8. Count the number of products belonging to Tablets
                var tabletsCount = products.Count(p => p.Catagory.Name == "Tablets");
                Console.WriteLine($"8. Number of products belonging to Tablets: {tabletsCount}");
                Console.WriteLine();

                // 9. Show which category has the costliest product
                var categoryWithCostliestProduct = products
                    .GroupBy(p => p.Catagory.Name)
                    .OrderByDescending(g => g.Max(p => p.Price))
                    .First().Key;
                Console.WriteLine($"9. Category with the costliest product: {categoryWithCostliestProduct}");
                Console.WriteLine();

                // 10. Show which category has fewer products
                var categoryWithLessProducts = products
                    .GroupBy(p => p.Catagory.Name)
                    .OrderBy(g => g.Count())
                    .First().Key;
                Console.WriteLine($"10. Category with fewer products: {categoryWithLessProducts}");
                Console.WriteLine();

                // 11. Extract the Product Details based on the category and show as below
                Console.WriteLine("11. Product Details based on the category:");
                var groupedProducts = products.GroupBy(p => p.Catagory.Name);
                foreach (var group in groupedProducts)
                {
                    Console.WriteLine($"{group.Key}");
                    foreach (var product in group)
                    {
                        Console.WriteLine($"\t{product.Name}");
                    }
                }
                Console.WriteLine();

                // 12. Extract the Product count based on the category and show as below
                Console.WriteLine("12. Product count based on the category:");
                var productCountByCategory = products
                    .GroupBy(p => p.Catagory.Name)
                    .Select(g => new { Category = g.Key, Count = g.Count() });
                foreach (var item in productCountByCategory)
                {
                    Console.WriteLine($"{item.Category} : {item.Count}");
                }
            }
        }

        class ProductsDB
        {
            public static List<Product> GetProducts()
            {
                Category cat1 = new Category { CatagoryID = 101, Name = "Laptops" };
                Category cat2 = new Category { CatagoryID = 201, Name = "Mobiles" };
                Category cat3 = new Category { CatagoryID = 301, Name = "Tablets" };

                Product p1 = new Product { ProductID = 1, Name = "Dell XPS 13", Catagory = cat1, Price = 90000 };
                Product p2 = new Product { ProductID = 2, Name = "HP 430", Catagory = cat1, Price = 50000 };
                Product p3 = new Product { ProductID = 3, Name = "IPhone 6", Catagory = cat2, Price = 80000 };
                Product p4 = new Product { ProductID = 4, Name = "Galaxy S6", Catagory = cat2, Price = 74000 };
                Product p5 = new Product { ProductID = 5, Name = "IPad Pro", Catagory = cat3, Price = 44000 };

                cat1.Products.Add(p1);
                cat1.Products.Add(p2);
                cat2.Products.Add(p3);
                cat2.Products.Add(p4);
                cat3.Products.Add(p5);

                List<Product> products = new List<Product>();
                products.Add(p1);
                products.Add(p2);
                products.Add(p3);
                products.Add(p4);
                products.Add(p5);

                return products;
            }
        }

        class Product
        {
            public int ProductID { get; set; }
            public string Name { get; set; }
            public int Price { get; set; }
            public Category Catagory { get; set; }
        }

        class Category
        {
            public int CatagoryID { get; set; }
            public string Name { get; set; }
            public List<Product> Products { get; } = new List<Product>();
        }
    }

