using IteachAPI.DTO.UserDTOs;
using IteachAPI.Models;
using IteachAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace IteachAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private IUserRepository _userRepository;
    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
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

        var userGenerated = await _userRepository.CreateUserAsync(newUser);
        if (userGenerated)
            return Ok("User created successfully!");
        return BadRequest("Bad Request");
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
}
