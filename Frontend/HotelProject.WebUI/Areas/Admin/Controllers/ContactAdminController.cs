using HotelProject.WebUI.Dtos.ContactDto;
using HotelProject.WebUI.Dtos.SendMessageDto;
using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactAdminController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        string baseUrl = "http://localhost:5181/api/Contacts";
        public ContactAdminController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Inbox()
        {
            var client = httpClientFactory.CreateClient(); //istemicl olusturulur
            var responseMessage = await client.GetAsync(baseUrl); //adrese istekte bulunur

            //GELEN MESAJ SAYISINI GETIRMEK İCİN
            var client2 = httpClientFactory.CreateClient(); //istemicl olusturulur
            var responseMessage2 = await client2.GetAsync("http://localhost:5181/api/Contacts/GetContactCount"); //adrese istekte bulunur 

            //GIDEN MESAJ SAYISINI GETIRMEK ICIN
            var client3 = httpClientFactory.CreateClient(); //istemicl olusturulur
            var responseMessage3 = await client3.GetAsync("http://localhost:5181/api/SendMessages/GetSendMessageCount"); //adrese istekte bulunur 

            if (responseMessage.IsSuccessStatusCode && responseMessage2.IsSuccessStatusCode && responseMessage3.IsSuccessStatusCode) //adresten basarili durum kodu donerse
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); //gelen veriyi jsonData'ya atadik
                var values = JsonConvert.DeserializeObject<IEnumerable<ResultContactDto>>(jsonData); //Json turundeki veriyi de deserialize ettik

                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync(); //gelen veriyi jsonData'ya atadik
                ViewBag.contactCount = jsonData2;


                var jsonData3 = await responseMessage.Content.ReadAsStringAsync(); //gelen veriyi jsonData'ya atadik
                ViewBag.senMessageCount = jsonData3;


                return View(values);


            }

            return View();

        }

        public async Task<IActionResult> Sendbox()
        {
            var client = httpClientFactory.CreateClient(); //istemicl olusturulur
            var responseMessage = await client.GetAsync("http://localhost:5181/api/SendMessages"); //adrese istekte bulunur
            if (responseMessage.IsSuccessStatusCode) //adresten basarili durum kodu donerse
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); //gelen veriyi jsonData'ya atadik
                var values = JsonConvert.DeserializeObject<IEnumerable<ResultSendMessage>>(jsonData); //Json turundeki veriyi de deserialize ettik
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddSendMessage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSendMessage(CreateSendMessage model)
        {
            model.SenderMail = "admin@gmail.com";
            model.SenderName = "Admin";
            model.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            var client = httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(model); // gelen veriyi jsona cevirdik
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");// gelen veriyi turkce karakter destekleyen jsona cevirdik
            var responseMessage = await client.PostAsync("http://localhost:5181/api/SendMessages", stringContent);
            if (responseMessage.IsSuccessStatusCode) //adresten basarili durum kodu donerse
            {
                return RedirectToAction("Inbox", "Admin/ContactAdmin");   // BURAYA BAK AREA YA YONLENDİRMİYOR
            }
            return View();
        }


        public PartialViewResult SideBarAdminContactPartial()
        {
            return PartialView();
        }


        public PartialViewResult SideBarAdminContactCategoryPartial()
        {
            return PartialView();
        }


        public async Task<IActionResult> MessageDetails(int id)
        {

            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5181/api/SendMessages/{id}"); //id ye gore veri getir
            if (responseMessage.IsSuccessStatusCode) //adresten basarili durum kodu donerse
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetMessageByIdDto>(jsonData); //sadece 1 veri gelecek Gelen json veriyi StaffViewModel'e cevir
                return View(values);

            }
            return View();

        }

        public async Task<IActionResult> MessageDetailsByInbox(int id)
        {

            var client = httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5181/api/Contacts/{id}"); //id ye gore veri getir
            if (responseMessage.IsSuccessStatusCode) //adresten basarili durum kodu donerse
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultContactDto>(jsonData); //sadece 1 veri gelecek Gelen json veriyi StaffViewModel'e cevir
                return View(values);

            }
            return View();

        }
    }
}