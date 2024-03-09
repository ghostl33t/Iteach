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
    public async Task<int> LoginUser(LoginDTO loginDto)
    {
        var user = await _dbContext.UserTable
                                    .Where(x => x.Email == loginDto.Email 
                                    && x.Password == loginDto.Password)
                                    .Select(x => x.UserId).FirstOrDefaultAsync();
        return user;
    }
}