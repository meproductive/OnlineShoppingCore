using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShoppingCore.EmailService;
using OnlineShoppingCore.Identity;
using OnlineShoppingCore.Models;
using static System.Net.WebRequestMethods;

namespace OnlineShoppingCore.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _SignInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signinManager)
        {
            _userManager = userManager;
            _SignInManager = signinManager;
        }
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new ApplicationUser()
            {
                UserName = model.Username,
                Email = model.Email,
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var callbackUrl = Url.Action("ConfirmEmail", "Account", new
                {
                    userId = user.Id,
                    token = code
                });
                string siteUrl = "https://localhost:7202/";
                string activeUrl = $"{siteUrl}{callbackUrl}";

                string body = $"Merhaba {model.Username}; Hesabınızı onaylamak için <a href='{activeUrl}' target='_blank'</a> tıklayınız";
                MailHelper.SendEmail(body, model.Email, "Hesap Aktifleştirme");
                return RedirectToAction("Login");
            }
            ModelState.AddModelError("", "HATA");
            return View();
        }
        public IActionResult Login(string ReturnUrl = null)
        {
            return View(new LoginViewModel()
            {
                ReturnUrl=ReturnUrl
            });
        }
        [HttpPost]

        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);

            var useru = await _userManager.FindByNameAsync(model.Email);

            if (user == null && useru == null)
            {
                ModelState.AddModelError("", "No User Found Error");
                return View(model);
            }

            if(!await _userManager.IsEmailConfirmedAsync(user == null ? useru : user))
            {
                ModelState.AddModelError("", "Active Your Account");
                return View(model);
            }

            var result = await _SignInManager.PasswordSignInAsync(user == null ? useru : user, model.Password, true, true);

            if (result.Succeeded)
            {
                return Redirect(model.ReturnUrl??"~/");
            }

            ModelState.AddModelError("", "Email Or Password Error");
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await _SignInManager.SignOutAsync();
            return Redirect("~/");
        }
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if(userId==null || token == null)
            {
                TempData["message"] = "Invalid Token";
                return View();
            }

            var user = await _userManager.FindByIdAsync(userId);
            if(user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    TempData["message"] = "Account Approved";
                    return View();
                }
            }
            TempData["message"] = "Account is not approved";
            return View();
        }
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ForgotPassword(string Email)
        {
            return View();
        }
    }
}
