using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.RegisterDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {

        private readonly UserManager<AppUser> _userManager; //register islemi hangi tablo icin yapilacak AppUser icin 

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateNewUserDto model)
        {
            if (!ModelState.IsValid) { return View(); }

            var appUser = new AppUser()
            {
                Name = model.Name,
                Surname = model.Surname,
                Email = model.Mail,
                UserName = model.UserName,
               
                
            };

            appUser.City = "Default"; //City olmadan kaydetmedi o yuzden default deger atadim
            var result = await _userManager.CreateAsync(appUser,model.Password);

            if (result.Succeeded) { return RedirectToAction("Index", "Staff"); }
            return View();
        }
    }
}
