using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageCategoriesController : ControllerBase
    {

        private readonly IMessageCategoryService MessageCategoryService;

        public MessageCategoriesController(IMessageCategoryService MessageCategoryService)
        {
            this.MessageCategoryService = MessageCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await MessageCategoryService.GetListAllAsync();
            return Ok(values);

        }

        [HttpPost]
        public async Task<IActionResult> Add(MessageCategory MessageCategory)
        {
            MessageCategoryService.TAdd(MessageCategory);
            return Ok(MessageCategory);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var value = await MessageCategoryService.GetByIDAsync(id);
            MessageCategoryService.TDelete(value);
            return Ok();
        }


        [HttpPut]
        public async Task<IActionResult> Edit(MessageCategory MessageCategory)
        {
            MessageCategoryService.TUpdate(MessageCategory);
            return Ok(MessageCategory);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var values = await MessageCategoryService.GetByIDAsync(id);
            return Ok(values);
        }
    }
}
