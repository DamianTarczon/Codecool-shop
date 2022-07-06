using System.Linq;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Daos.Implementations.Database;
using Codecool.CodecoolShop.Daos.Implementations.Memory;
using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Codecool.CodecoolShop.Controllers
{
    public class CartController : Controller
    {
        private CartService CartService { get; set; }
        private ProductService ProductService { get; set; }

        private static Cart _cart { get; set; }

        public CartController()
        {
            CartService = new CartService(
                new CartDaoDb(),
                ProductDaoMemory.GetInstance(),
                ProductCategoryDaoMemory.GetInstance(),
                SupplierDaoMemory.GetInstance());
            ProductService = new ProductService(
                ProductDaoMemory.GetInstance(),
                ProductCategoryDaoMemory.GetInstance(),
                SupplierDaoMemory.GetInstance());
        }
        public IActionResult Index(string buttonType = "", int productId = 0)
        {
            if (buttonType == "delete")
            {
                CartService.RemoveProduct(productId, _cart);
            }
            else if (buttonType == "increase")
            {
                if (_cart == null)
                {
                    _cart = new Cart();
                }
                CartService.IncreaseProduct(productId, _cart);
            }
            else if (buttonType == "decrease")
            {
                CartService.DecreaseProduct(productId, _cart);
            }
            else if (buttonType == "deleteAll")
            {
                CartService.RemoveAllProducts();
                _cart = null;
            }
            var card = CartService.GetCart();
            return View(card);
        }

       /*[HttpPost]*/
        public IActionResult Add(int productId, string categoryOrSupplier)
        {
            CartService.IncreaseProduct(productId);
            int categoryId;
            int supplierId;
            if (categoryOrSupplier != "category")
            {
                supplierId = ProductService.GetProduct(productId).Supplier.Id;
                return RedirectToAction("Index", "Product", new { id = supplierId, categoryOrSupplier = categoryOrSupplier });
            } 
            else categoryId = ProductService.GetProduct(productId).ProductCategory.Id;
            return RedirectToAction("Index", "Product", new { id = categoryId, categoryOrSupplier = categoryOrSupplier });
        }
    }
}
