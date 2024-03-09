using IteachAPI.Data;
using IteachAPI.DTO.UserDTOs;
using IteachAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace IteachAPI.Repositories;
public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _dbContext;
    public UserRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<bool> CreateUserAsync(User newUser)
    {
        try
        {
            await _dbContext.AddAsync(newUser);
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }
        return true;
    }
    public async Task<int> LoginUser(LoginDTO loginDto)
    {
        var user = await _dbContext.UserTable
                                    .Where(x => x.Email == loginDto.Email 
                                    && x.Password == loginDto.Password)
                                    .Select(x => x.UserId).FirstOrDefaultAsync();
        return user;
    }
    public async Task<User> GetUserById(int id, int role)
    {
        var userExists = await _dbContext.UserTable
                                         .AsNoTracking()
                                         .Where(x => x.UserId == id && x.Roles == role)
                                         .FirstOrDefaultAsync();
        if (userExists == null)
            return new User();

        return userExists;
    }
    public async Task<int> AddChild(Child child)
    {
        try
        {

            await _dbContext.AddAsync(child);
            await _dbContext.SaveChangesAsync();
            return child.ChildId;
        }
        catch (Exception)
        {

            throw;
        }
    }
}
