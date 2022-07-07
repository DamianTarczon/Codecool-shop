using System;
using System.Linq;
using System.Threading.Tasks;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Daos.Implementations.Database;
using Codecool.CodecoolShop.Daos.Implementations.Memory;
using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Codecool.CodecoolShop.Controllers
{
    public class OrderController : Controller
    {
        private static Order _order;
        private OrderService OrderService { get; set; }
        private CartService CartService { get; set; }
        private readonly UserManager<IdentityUser> _userManager;

        public OrderController(OrderService orderService, CartService cartService, UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            CartService = cartService;
            OrderService = orderService;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult OrderDetails(int orderId)
        {
            Order order = OrderService.GetOrder(orderId);
            return View(order);
        }

        [HttpPost]
        public async Task<ActionResult> MakePayment(CreditCard creditCard)
        {
            if (ModelState.IsValid)
            {
                _order.PaymentStatus = PaymentStatusEnum.Paid;
                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    _order.UserEmail = user.Email;
                }
                OrderService.UpdateOrder(_order);
                OrderService.SaveToJson(_order);
                MailService.MailSender(_order);
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
                _order = OrderService.MakeNewOrder(userData, CartService.GetCart());
                _order = OrderService.AddOrder(_order);
                OrderService.SaveToJson(_order);
                return RedirectToAction("MakePayment", "Order");
            }
            else
            {
                return View();
            }
        }
    }
}
