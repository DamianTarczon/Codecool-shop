using System.Collections.Generic;
using System.Linq;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Codecool.CodecoolShop.Services
{
    public class CartService
    {
        private readonly  ICartDao _cartDao;
        private readonly ProductService _productService;
        private readonly ILogger<CartService> _logger;
        private static Cart _cart = new Cart() {CartDetails = new List<CartDetail>()};

        public CartService(ICartDao cartDao, IProductDao productDao, IProductCategoryDao productCategoryDao, ISupplierDao supplierDao)
        {
            _cartDao = cartDao;
            _productService = new ProductService(productDao, productCategoryDao, supplierDao);

        }

        public void AddCart()
        {
            _cart = _cartDao.AddCart(_cart);
        }

        public void IncreaseProduct(int productId)
        {
            var productsInCart = _cart.CartDetails.Select(x => x.Product).Count();
            if (productsInCart == 0)
            {
                _cart = new Cart();
                AddCart();
            }
            var product = _productService.GetProduct(productId);
            _cartDao.IncreaseProduct(product, _cart.Id);
        }

        public Dictionary<Product,int> GetCart()
        {
            if (_cart.Id == 0)
            {
                _cart = _cartDao.AddCart(_cart);
            }
            return _cartDao.GetAll(_cart.Id);
        }

        public void RemoveProduct(int productId)
        {
            var product = _productService.GetProduct(productId);
            _cart=_cartDao.RemoveProduct(product, _cart.Id);
        }

        public void DecreaseProduct(int productId)
        {
            var product = _productService.GetProduct(productId);
            _cart = _cartDao.DecreaseProduct(product, _cart.Id);
            
        }

        public void RemoveAllProducts()
        {
            _cart = _cartDao.RemoveAllProducts(_cart.Id);
        }
    }
}
