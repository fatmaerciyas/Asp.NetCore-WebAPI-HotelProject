using HotelProject.WebUI.Models.Room;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class RoomController : Controller
    {
       
            private readonly IHttpClientFactory httpClientFactory;
            string baseUrl = "http://localhost:5181/api/Rooms";
            public RoomController(IHttpClientFactory httpClientFactory)
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
                    var values = JsonConvert.DeserializeObject<IEnumerable<RoomViewModel>>(jsonData); //Json turundeki veriyi de deserialize ettik
                    return View(values);
                }
                return View();
            }


            [HttpGet]
            public async Task<IActionResult> Add()
            {
                return View();
            }

            [HttpPost]
            public async Task<IActionResult> Add(RoomViewModel model)
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

            public async Task<IActionResult> Delete(int id)
            {
                var client = httpClientFactory.CreateClient();
                var responseMessage = await client.DeleteAsync($"http://localhost:5181/api/Rooms/{id}"); //id ye gore veri sil
                if (responseMessage.IsSuccessStatusCode) //adresten basarili durum kodu donerse
                {
                    return RedirectToAction("Index");

                }
                return View();
            }

            [HttpGet]
            public async Task<IActionResult> Update(int id)
            {
                var client = httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync($"http://localhost:5181/api/Rooms/{id}"); //id ye gore veri getir
                if (responseMessage.IsSuccessStatusCode) //adresten basarili durum kodu donerse
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<RoomViewModel>(jsonData); //sadece 1 veri gelecek Gelen json veriyi StaffViewModel'e cevir
                    return View(values);

                }
                return View();
            }


            [HttpPost]
            public async Task<IActionResult> Update(RoomViewModel model)
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
