using Codecool.CodecoolShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace Codecool.CodecoolShop.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreditCardDetails()
        {
            return View();

        }

        [HttpPost]
        public ViewResult CreditCardDetails(CreditCard creditCard)
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            else
            {
                return View();
            }
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
