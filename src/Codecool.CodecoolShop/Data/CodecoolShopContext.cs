using Codecool.CodecoolShop.Models;
using Microsoft.EntityFrameworkCore;

namespace Codecool.CodecoolShop.Data
{
    public class CodecoolShopContext : DbContext
    {
        
        public DbSet<Supplier> Suppliers { get; set; }
    
        public DbSet<Product> Products { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }


        public CodecoolShopContext(DbContextOptions options) : base(options)
        {
                
        }
        
    }
}
