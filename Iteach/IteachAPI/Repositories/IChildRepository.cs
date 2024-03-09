using IteachAPI.Models;
using IteachAPI.Models.MtMTables;

namespace IteachAPI.Repositories;

public interface IChildRepository
{
    public Task<Child> GetChildById(int id);
    public Task<Child> GetChildWithParentById(int id);
    public Task<List<ChildTest>> GetSuggestionForChild(int childId);
    public Task<bool> WriteSuggestionForChild(Suggestion suggestion);
}
