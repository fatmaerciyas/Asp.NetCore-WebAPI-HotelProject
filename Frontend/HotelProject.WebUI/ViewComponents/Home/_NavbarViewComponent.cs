using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents.Home
{
    [ViewComponent(Name = "_NavbarViewComponent")]
    public class _NavbarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
