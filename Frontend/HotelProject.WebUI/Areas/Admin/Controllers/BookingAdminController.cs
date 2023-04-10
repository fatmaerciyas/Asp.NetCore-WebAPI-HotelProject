using HotelProject.WebUI.Dtos.BookingDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BookingAdminController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        string baseUrl = "http://localhost:5181/api/Bookings";
        public BookingAdminController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = httpClientFactory.CreateClient(); //istemicl olusturulur
            var responseMessage = await client.GetAsync(baseUrl); //adrese istekte bulunur
            if (responseMessage.IsSuccessStatusCode) //adresten basarili durum kodu donerse
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); //gelen veriyi jsonData'ya atadik
                var values = JsonConvert.DeserializeObject<IEnumerable<ResultBookingDto>>(jsonData); //Json turundeki veriyi de deserialize ettik
                return View(values);
            }
            return View();
        }

        //BURASI DAHA SONRA HALLEDILECEK
        public async Task<IActionResult> ApprovedReservation(ApprovedReservationDto model)
        {
            if (!ModelState.IsValid) { return View(); }

            model.Status = "Onaylandı";
            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model); // gelen veriyi jsona cevirdik
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");// gelen veriyi turkce karakter destekleyen jsona cevirdik
            var responseMessage = await client.PutAsync(baseUrl, stringContent);
            if (responseMessage.IsSuccessStatusCode) //adresten basarili durum kodu donerse
            {
                return RedirectToAction("Index");

            }
            return View();
        }
    }
}
