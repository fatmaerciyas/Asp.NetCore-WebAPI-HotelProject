using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace HotelProject.WebUI.ViewComponents.Home
{

    [ViewComponent(Name = "_FooterViewComponent")]
    public class _FooterViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }


}
