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
            var card = new CartDao().GetAll();
            return View(card);
        }

       /*[HttpPost]*/
        public IActionResult Add(int productId)
        {
            CartService.AddProduct(productId);
            var categoryId = ProductService.GetProduct(productId).ProductCategory.Id;
            /*return View(Cart);*/
            return RedirectToAction("Index", "Product", new {id = categoryId, category = "category"});
        }
    }
}
