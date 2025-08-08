using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Clinic_System.BLL.ModelVM;

namespace Clinic_System.PLL.Controllers
{
    [Authorize(Roles ="Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        public IActionResult AddRole()
        {
            return View("AddRole");
        }
        [HttpPost]
        public async Task <IActionResult> SaveRole(RoleVM roleVM)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole();
                role.Name = roleVM.RoleName;
                IdentityResult result= await roleManager.CreateAsync(role);
                if(result.Succeeded ==true)
                {
                    ViewBag.success=true;
                    return View("AddRole");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View("AddRole",roleVM);
        }

    }
}
