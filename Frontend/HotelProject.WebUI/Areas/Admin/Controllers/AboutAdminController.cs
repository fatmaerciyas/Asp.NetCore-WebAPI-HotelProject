using HotelProject.WebUI.Dtos.AboutDto;
using HotelProject.WebUI.Dtos.LoginDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutAdminController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        string baseUrl = "http://localhost:5181/api/Abouts";
        public AboutAdminController(IHttpClientFactory httpClientFactory)
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
                var values = JsonConvert.DeserializeObject<IEnumerable<ResultAboutDto>>(jsonData); //Json turundeki veriyi de deserialize ettik
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateAbout(int id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5181/api/Abouts/{id}"); //id ye gore veri getir
            if (responseMessage.IsSuccessStatusCode) //adresten basarili durum kodu donerse
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateAboutDto>(jsonData); //sadece 1 veri gelecek Gelen json veriyi UpdateAboutDto'e cevir
                return View(values);

            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto model)
        {
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
