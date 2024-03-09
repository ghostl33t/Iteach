using IteachAPI.Models;
using IteachAPI.Models.MtMTables;
using IteachAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IteachAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("TestResponse")]
        public async Task<IActionResult> PostChildInformations(TestResponse testResponse)
        {
            var answer = await _userService.PostChildInformations(testResponse);
            if (answer.Status)
                return Ok(answer.Error);
            return BadRequest(answer.Error);
        }

        [HttpPost("GetTests")]

        public async Task<IActionResult> GetTests (User user)
        {
            var answer = await _userService.GetTests(user);
            if (answer.Status == false)
                return BadRequest(answer.Error);
            return Ok(answer.Object);    
        }

        //[HttpGet("GetInfoParents")]
        //public async Task<IActionResult> GetInfoParents (User user)
        //{

        //}

    }
}
