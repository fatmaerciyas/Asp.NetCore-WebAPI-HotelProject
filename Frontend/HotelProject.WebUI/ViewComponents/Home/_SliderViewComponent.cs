using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace HotelProject.WebUI.ViewComponents.Home
{
    [ViewComponent(Name = "_SliderViewComponent")]
    public class _SliderViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
