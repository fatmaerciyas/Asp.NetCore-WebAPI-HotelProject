using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribesController : ControllerBase
    {
        private readonly ISubscribeService SubscribeService;

        public SubscribesController(ISubscribeService SubscribeService)
        {
            this.SubscribeService = SubscribeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await SubscribeService.GetListAllAsync();
            return Ok(values);

        }

        [HttpPost]
        public async Task<IActionResult> Add(Subscribe Subscribe)
        {
            SubscribeService.TAdd(Subscribe);
            return Ok(Subscribe);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var value = await SubscribeService.GetByIDAsync(id);
            SubscribeService.TDelete(value);
            return Ok();
        }


        [HttpPut]
        public async Task<IActionResult> Edit(Subscribe Subscribe)
        {
            SubscribeService.TUpdate(Subscribe);
            return Ok(Subscribe);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var values = await SubscribeService.GetByIDAsync(id);
            return Ok(values);
        }
    }
}
