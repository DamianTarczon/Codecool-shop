using System.Linq;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace Codecool.CodecoolShop.Controllers
{
    public class CartController : Controller
    {
        private CartService CartService { get; set; }
        private ProductService ProductService { get; set; }
        private ICartDao _cartDao = new CartDao();

        public CartController()
        {
            CartService = new CartService(
                _cartDao.GetInstance(),
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
            var Cart = CartService.GetCard();
            return View(Cart);
            /*return RedirectToAction("Index", "Cart");*/
        }
    }
}
