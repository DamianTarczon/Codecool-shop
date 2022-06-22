using System;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Services;
using Microsoft.AspNetCore.Mvc;

namespace Codecool.CodecoolShop.Controllers
{
    public class OrderController : Controller
    {
        private Order _order;
        private UserData _validUserData;
        private Cart _cart;
        private OrderService OrderService { get; set; }
        private CartService CartService { get; set; }

        public OrderController()
        {
            CartService = new CartService(
                CartDao.GetInstance(),
                ProductDaoMemory.GetInstance(),
                ProductCategoryDaoMemory.GetInstance(),
                SupplierDaoMemory.GetInstance());
            OrderService = new OrderService(OrderDaoMemory.GetInstance());
            _order = new Order(DateTime.Now);
            _order.OrderedProducts = CartService.GetCart();
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult OrderDetails(int orderId)
        {
            return View(order);
        }

        [HttpPost]
        public IActionResult MakePayment(CreditCard creditCard)
        {
            if (ModelState.IsValid)
            {
                OrderService.AddOrder(_order);
                return RedirectToAction("OrderDetails", "Order", new {orderId = _order.Id});
            }
            else
            {
                return View();
            }
        }

        public IActionResult MakePayment()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UserDataDetails()
        {
            return View();

        }

        [HttpPost]
        public IActionResult UserDataDetails(UserData userData)
        {
            if (ModelState.IsValid)
            {
                _order.UserData = userData;
                return RedirectToAction("MakePayment", "Order");
            }
            else
            {
                return View();
            }
        }
    }
}
