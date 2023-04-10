using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace HotelProject.WebUI.ViewComponents.Home
{

    [ViewComponent(Name = "_ScriptsViewComponent")]
    public class _ScriptsViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
   
}
