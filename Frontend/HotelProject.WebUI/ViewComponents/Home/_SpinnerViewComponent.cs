using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents.Home
{
    [ViewComponent(Name = "_SpinnerViewComponent")]
    public class _SpinnerViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
