﻿using IteachAPI.Data;
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
    public async Task<LoginResponse> LoginUser(LoginDTO loginDto)
    {
        var user = await _dbContext.Users
                                    .Where(x => x.Email == loginDto.Email 
                                    && x.Password == loginDto.Password)
                                    .FirstOrDefaultAsync();
        if (user == null) 
            return new LoginResponse();
        var userDto = new LoginResponse()
        {
            Email = user.Email,
            Id = user.Id,
            Roles = user.Roles
        };
        return userDto;
    }
    public async Task<User> GetUserById(int id, int role)
    {
        var userExists = await _dbContext.Users
                                         .Where(x => x.Id == id && x.Roles == role)
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
            return child.Id;
        }
        catch (Exception)
        {

            throw;
        }
    }
    public async Task<bool> IsUserUnique(string email)
    {
        var userExists = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
        if (userExists != null)
            return false;

        return true;
    }
    public async Task<List<ParentGetDTO>> GetParents()
    {
        var users = await _dbContext.Users.AsNoTracking().Where(x => x.Roles == 1).ToListAsync();
        var parentsDto = new List<ParentGetDTO>();
        foreach(var item in users)
            parentsDto.Add(new ParentGetDTO() { Id = item.Id,NameMail = item.FirstName + " " + item.LastName 
                           + $"({item.Email})"});

        return parentsDto;
    }
}
