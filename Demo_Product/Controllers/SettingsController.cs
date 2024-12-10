using Demo_Product.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Demo_Product.Controllers
{
    public class SettingsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public SettingsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var values = await _userManager.FindByIdAsync(userId.ToString());
            //var values = await _userManager.FindByIdAsync(User.Identity.Name);
            UserEditViewModel userEditViewModel = new UserEditViewModel();
            userEditViewModel.FirstName = values.FirstName;
            userEditViewModel.LastName = values.LastName;
            userEditViewModel.EMail = values.Email;
            //userEditViewModel.Gender = values.Gender;
            return View(userEditViewModel);
        }
    }
}
