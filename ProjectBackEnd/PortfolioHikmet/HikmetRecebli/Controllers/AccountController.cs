using HikmetRecebli.Data;
using HikmetRecebli.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace HikmetRecebli.Controllers
{
    public class AccountController : Controller
    {
        private readonly PortfolioDbContext _dbContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IWebHostEnvironment _env;

        public AccountController(PortfolioDbContext dbContext, 
                                UserManager<IdentityUser> userManager,
                                RoleManager<IdentityRole> roleManager,
                                SignInManager<IdentityUser>  signInManager,
                                IWebHostEnvironment env)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _env = env;
        }

        // ======================= Login ============
        // Login Get
        [HttpGet]
        public IActionResult Login(string ReturnUrl) => View(new SignInVM { ReturnUrl = string.IsNullOrEmpty(ReturnUrl)? "":ReturnUrl});
        

        // Login Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(SignInVM signIn)
        {

            if (!ModelState.IsValid) return View(signIn);
            // Check User 
            var user = await _userManager.FindByEmailAsync(signIn.Email);
            if (user == null)
            {
                ModelState.AddModelError("Email", "Email is Wrong!");
                return View(signIn);
            }
            // Check Pass 
            var resault = await _signInManager.PasswordSignInAsync(user, signIn.Password, signIn.RememberMe, false);
            
            if (resault.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: true);
                if (string.IsNullOrEmpty(signIn.ReturnUrl))
                {
                    return RedirectToAction("Index", "Portfolios");
                }
                else
                {
                    return Redirect(signIn.ReturnUrl);
                }
            }

            ModelState.AddModelError("Password", "Password Wrong!");
            return View(signIn);
        }

        [HttpGet]
        public IActionResult AccessDenied() => View("Messenge", new MessengeVM { Mesange ="Access Dinaded",PageTitle="Error 403"});

        [HttpGet]
        public async Task<IActionResult> SeedData()
        {

            string messange = "Data Already Add";
            if(await _dbContext.Users.CountAsync() == 0)
            {
                bool isAddDefaultUser = await AppDbIntailazer.SeedDefaultUserAndRoleAysnc(_userManager, _roleManager);
                if (isAddDefaultUser)
                {
                    messange = "Successfuly Data Added";
                }
                else
                {
                    messange = "Opps Something Wrong";
                }
            }
             var  msg = new MessengeVM
             {
                 PageTitle = "Seed Data",
                 Mesange = messange
             };
            return View("Messenge", msg);
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> ChangePassword() => 
            View(new ChangePasswordVM 
                { UserName = 
                    (await _userManager.FindByNameAsync(User.Identity.Name)).UserName
                });


        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordVM changePassword)
        {
            if (!ModelState.IsValid) return View(changePassword);

            // Check User 
            var user = await _userManager.FindByNameAsync(changePassword.UserName);
            if (user == null) return NotFound();

            // Ckeck Password Usable
            var passwordValidator = new PasswordValidator<IdentityUser>();
            var result = await passwordValidator.ValidateAsync(_userManager, null, changePassword.NewPassword);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("NewPassword", result.Errors.FirstOrDefault().Description);
                return View(changePassword);
            }

            var resault = await _userManager.ChangePasswordAsync(user,changePassword.OldPassword,changePassword.NewPassword);

            if (resault.Succeeded)
            {
                TempData["Messange"] = "Password Changed !";
                return RedirectToAction("Index", "Portfolios");
            }
            ModelState.AddModelError("NewPassword", "We Have Some Problem");
            return View(changePassword);
        }

    }
}
