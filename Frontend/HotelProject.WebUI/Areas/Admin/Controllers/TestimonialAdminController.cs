using HotelProject.WebUI.Models.Testimonial;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    [Area("Admin")]
    public class TestimonialAdminController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        string baseUrl = "http://localhost:5181/api/Testimonials";
        public TestimonialAdminController(IHttpClientFactory httpClientFactory)
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
                var values = JsonConvert.DeserializeObject<IEnumerable<TestimonialViewModel>>(jsonData); //Json turundeki veriyi de deserialize ettik
                return View(values);
            }
            return View();
        }

        [Area("Admin")]
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [Area("Admin")]
        [HttpPost]
        public async Task<IActionResult> Add(TestimonialViewModel model)
        {
            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model); // gelen veriyi jsona cevirdik
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");// gelen veriyi turkce karakter destekleyen jsona cevirdik
            var responseMessage = await client.PostAsync(baseUrl, stringContent);
            if (responseMessage.IsSuccessStatusCode) //adresten basarili durum kodu donerse
            {
                return RedirectToAction("Index");

            }
            return View();
        }
        [Area("Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5181/api/Testimonials/{id}"); //id ye gore veri sil
            if (responseMessage.IsSuccessStatusCode) //adresten basarili durum kodu donerse
            {
                return RedirectToAction("Index");

            }
            return View();
        }
        [Area("Admin")]
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5181/api/Testimonials/{id}"); //id ye gore veri getir
            if (responseMessage.IsSuccessStatusCode) //adresten basarili durum kodu donerse
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<TestimonialViewModel>(jsonData); //sadece 1 veri gelecek Gelen json veriyi StaffViewModel'e cevir
                return View(values);

            }
            return View();
        }

        [Area("Admin")]
        [HttpPost]
        public async Task<IActionResult> Update(TestimonialViewModel model)
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
