using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework_07.Entities;
namespace Homework_07
{
    public static class DbInitializer
    {
        public static void SeedCities(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cities>().HasData(
                new Cities { Id = 1, Name = "New York", CountryId = 1 },
                new Cities { Id = 2, Name = "Paris", CountryId = 2 },
                new Cities { Id = 3, Name = "London", CountryId = 3 }
            );
        }
        public static void SeedCountries(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Countries>().HasData(
                new Countries { Id = 1, Name = "USA" },
                new Countries { Id = 2, Name = "France" },
                new Countries { Id = 3, Name = "UK" }
            );
        }

        public static void SeedShops(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shops>().HasData(
               new Shops { Id = 1, Name = "BestMart", Address = "123 Main St", CityId = 1, ParkingAreaId = 1 ,},
               new Shops { Id = 2, Name = "SuperGoods", Address = "456 Oak Ave", CityId = 2, ParkingAreaId = 2 },
               new Shops { Id = 3, Name = "MegaMart", Address = "789 Elm Blvd", CityId = 3, ParkingAreaId = 3 }
           );
        }
        public static void SeedProducts(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>().HasData(
                new Products { Id = 1, Name = "Laptop", Price = 1000.00m, Discount = 0.05f, CategoryId = 1, Quantity = 10, IsInStock = true },
                new Products { Id = 2, Name = "Smartphone", Price = 600.00m, Discount = 0.10f, CategoryId = 1, Quantity = 20, IsInStock = true },
                new Products { Id = 3, Name = "TV", Price = 1200.00m, Discount = 0.00f, CategoryId = 2, Quantity = 5, IsInStock = false }
            );
        }

        public static void SeedWorkers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Workers>().HasData(
                new Workers { Id = 1, Name = "John", Surname = "Doe", Salary = 2000, Email = "john@example.com", PhoneNumber = "1234567890", PositionId = 1, ShopId = 1 },
                new Workers { Id = 2, Name = "Alice", Surname = "Smith", Salary = 2200, Email = "alice@example.com", PhoneNumber = "9876543210", PositionId = 2, ShopId = 2 },
                new Workers { Id = 3, Name = "Bob", Surname = "Johnson", Salary = 1800, Email = "bob@example.com", PhoneNumber = "5555555555", PositionId = 3, ShopId = 3 }
            );
        }
        public static void SeedPositions(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Positions>().HasData(
                new Positions { Id = 1, Name = "Manager" },
                new Positions { Id = 2, Name = "Salesperson" },
                new Positions { Id = 3, Name = "Cashier" }
            );
        }

        public static void SeedCategories(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>().HasData(
                new Categories { Id = 1, Name = "Electronics" },
                new Categories { Id = 2, Name = "Appliances" },
                new Categories { Id = 3, Name = "Clothing" }
            );
        }

  
       

    }
}
