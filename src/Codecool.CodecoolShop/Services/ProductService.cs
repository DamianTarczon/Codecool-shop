using System.Collections.Generic;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Services
{
    public class ProductService
    {
        private readonly IProductDao productDao;
        private readonly IProductCategoryDao productCategoryDao;
        private readonly ISupplierDao supplierDao;

        public ProductService(IProductDao productDao, IProductCategoryDao productCategoryDao, ISupplierDao supplierDao)
        {
            this.productDao = productDao;
            this.productCategoryDao = productCategoryDao;
            this.supplierDao = supplierDao;
        }

        public IEnumerable<Product> GetProductsForCategory(int categoryId)
        {
            ProductCategory category = this.productCategoryDao.Get(categoryId);
            return this.productDao.GetBy(category);
        }

        public IEnumerable<Product> GetProductsBySupplier(int supplierId)
        {
            Supplier supplier = this.supplierDao.Get(supplierId);
            return this.productDao.GetBy(supplier);
        }

        public Product GetProduct(int productID)
        {
            return productDao.Get(productID);
        }

        public Product GetProductWithCategoryAndSupplier(int productId)
        {
            return productDao.GetWithCategoryAndSupplier(productId);
        }
    }
}
