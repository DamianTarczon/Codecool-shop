using System.Collections.Generic;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Services
{
    public interface IProductService
    {
        public ProductCategory GetProductCategory(int categoryId);

        public IEnumerable<Product> GetProductsForCategory(int categoryId);
    }
}
