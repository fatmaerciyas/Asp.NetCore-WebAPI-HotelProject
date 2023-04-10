using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService bookingService;

        public BookingsController(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await bookingService.GetListAllAsync();
            return Ok(values);

        }

        [HttpPost]
        public async Task<IActionResult> Add(Booking Booking)
        {
            bookingService.TAdd(Booking);
            return Ok(Booking);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var value = await bookingService.GetByIDAsync(id);
            bookingService.TDelete(value);
            return Ok();
        }


        [HttpPut("Edit")]
        public async Task<IActionResult> Edit(Booking Booking)
        {
            bookingService.TUpdate(Booking);
            return Ok(Booking);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var values = await bookingService.GetByIDAsync(id);
            return Ok(values);
        }


        [HttpPut("UpdateRezervationStatus")] // 2 tane HttpPut, HttpGet olamaz 1 tane olmali O yüzden parametre verdik Action adini yazdik
        public async Task<IActionResult> UpdateRezervationStatus(Booking model)
        {
            bookingService.BookingApproved(model);
            return Ok();
        }
    }
}
