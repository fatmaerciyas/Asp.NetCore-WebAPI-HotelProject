using HotelProject.WebUI.Dtos.AboutDto;
using HotelProject.WebUI.Dtos.ServiceDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Xml.Linq;

namespace HotelProject.WebUI.ViewComponents.Home
{

    [ViewComponent(Name = "_ServiceViewComponent")]
    public class _ServiceViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory httpClientFactory;
        string baseUrl = "http://localhost:5181/api/Services";
        public _ServiceViewComponent(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var client = httpClientFactory.CreateClient(); //istemicl olusturulur
            var responseMessage = await client.GetAsync(baseUrl); //adrese istekte bulunur
            if (responseMessage.IsSuccessStatusCode) //adresten basarili durum kodu donerse
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); //gelen veriyi jsonData'ya atadik
                var values = JsonConvert.DeserializeObject<IEnumerable<ResultServiceDto>>(jsonData); //Json turundeki veriyi de deserialize ettik
                return View(values);
            }
            return View();
        }
    }
   
}
