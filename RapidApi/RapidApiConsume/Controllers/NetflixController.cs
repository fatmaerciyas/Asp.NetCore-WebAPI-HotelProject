using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiConsume.Models;

namespace RapidApiConsume.Controllers
{
    public class NetflixController : Controller
    {
        public async Task<IActionResult> Index()
        {
          
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb8.p.rapidapi.com/auto-complete?q=game%20of%20thr"),
                Headers =
    {
        { "X-RapidAPI-Key", "f0abe106ccmsh50a997067495d78p1fc2aajsn9fe122ebb39e" }, // Key
        { "X-RapidAPI-Host", "imdb8.p.rapidapi.com" }, // Host
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<NetflixMovieViewModel>(body); //gelen Json veriyi gosterebilmek icin deserialize ettik
                return View(values.d.ToList());
            }
            return View();
        }
    }
}
