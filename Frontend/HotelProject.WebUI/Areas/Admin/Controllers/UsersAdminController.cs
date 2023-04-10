using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersAdminController : Controller
    {

        private readonly UserManager<AppUser> userManager;

        public UsersAdminController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            var values = userManager.Users.ToList();
            return View(values);
        }
    }
}
