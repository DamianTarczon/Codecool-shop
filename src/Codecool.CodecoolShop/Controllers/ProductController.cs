using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Services;

namespace Codecool.CodecoolShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        public ProductService ProductService { get; set; }

        private CartService CartService { get; set; }

        private ViewModel ViewModel { get; set; }

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
            ProductService = new ProductService(
                ProductDaoMemory.GetInstance(),
                ProductCategoryDaoMemory.GetInstance(),
                SupplierDaoMemory.GetInstance());
            CartService = new CartService(
                CartDao.GetInstance(),
                ProductDaoMemory.GetInstance(),
                ProductCategoryDaoMemory.GetInstance(),
                SupplierDaoMemory.GetInstance());
            ViewModel = new ViewModel();
            ViewModel.ProductsInCart = CartService.GetCart();
        }

        public IActionResult Index(int id = 1, string category = "category")
        {
            if (category != "category")
            {
                var productsBySupplier = ProductService.GetProductsBySupplier(id);
                ViewModel.Products = productsBySupplier.ToList();
                return View(ViewModel);
            }
            var productsByCategory = ProductService.GetProductsForCategory(id);
            ViewModel.Products = productsByCategory.ToList();
            return View(ViewModel);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
