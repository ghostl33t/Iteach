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
        if (!await _userRepository.IsUserUnique(newUserDto.Email))
            return BadRequest("User with parsed email already exists in the database!");

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
    [Route("login")]
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginDTO userCreds)
    {
        var user = await _userRepository.LoginUser(userCreds);
        if (user.Id == 0) 
            return BadRequest("User doesn't exist!");

        return Ok(user);
    }
    [Route("child-add")]
    [HttpPost]
    public async Task<IActionResult> ChildAdd([FromBody] ChildAddDTO childAddDto)
    {
        /* check if user is teacher */
        var teacher = await _userRepository.GetUserById(childAddDto.TeacherId, 0);
        if (teacher.Id == 0)
            return BadRequest("Invalid teacher user!");
        /* check if parent exists */
        var parent = await _userRepository.GetUserById(childAddDto.ParentId, 1);
        if (parent.Id == 0)
            return BadRequest("Parent doesn't exist in database!");

        var child = new Child();
        child.Parent = parent;
        child.FirstName = childAddDto.FirstName;
        child.LastName = childAddDto.LastName;

        var generatedChildId = await _userRepository.AddChild(child);

        return Ok(generatedChildId);
    }
    [Route("get-parents")]
    [HttpGet]
    public async Task<IActionResult> GetParents()
    {
        return Ok(await _userRepository.GetParents());
    }
}
