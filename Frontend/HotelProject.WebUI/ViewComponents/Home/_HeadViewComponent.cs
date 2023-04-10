using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;


namespace HotelProject.WebUI.ViewComponents.Home
{
    [ViewComponent(Name = "_HeadViewComponent")]
    public class _HeadViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}
