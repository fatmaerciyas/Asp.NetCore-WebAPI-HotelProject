using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Dtos.ContactDto;
using HotelProject.WebUI.Dtos.MessageCategoryDto;
using HotelProject.WebUI.Models.Room;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {

        private readonly IHttpClientFactory httpClientFactory;
        string baseUrl = "http://localhost:5181/api/Contacts";

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = httpClientFactory.CreateClient(); //istemicl olusturulur
            var responseMessage = await client.GetAsync("http://localhost:5181/api/MessageCategories"); //adrese istekte bulunur

            var jsonData = await responseMessage.Content.ReadAsStringAsync(); //gelen veriyi jsonData'ya atadik
            var values = JsonConvert.DeserializeObject<IEnumerable<ResultMessageCategory>>(jsonData); //Json turundeki veriyi de deserialize ettik

            List<SelectListItem> values2 = (from x in values
                                            select new SelectListItem
                                            {
                                                Text = x.MessageCategoryName,
                                                Value = x.MessageCategoryId.ToString()
                                            }).ToList();
            ViewBag.v = values2;

            return View();

        }

        public PartialViewResult SendMessage()
        {
            return PartialView();
        }


        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateContactDto model)
        {
            model.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model); // gelen veriyi jsona cevirdik
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");// gelen veriyi turkce karakter destekleyen jsona cevirdik
            var responseMessage = await client.PostAsync(baseUrl, stringContent);
            if (responseMessage.IsSuccessStatusCode) //adresten basarili durum kodu donerse
            {
                return RedirectToAction("Index", "Contact");

            }
            return View();
        }
    }
}
