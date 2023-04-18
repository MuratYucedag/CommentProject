using CommentProject.EntityLayer.Concrete;
using CommentProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CommentProject.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(RegisterViewModel rvm)
        {
            var appUser = new AppUser()
            {
                Name = rvm.Name,
                Surname = rvm.Surname,
                Email = rvm.Mail,
                UserName = rvm.Username,
                Image = "test"
            };
            if (rvm.Password == rvm.ConfirmPassword)
            {
                var result = await _userManager.CreateAsync(appUser, rvm.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    foreach (var x in result.Errors)
                    {
                        ModelState.AddModelError("", x.Description);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Lütfen şifrelerinizi kontrol ediniz");
            }
            return View();
        }
    }
}