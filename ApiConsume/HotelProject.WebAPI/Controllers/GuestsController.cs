using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestsController : ControllerBase
    {
        private readonly IGuestService GuestService;

        public GuestsController(IGuestService GuestService)
        {
            this.GuestService = GuestService;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await GuestService.GetListAllAsync();
            return Ok(values);

        }

        [HttpPost]
        public async Task<IActionResult> Add(Guest Guest)
        {
            GuestService.TAdd(Guest);
            return Ok(Guest);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var value = await GuestService.GetByIDAsync(id);
            GuestService.TDelete(value);
            return Ok();
        }


        [HttpPut]
        public async Task<IActionResult> Edit(Guest Guest)
        {
            GuestService.TUpdate(Guest);
            return Ok(Guest);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var values = await GuestService.GetByIDAsync(id);
            return Ok(values);
        }
    }
}
