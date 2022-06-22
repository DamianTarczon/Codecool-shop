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
        private OrderService _orderService;

        public OrderController()
        {
            _orderService = new OrderService(OrderDaoMemory.GetInstance());
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult OrderDetails(Order order)
        {
            return View(order);
        }

        [HttpPost]
        public ViewResult CreditCardDetails(CreditCard creditCard)
        {
            if (ModelState.IsValid)
            {
                _orderService.AddOrder(_order);
                return View();
            }
            else
            {
                return View();
            }
        }

        public ViewResult MakePayment()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UserDataDetails()
        {
            return View();

        }

        [HttpPost]
        public ViewResult UserDataDetails(UserData userData)
        {
            if (ModelState.IsValid)
            {
                return View(userData);
            }
            else
            {
                return View();
            }
        }
    }
}
