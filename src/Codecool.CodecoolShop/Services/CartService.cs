using System.Collections.Generic;
using System.Linq;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Services
{
    public class CartService
    {
        private readonly  ICartDao _cartDao;
        private readonly ProductService _productService;

        public CartService(ICartDao cartDao, IProductDao productDao, IProductCategoryDao productCategoryDao, ISupplierDao supplierDao)
        {
            _cartDao = cartDao;
            _productService = new ProductService(productDao, productCategoryDao, supplierDao);

        }

        public void AddProduct(int productId)
        {
            var card = _cartDao.GetInstance();
            var product = _productService.GetProduct(productId);
            card.AddProduct(product);
        }

        public Dictionary<Product,int> GetCard()
        {
            var card = _cartDao.GetInstance();
            return card.GetAll();
        }
    }
}
