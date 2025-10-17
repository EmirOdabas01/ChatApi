using ChatApi.BL;
using ChatApi.BL.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatApi.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _service;
        public MessageController(IMessageService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var messages = await _service.GetAllAsync();
            return Ok(messages);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMessageDto dto)
        {
            var result = await _service.AddAsync(dto);
            return Ok(result);
        }
    }
}

