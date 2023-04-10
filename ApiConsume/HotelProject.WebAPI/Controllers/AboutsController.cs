using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {

        private readonly IAboutService AboutService;

        public AboutsController(IAboutService AboutService)
        {
            this.AboutService = AboutService;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await AboutService.GetListAllAsync();
            return Ok(values);

        }

        [HttpPost]
        public async Task<IActionResult> Add(About About)
        {
            AboutService.TAdd(About);
            return Ok(About);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var value = await AboutService.GetByIDAsync(id);
            AboutService.TDelete(value);
            return Ok();
        }


        [HttpPut]
        public async Task<IActionResult> Edit(About About)
        {
            AboutService.TUpdate(About);
            return Ok(About);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var values = await AboutService.GetByIDAsync(id);
            return Ok(values);
        }
    }
}
