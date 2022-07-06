using System;
using Codecool.CodecoolShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Codecool.CodecoolShop.Data
{
    public class CodecoolShopContext : DbContext
    {
        private const string ConnectionString = "Data Source=localhost;Database=codecoolshop;Integrated Security=true";
        public DbSet<Supplier> Suppliers { get; set; }
    
        public DbSet<Product> Products { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }


        public CodecoolShopContext(DbContextOptions options) : base(options)
        {
                
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(ConnectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging();
            }
            
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Supplier amazon = new Supplier { Id = 1, Name = "Amazon", Description = "Digital content and services" };
            Supplier apple = new Supplier() { Id = 2, Name = "Apple", Description = "Digital content" };
            Supplier xiaomi = new Supplier() { Id = 3, Name = "Xiaomi", Description = "Digital content" };
            Supplier garmin = new Supplier() { Id = 4, Name = "Garmin", Description = "Electronics watches" };
            Supplier lenovo = new Supplier() { Id = 5, Name = "Lenovo", Description = "Computers" };

            ProductCategory tablet = new ProductCategory { Id = 1, Name = "Tablet", Department = "Hardware", Description = "A tablet computer, commonly shortened to tablet, is a thin, flat mobile computer with a touchscreen display." };
            ProductCategory smartphone = new ProductCategory { Id = 2, Name = "Smartphone", Department = "Hardware", Description = "A mobile phone that is smart" };
            ProductCategory smartwatch = new ProductCategory { Id = 3, Name = "Smartwatch", Department = "Luxury goods", Description = "A watch with smart functions" };

            Product amazonFire = new Product
            {
                Id = 1,
                Name = "Amazon Fire",
                DefaultPrice = 49.9m,
                Currency = "USD",
                Description =
                    "Fantastic price. Large content ecosystem. Good parental controls. Helpful technical support.",
                ProductCategoryId = tablet.Id,
                SupplierId = amazon.Id
            };
            Product lenovoIdeapad = new Product
            {
                Id = 2,
                Name = "Lenovo IdeaPad Miix 700",
                DefaultPrice = 479.0m,
                Currency = "USD",
                Description =
                    "Keyboard cover is included. Fanless Core m5 processor. Full-size USB ports. Adjustable kickstand.",
                ProductCategoryId = tablet.Id,
                SupplierId = lenovo.Id
            };
            Product amazonFireHD = new Product
            {
                Id = 3,
                Name = "Amazon Fire HD 8",
                DefaultPrice = 89.0m,
                Currency = "USD",
                Description = "Amazon's latest Fire HD 8 tablet is a great value for media consumption.",
                ProductCategoryId = tablet.Id,
                SupplierId = amazon.Id
            };
            Product iphone10 = new Product
            {
                Id = 4,
                Name = "iPhone 10",
                DefaultPrice = 500.9m,
                Currency = "USD",
                Description = "Fantasic mobile phone",
                ProductCategoryId = smartphone.Id,
                SupplierId = apple.Id
            };
            Product iphone8 = new Product
            {
                Id = 5,
                Name = "iPhone 8",
                DefaultPrice = 500.9m,
                Currency = "USD",
                Description = "Good enough",
                ProductCategoryId = smartphone.Id,
                SupplierId = apple.Id
            };
            Product XiaomiRedmi2 = new Product
            {
                Id = 6,
                Name = "Xiaomi Redmi 2",
                DefaultPrice = 50.9m,
                Currency = "USD",
                Description = "Fantasic smartwatch with good price",
                ProductCategoryId = smartphone.Id,
                SupplierId = xiaomi.Id
            };
            Product GraminFenix5 = new Product
            {
                Id = 7,
                Name = "Garmin Fenix 5",
                DefaultPrice = 60.9m,
                Currency = "USD",
                Description = "Smartwatch with a lot of functions",
                ProductCategoryId = smartwatch.Id,
                SupplierId = garmin.Id
            };
            Product XiaomiMiBand6 = new Product
            {
                Id = 8,
                Name = "Xiaomi Mi Band 6",
                DefaultPrice = 70.9m,
                Currency = "USD",
                Description = "The best smartwatch",
                ProductCategoryId = smartwatch.Id,
                SupplierId = xiaomi.Id
            };


            modelBuilder.Entity<Supplier>().ToTable("Suppliers");
            modelBuilder.Entity<Supplier>().HasData(
                    amazon,
                    apple,
                    xiaomi,
                    garmin,
                    lenovo
            );

            modelBuilder.Entity<ProductCategory>().ToTable("ProductCategories");
            modelBuilder.Entity<ProductCategory>().HasData(
                    tablet,
                    smartphone,
                    smartwatch
                );


            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Product>().HasData(
                amazonFire,
                lenovoIdeapad,
                amazonFireHD,
                iphone10,
                iphone8,
                XiaomiRedmi2,
                GraminFenix5,
                XiaomiMiBand6
            );
            /*modelBuilder.Entity<Cart>().*/
        }
    }
}
