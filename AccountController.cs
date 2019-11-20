using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FanCentral2.Data;
using FanCentral2.Models;
using FanCentral2.Models.ViewModels;
using FanCentral2.Models.Infrastructure;

namespace FanCentral2.Controllers
{
    public class AccountController : Controller
    {
     private readonly ApplicationDBContext _context;

        public AccountController(ApplicationDBContext context)
        {
            _context = context;
        }

        private readonly SignInManager<IdentityUser>signInManager;

        public AccountController(SignInManager<IdentityUser>signInManager)
        {
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password,
                                            model.RememberMe, false);

            if(result.Succeeded)
            {
                return RedirectToAction("index", "home");
            }
            ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }
            return View(model);
        }
    }

}
    