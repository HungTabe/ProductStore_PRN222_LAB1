using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using ProductManagementMVC.Models.ViewModels;
using Services;

namespace ProductManagementMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        // GET: Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_accountService.VerifyPassword(model.EmailAddress, model.MemberPassword))
                {
                    var user = _accountService.GetAccountById(model.EmailAddress);
                    HttpContext.Session.SetString("UserId", user.MemberId);
                    HttpContext.Session.SetString("Username", user.FullName ?? user.EmailAddress);
                    return RedirectToAction("Index", "Products");
                }
                else
                {
                    ModelState.AddModelError("", "Email hoặc mật khẩu không đúng.");
                }
            }
            return View(model);
        }

        // GET: Account/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: Account/Register
        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var existingUser = _accountService.GetAccountById(model.EmailAddress);
                if (existingUser != null)
                {
                    ModelState.AddModelError("", "Email đã được sử dụng.");
                    return View(model);
                }

                var account = new AccountMember
                {
                    MemberId = Guid.NewGuid().ToString(),
                    EmailAddress = model.EmailAddress,
                    FullName = model.FullName,
                    MemberPassword = model.MemberPassword
                };
                _accountService.AddAccount(account);
                return RedirectToAction("Login");
            }
            return View(model);
        }

        // GET: Account/Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
