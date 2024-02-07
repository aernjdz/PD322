using System;
using System.Collections.Generic;
using System.Linq;
namespace Ho_ework_17
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Category> categories = new List<Category>
            {
            new Category { Name = "Electronics" },
            new Category { Name = "Clothing" },
            new Category { Name = "Food" }
            };
            List<Product> products = new List<Product>
            {
            new Product { Name = "TV", Price = 1500, ManufactureDate = new DateTime(2023, 1, 15), Country = "USA", Category = categories[0] },
            new Product { Name = "Shirt", Price = 50, ManufactureDate = new DateTime(2022, 5, 20), Country = "China", Category = categories[1] },
            new Product { Name = "Apple", Price = 1, ManufactureDate = new DateTime(2024, 3, 10), Country = "Ukraine", Category = categories[2] },
            new Product { Name = "Smartphone", Price = 1000, ManufactureDate = new DateTime(2023, 8, 5), Country = "South Korea", Category = categories[0] },
            new Product { Name = "Trousers", Price = 70, ManufactureDate = new DateTime(2022, 7, 30), Country = "Vietnam", Category = categories[1] },
            new Product { Name = "Banana", Price = 0.5m, ManufactureDate = new DateTime(2024, 4, 25), Country = "Ecuador", Category = categories[2] }
            };

            var currentYearProducts = products.Where(p => p.ManufactureDate.Year == DateTime.Now.Year).OrderByDescending(p => p.Price);
            Console.WriteLine("Task 1 ::");
            foreach (var product in currentYearProducts)
            {
                Console.WriteLine($"{product.Name} - {product.Price}");
            }

            string selectedCountry = "Ukraine";
            var productsCountByCountry = products.Count(p => p.Country == selectedCountry);
            Console.WriteLine($"\nTask 2 ::\nNumber of products manufactured in {selectedCountry}: {productsCountByCountry}");


            string selectedCategoryName = "Electronics";
            var selectedCategory = categories.FirstOrDefault(c => c.Name == selectedCategoryName);
            if (selectedCategory != null)
            {
                var maxPriceProduct = products.Where(p => p.Category == selectedCategory).OrderByDescending(p => p.Price).FirstOrDefault();
                var minPriceProduct = products.Where(p => p.Category == selectedCategory).OrderBy(p => p.Price).FirstOrDefault();
                Console.WriteLine($"\nTask 3 ::\nMost expensive product in {selectedCategoryName}: {maxPriceProduct.Name} ({maxPriceProduct.Price})");
                Console.WriteLine($"Cheapest product in {selectedCategoryName}: {minPriceProduct.Name} ({minPriceProduct.Price})");
            }

            var categoriesNotMadeInUkraine = products.Select(p => p.Category.Name).Distinct().Where(categoryName => !products.Any(p => p.Country == "Ukraine" && p.Category.Name == categoryName));
            Console.WriteLine("\nTask 4 ::\nCategories whose products are not manufactured in Ukraine:");
            foreach (var categoryName in categoriesNotMadeInUkraine)
            {
                Console.WriteLine(categoryName);
            }

            var productsCountByCategory = products.GroupBy(p => p.Category.Name).Select(group => new { Category = group.Key, Count = group.Count() });
            Console.WriteLine("\nTask 5 ::\n Number of products in each category:");
            foreach (var item in productsCountByCategory)
            {
                Console.WriteLine($"{item.Category}: {item.Count}");
            }

            var productsGroupedByCategory = products.OrderBy(p => p.ManufactureDate).GroupBy(p => p.Category.Name).Select(group => new { Category = group.Key, Products = group });
            Console.WriteLine("\nTask 6 ::\nProducts grouped by category, sorted by manufacture date:");
            foreach (var categoryGroup in productsGroupedByCategory)
            {
                Console.WriteLine($"{categoryGroup.Category}:");
                foreach (var product in categoryGroup.Products)
                {
                    Console.WriteLine($"   {product.Name} - {product.ManufactureDate}");
                }
            }
        }
    }
}
