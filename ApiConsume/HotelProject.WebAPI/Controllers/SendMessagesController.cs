using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendMessagesController : ControllerBase
    {
        private readonly ISendMessageService sendMessageService;

        public SendMessagesController(ISendMessageService sendMessageService)
        {
            this.sendMessageService = sendMessageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await sendMessageService.GetListAllAsync();
            return Ok(values);

        }

        [HttpPost]
        public async Task<IActionResult> Add(SendMessage SendMessage)
        {
            sendMessageService.TAdd(SendMessage);
            return Ok(SendMessage);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var value = await sendMessageService.GetByIDAsync(id);
            sendMessageService.TDelete(value);
            return Ok();
        }


        [HttpPut]
        public async Task<IActionResult> Edit(SendMessage SendMessage)
        {
            sendMessageService.TUpdate(SendMessage);
            return Ok(SendMessage);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var values = await sendMessageService.GetByIDAsync(id);
            return Ok(values);
        }
        [HttpGet("GetSendMessageCount")]
        public IActionResult GetSendMessageCount()
        {
            return Ok(sendMessageService.GetSendMessageCount());
        }
    }
}
