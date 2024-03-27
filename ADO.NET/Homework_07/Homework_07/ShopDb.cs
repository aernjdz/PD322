using Homework_07.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_07
{
    public class ShopDb : DbContext
    {
        public ShopDb()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(@"data source=LAPTOP-SME2AMSS\SQLEXPRESS;
                                    initial catalog=shopDB;
                                    integrated security=True;
                                    Connect Timeout = 2;
                                    Encrypt = False;
                                    Trust Server Certificate = False;
                                    Application Intent = ReadWrite;
                                    Multi Subnet Failover = False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Initializator - Seeder
            //Fluent API configuration

            modelBuilder.Entity<Cities>()
                .Property(c => c.Name)
                .HasMaxLength(50);

            modelBuilder.Entity<Cities>()
                .HasOne(c => c.Countries)
                .WithMany(c => c.Cities)
                .HasForeignKey(k => k.CountryId);

            modelBuilder.Entity<Countries>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Countries>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Countries>()
                .HasMany(c => c.Cities)
                .WithOne(city => city.Countries)
                .HasForeignKey(c => c.CountryId);

            modelBuilder.Entity<Categories>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Categories>()
                .Property(c => c.Name)
                .HasMaxLength(50);

            modelBuilder.Entity<Categories>()
                .HasIndex(c => c.Name)
                .IsUnique();

            modelBuilder.Entity<Positions>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Positions>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Positions>()
                .HasMany(p => p.Workers)
                .WithOne(w => w.Positions)
                .HasForeignKey(p => p.PositionId);

            modelBuilder.Entity<Workers>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Workers>()
                .Property(w => w.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Workers>()
                .HasOne(w => w.Positions)
                .WithMany(p => p.Workers)
                .HasForeignKey(w => w.PositionId);

            modelBuilder.Entity<Workers>()
                .HasOne(w => w.Shops)
                .WithMany(s => s.Workers)
                .HasForeignKey(w => w.ShopId);

            modelBuilder.Entity<Products>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Products>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Products>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Products>()
                .Property(p => p.Discount)
                .HasColumnType("float");

            modelBuilder.Entity<Products>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(c => c.CategoryId);




            modelBuilder.Entity<Shops>()
                  .HasKey(s => s.Id);

            modelBuilder.Entity<Shops>()
                .Property(s => s.Name)
                .IsRequired();

            modelBuilder.Entity<Shops>()
                .Property(s => s.Address)
                .IsRequired();

            modelBuilder.Entity<Shops>()
                .HasOne(s => s.City)
                .WithMany(c => c.Shops)
                .HasForeignKey(s => s.CityId);

            modelBuilder.Entity<Shops>()
                .HasOne(s => s.ParkingArea)  
                .WithMany()  
                .HasForeignKey(s => s.ParkingAreaId);

            modelBuilder.SeedCountries();
            modelBuilder.SeedCities();
            modelBuilder.SeedCategories();
            modelBuilder.SeedProducts();
            modelBuilder.SeedShops();
            modelBuilder.SeedPositions();
            modelBuilder.SeedWorkers();

        }
        public DbSet<Workers> Workers { get; set; }
        public DbSet<Shops> Shops { get; set; }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<Countries> Countries { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Positions> Positions { get; set; }
    }
}
