using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffsController : ControllerBase
    {
        private readonly IStaffService staffService;

        public StaffsController(IStaffService staffService)
        {
            this.staffService = staffService;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await staffService.GetListAllAsync();
            return Ok(values);

        }

        [HttpPost]
        public async Task<IActionResult> Add(Staff staff)
        {
            staffService.TAdd(staff);
            return Ok(staff);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var value = await staffService.GetByIDAsync(id);
            staffService.TDelete(value);  
            return Ok();
        }


        [HttpPut]
        public async Task<IActionResult> Edit(Staff staff)
        {
            staffService.TUpdate(staff);
            return Ok(staff);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var values = await staffService.GetByIDAsync(id);
            return Ok(values);
        }
    }
}
