using IteachAPI.Data;
using IteachAPI.Models;
using IteachAPI.Models.MtMTables;
using IteachAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;

namespace IteachAPI.Services
{
    public class UserService : IUserService
    {
        public ApplicationDbContext _dbContext;
        public UserService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<ErrorProvider> PostChildInformations(TestResponse testResponse)
        {
            if (testResponse == null)
            { 
                return new ErrorProvider()
                {
                    Status = false,
                    Error = "Test response ne smije biti prazan!"
                };
            }

            if(testResponse.Child.Parent.Roles == 2)
            {
                return new ErrorProvider()
                {
                    Status = false,
                    Error = "Ova funkcija je namijenjena samo za Ucitelja/icu!"
                };
            }
            await _dbContext.TestResponseTable.AddAsync(testResponse);  
            await _dbContext.SaveChangesAsync();    
            return new ErrorProvider()
            {
                Status = true,
                Error = "Uspjesno dodano!"
            };    
        }

        public async Task<ErrorProvider> GetTests(User user)
        {
            var test = await _dbContext.UserTestTable.FindAsync(user.UserId) ;
            if(test == null)
            {
                return new ErrorProvider()
                {
                    Status = false,
                    Error = "Nije pronadjen niti jedan test!"
                };
            }

            if(test.User.Roles == 2)
            {
                return new ErrorProvider()
                {
                    Status = false,
                    Error = "Ova funkcija je namijenjena samo za Ucitelja/icu!"
                };
            }
            List<UserTest> lista = _dbContext.UserTestTable.Include(x => x.User).Include(x => x.Test)
                .Where(x => x.User.UserId == user.UserId).ToList();

            return new ErrorProvider()
            {
                Status = true,
                Object = lista.Cast<object>().ToList()
            };
            
        }

        public async Task<ErrorProvider> AddChild(Child child, User user)
        {
            if(child == null)
            {
                return new ErrorProvider()
                {
                    Status = false,
                    Error = "Child profil ne smije biti prazan!"
                };
            }    

            if(user.Roles == 2)
            {
                return new ErrorProvider()
                {
                    Status = false,
                    Error = "Ova funkcija je dostupna samo za Ucitelja/icu!"
                };
            }


            var parent = await _dbContext.UserTable.FindAsync(child.Parent.UserId);
            if(parent == null)
            {
                return new ErrorProvider()
                {
                    Status = false,
                    Error = "Ne postoji roditelj u bazi!"
                };
            }
            
            var newChild = new Child()
            {
                FirstName = child.FirstName,
                LastName = child.LastName,
                Parent = child.Parent
            };

            return new ErrorProvider()
            {
                Status = true,
                Error = "Uspjesno dodano!"
            };
        }

     
        

    }
}
