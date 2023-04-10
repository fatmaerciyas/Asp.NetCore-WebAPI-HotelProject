using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly ITestimonialService TestimonialService;

        public TestimonialsController(ITestimonialService TestimonialService)
        {
            this.TestimonialService = TestimonialService;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await TestimonialService.GetListAllAsync();
            return Ok(values);

        }

        [HttpPost]
        public async Task<IActionResult> Add(Testimonial Testimonial)
        {
            TestimonialService.TAdd(Testimonial);
            return Ok(Testimonial);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var value = await TestimonialService.GetByIDAsync(id);
            TestimonialService.TDelete(value);
            return Ok();
        }


        [HttpPut]
        public async Task<IActionResult> Edit(Testimonial Testimonial)
        {
            TestimonialService.TUpdate(Testimonial);
            return Ok(Testimonial);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var values = await TestimonialService.GetByIDAsync(id);
            return Ok(values);
        }
    }
}
