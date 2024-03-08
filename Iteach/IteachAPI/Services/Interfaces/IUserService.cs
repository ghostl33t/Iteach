using IteachAPI.Models;
using IteachAPI.Models.MtMTables;

namespace IteachAPI.Services.Interfaces
{
    public interface IUserService
    {
        public string GenerateTest(string description);
        public bool PostChildInformations (TestResponse testRespons);

    }
}
