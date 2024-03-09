using IteachAPI.Models;
using IteachAPI.Models.MtMTables;

namespace IteachAPI.Services.Interfaces
{
    public interface IUserService
    {
        
        Task<ErrorProvider> PostChildInformations (TestResponse testRespons);
        Task<ErrorProvider> GetTests(User user); 
        Task<ErrorProvider> AddChild (Child child, User user);

    }
}
