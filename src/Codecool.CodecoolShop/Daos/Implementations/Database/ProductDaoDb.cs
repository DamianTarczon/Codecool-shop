using System.Collections.Generic;
using System.Linq;
using Codecool.CodecoolShop.Data;
using Codecool.CodecoolShop.Models;
using Microsoft.EntityFrameworkCore;

namespace Codecool.CodecoolShop.Daos.Implementations.Database
{
    public class ProductDaoDb : IProductDao
    {
        private readonly CodecoolShopContext _context;

        public ProductDaoDb(CodecoolShopContext context)
        {
            _context = context;
        }
        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            _context.Products.Remove(this.Get(id));
            _context.SaveChanges();
        }

        public Product Get(int id)
        {
            return _context.Products.Find(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public IEnumerable<Product> GetBy(Supplier supplier)
        {
            return _context.Products.Where(x => x.SupplierId == supplier.Id)
                .Include(x => x.Supplier)
                .Include(x => x.ProductCategory);
        }

        public IEnumerable<Product> GetBy(ProductCategory productCategory)
        {
            return _context.Products.Where(x => x.ProductCategoryId == productCategory.Id)
                .Include(x => x.ProductCategory)
                .Include(x => x.Supplier);
        }
    }
}
