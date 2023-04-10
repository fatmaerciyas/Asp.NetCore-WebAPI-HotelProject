using AutoMapper;
using HotelProject.BusinessLayer.Abstract;
using HotelProject.DtoLayer.Dtos.RoomDto;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Rooms2Controller : ControllerBase
    {
        private readonly IRoomService roomService; // roomService olusturduk
        private readonly IMapper mapper; // roomService olusturduk

        public Rooms2Controller(IRoomService roomService, IMapper mapper)
        {
            this.roomService = roomService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await roomService.GetListAllAsync();
            return Ok(values);
            
        }

        [HttpPost]
        public async Task<IActionResult> Add(RoomAddDto model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                var values = mapper.Map<Room>(model); //Burada Room ile RoomAddDto Map Edilir

                 roomService.TAdd(values);
                return Ok();

            }

        }


        [HttpPut]
        public async Task<IActionResult> Update(RoomAddDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                var values = mapper.Map<Room>(model); //Burada Room ile RoomAddDto Map Edilir

                roomService.TUpdate(values);
                return Ok();

            }

        }

    }
}
