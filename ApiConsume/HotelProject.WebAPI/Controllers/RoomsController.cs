using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace HotelProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService RoomService;

        public RoomsController(IRoomService RoomService)
        {
            this.RoomService = RoomService;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await RoomService.GetListAllAsync();
            return Ok(values);

        }

        [HttpPost]
        public async Task<IActionResult> Add(Room Room)
        {
            RoomService.TAdd(Room);
            return Ok(Room);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var value = await RoomService.GetByIDAsync(id);
            RoomService.TDelete(value);
            return Ok();
        }


        [HttpPut]
        public async Task<IActionResult> Edit(Room Room)
        {
            RoomService.TUpdate(Room);
            return Ok(Room);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var values = await RoomService.GetByIDAsync(id);
            return Ok(values);
        }

    }
}
