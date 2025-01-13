using System.Diagnostics;
using CoreIdentity_0.Models;
using CoreIdentity_0.Models.AppUsers.RequestModels;
using CoreIdentity_0.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreIdentity_0.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //Identity Kütüphanesi crud ve servis işlemleri icin bir takım class'lara sahiptir....BU Manager class'ları sizin ilgili Identity yapılarınızın crud işlemlerine ve baska business logic işlemlerine girmesini saglarlar...

        readonly UserManager<AppUser> _userManager;
        readonly RoleManager<AppRole> _roleManager;
        readonly SignInManager<AppUser> _signInManager;

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager)
        {
            _logger = logger;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //Bizim işlemlerimiz

        //Register'da yapmak istedigimiz şey kullanıcı eklemek (Create)
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterRequestModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new()
                {
                    UserName = model.UserName,
                    Email = model.Email,
                };

                //Eger Task halindeki awaitable metotlar geriye deger döndürüyorsa (Bir Task'in deger döndürdügünü onun generic olup olmamasından cıkarırsınız...Eger Task generic degilse geriye deger döndürmüyordur sadece awaitable'dir...Eger generic ise awaitable'dir ve geriye deger döndürüyordur...

                IdentityResult result = await _userManager.CreateAsync(appUser, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }
    }
}
