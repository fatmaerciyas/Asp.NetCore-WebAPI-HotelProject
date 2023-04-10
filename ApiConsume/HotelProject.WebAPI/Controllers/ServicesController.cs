using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceService ServiceService;

        public ServicesController(IServiceService ServiceService)
        {
            this.ServiceService = ServiceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await ServiceService.GetListAllAsync();
            return Ok(values);

        }

        [HttpPost]
        public async Task<IActionResult> Add(Service Service)
        {
            ServiceService.TAdd(Service);
            return Ok(Service);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var value = await ServiceService.GetByIDAsync(id);
            ServiceService.TDelete(value);
            return Ok();
        }


        [HttpPut]
        public async Task<IActionResult> Edit(Service Service)
        {
            ServiceService.TUpdate(Service);
            return Ok(Service);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var values = await ServiceService.GetByIDAsync(id);
            return Ok(values);
        }
    }
}
