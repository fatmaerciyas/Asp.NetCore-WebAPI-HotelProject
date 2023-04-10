using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileProcessController : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> UploadFile([FromForm] IFormFile file)
        {
            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);//Dosyanin adi benzersiz olsun
            var path = Path.Combine(Directory.GetCurrentDirectory(), "files/" + fileName);//bu verdigim yola kaydet
            var stream = new FileStream(path, FileMode.Create); // dosya yolu ve dosyayi olusturma modu
            await file.CopyToAsync(stream);

            return Created("", file);

        }
    }
}
