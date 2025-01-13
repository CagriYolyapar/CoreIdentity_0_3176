using CoreIdentity_0.Models.AppRoles.RequestModels;
using CoreIdentity_0.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CoreIdentity_0.Controllers
{
    [Authorize(Roles ="Admin")]
    public class RoleController : Controller
    {
        readonly RoleManager<AppRole> _roleManager;

        public RoleController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View(_roleManager.Roles.ToList());
        }

        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleRequestModel model)
        {
            if (ModelState.IsValid)
            {

                AppRole role = new()
                {
                    Name = model.RoleName
                };

                IdentityResult result = await _roleManager.CreateAsync(role);

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
