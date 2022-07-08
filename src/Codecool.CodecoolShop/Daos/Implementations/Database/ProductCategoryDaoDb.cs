using System.Collections.Generic;
using System.Linq;
using Codecool.CodecoolShop.Data;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Daos.Implementations.Database
{
    public class ProductCategoryDaoDb : IProductCategoryDao
    {
        private readonly CodecoolShopContext _context;

        public ProductCategoryDaoDb(){}
        public ProductCategoryDaoDb(CodecoolShopContext context)
        {
            _context = context;
        }

        public void Add(ProductCategory productCategory)
        {
            _context.ProductCategories.Add(productCategory);
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            _context.ProductCategories.Remove(this.Get(id));
            _context.SaveChanges();
        }

        public ProductCategory Get(int id)
        {
            return _context.ProductCategories.Find(id);
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            return _context.ProductCategories.ToList();
        }
    }
}
