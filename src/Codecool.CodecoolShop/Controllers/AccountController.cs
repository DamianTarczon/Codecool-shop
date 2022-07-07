using System.Threading.Tasks;
using Codecool.CodecoolShop.Models;
using Codecool.CodecoolShop.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Codecool.CodecoolShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly AccountService _accountService;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, AccountService accountService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _accountService = accountService;
        }

        public async Task<IActionResult>  GetCurrentUser()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            return Ok(user);
        }

        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }

            var profileView = new ProfileView();
            profileView.User = user;
            profileView.Order = _accountService.FindUserOrders(user);
            return View(profileView);
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterDto userRegisterDto)
        {
            var newUser = new IdentityUser()
            {
                UserName = userRegisterDto.UserName,
                Email = userRegisterDto.Email,
                
            };

            var result = await _userManager.CreateAsync(newUser, userRegisterDto.Password);
            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

    
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            var foundUser = await _userManager.FindByEmailAsync(userLoginDto.Email);
            if (foundUser == null)
            {
                return NotFound();
            }

            var result = await _signInManager.PasswordSignInAsync(foundUser, userLoginDto.Password, true, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Profile", "Account");
            }

            return NotFound();

        }

        public IActionResult Login ()
        {
            return View();
        }

    }
}
