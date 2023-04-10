using HotelProject.WebUI.Dtos.AboutDto;
using HotelProject.WebUI.Dtos.SubscribeDto;
using HotelProject.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory httpClientFactory;
        string baseUrl = "http://localhost:5181/api/Subscribes";
        public HomeController(IHttpClientFactory httpClientFactory, ILogger<HomeController> logger)
        {
            this.httpClientFactory = httpClientFactory;
            _logger = logger;
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult _SubscribePartial()
        {
            return PartialView();
        }


        [HttpPost]
        public async Task<IActionResult> _SubscribePartial(CreateSubscribeDto model)
        {

            if (!ModelState.IsValid) { return View(); }

            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model); // gelen veriyi jsona cevirdik
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");// gelen veriyi turkce karakter destekleyen jsona cevirdik
            var responseMessage = await client.PostAsync(baseUrl, stringContent);
            if (responseMessage.IsSuccessStatusCode) //adresten basarili durum kodu donerse
            {
                return RedirectToAction("Index","Home");

            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}