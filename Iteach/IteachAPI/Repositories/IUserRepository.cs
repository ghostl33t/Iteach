using IteachAPI.DTO.UserDTOs;
using IteachAPI.Models;

namespace IteachAPI.Repositories;
public interface IUserRepository
{
    public Task<bool> CreateUserAsync(User newUser);
    public Task<LoginResponse> LoginUser(LoginDTO loginDto);
    public Task<User> GetUserById(int id, int role);
    public Task<int> AddChild(Child child);
    public Task<bool> IsUserUnique(string email);
    public Task<List<ParentGetDTO>> GetParents();
}
