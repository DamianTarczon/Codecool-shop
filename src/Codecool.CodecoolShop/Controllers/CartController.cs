using System.Linq;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace Codecool.CodecoolShop.Controllers
{
    public class CartController : Controller
    {
        private CartService CartService { get; set; }
        private ProductService ProductService { get; set; }

        public CartController()
        {
            CartService = new CartService(
                CartDao.GetInstance(),
                ProductDaoMemory.GetInstance(),
                ProductCategoryDaoMemory.GetInstance(),
                SupplierDaoMemory.GetInstance());
            ProductService = new ProductService(
                ProductDaoMemory.GetInstance(),
                ProductCategoryDaoMemory.GetInstance(),
                SupplierDaoMemory.GetInstance());
        }
        public IActionResult Index()
        {
            var card = CartService.GetCart();
            return View(card);
        }

       /*[HttpPost]*/
        public IActionResult Add(int productId, string categoryOrSupplier)
        {
            CartService.AddProduct(productId);
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
