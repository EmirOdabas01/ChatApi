using ChatApi.BL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChatApi.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Register(string nickname)
        {
            var response = await _userService.AddUserAsync(nickname);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetUserMessages(int id)
        {
            var response = await _userService.GetAllAsync(id);
            return Ok(response);
        }
    }
}
