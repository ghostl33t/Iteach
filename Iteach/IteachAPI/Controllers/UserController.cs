using IteachAPI.DTO.UserDTOs;
using IteachAPI.Models;
using IteachAPI.Repositories;
using IteachAPI.Models.MtMTables;
using IteachAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IteachAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
        private IUserRepository _userRepository;
        public readonly IUserService _userService;
        

        public UserController(IUserService userService, IUserRepository userRepository)
    {
        _userRepository = userRepository;
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
    [HttpPost]
    public async Task<IActionResult> CreateUserAsync([FromBody] RegisterDTO newUserDto)
    { 
        
        var newUser = new User();
        newUser.FirstName = newUserDto.FirstName;
        newUser.LastName = newUserDto.LastName;
        newUser.PhoneNumber = newUserDto.PhoneNumber;
        newUser.Email = newUserDto.Email;
        newUser.Gender = newUserDto.Gender;
        newUser.Active = newUserDto.Active;
        newUser.Password = newUserDto.Password;
        newUser.Roles = newUserDto.Roles;

        var userGenerated = await _userRepository.CreateUserAsync(newUser);
        if (userGenerated)
            return Ok("User created successfully!");
        return BadRequest("Bad Request");
    }

    [HttpPost("GetTests")]
    public async Task<IActionResult> GetTests(User user)
    {
        var answer = await _userService.GetTests(user);
        if (answer.Status == false)
            return BadRequest(answer.Error);
        return Ok(answer.Object);
    }
        [Route("login")]
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginDTO userCreds)
    { 
        var userId = await _userRepository.LoginUser(userCreds);
        if (userId == 0) 
            return BadRequest("User doesn't exist!");

        return Ok($"UserId = {userId}");
    }

    [Route("child-add")]
    [HttpPost]
    public async Task<IActionResult> ChildAdd([FromBody] ChildAddDTO childAddDto)
    {
        /* check if user is teacher */
        var teacher = await _userRepository.GetUserById(childAddDto.TeacherId, 0);
        if (teacher.UserId == 0)
            return BadRequest("Invalid teacher user!");
        /* check if parent exists */
        var parent = await _userRepository.GetUserById(childAddDto.ParentId, 1);
        if (parent.UserId == 0)
            return BadRequest("Parent doesn't exist in database!");

        var child = new Child();
        child.Parent = parent;
        child.FirstName = childAddDto.FirstName;
        child.LastName = childAddDto.LastName;
        //[HttpGet("GetInfoParents")]
        //public async Task<IActionResult> GetInfoParents (User user)
        //{

        //}
        var generatedChildId = await _userRepository.AddChild(child);

        return Ok(generatedChildId);
    }
}
