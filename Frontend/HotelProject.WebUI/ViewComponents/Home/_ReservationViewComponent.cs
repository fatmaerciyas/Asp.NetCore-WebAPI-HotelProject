using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace HotelProject.WebUI.ViewComponents.Home
{


    [ViewComponent(Name = "_ReservationViewComponent")]
    public class _ReservationViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }


}
