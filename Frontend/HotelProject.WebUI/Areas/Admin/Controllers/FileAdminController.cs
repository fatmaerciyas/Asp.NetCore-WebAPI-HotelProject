using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace HotelProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FileAdminController : Controller
    {
        HttpClient httpClient = new HttpClient();

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormFile file)
        {
            var stream = new MemoryStream(); //Akısı olusturduk
            await file.CopyToAsync(stream);//Doayayi kopyaladik
            var bytes = stream.ToArray();//dosyayi byte olarak tuttuk


            ByteArrayContent byteArrayContent = new ByteArrayContent(bytes);
            byteArrayContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);
            MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
            multipartFormDataContent.Add(byteArrayContent, "file", file.FileName);
            await httpClient.PostAsync("http://localhost:5181/api/FileProcess", multipartFormDataContent);


            return View();
        }
    }
}
