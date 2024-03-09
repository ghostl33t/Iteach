using IteachAPI.Data;
using IteachAPI.DTO.TestsDTOs;
using IteachAPI.Models;
using IteachAPI.Models.MtMTables;
using Microsoft.EntityFrameworkCore;

namespace IteachAPI.Repositories;
public class ChildRepository : IChildRepository
{
    private readonly ApplicationDbContext _dbContext;
    public ChildRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Child> GetChildById(int id)
    {
        return await _dbContext.Childs.FirstOrDefaultAsync(x => x.Id == id);
    }
    public async Task<Child> GetChildWithParentById(int id)
    {
        return await _dbContext.Childs.Include(x => x.Parent).FirstOrDefaultAsync(x => x.Id == id);
    }
    public async Task<List<ChildTest>> GetSuggestionForChild(int childId)
    {
        var listOfTests = await _dbContext.ChildTests
                                           .AsNoTracking()
                                           .Include(x => x.Test)
                                           .Where(x => x.ChildId == childId).ToListAsync();
        return listOfTests;
    }
    public async Task<bool> WriteSuggestionForChild(Suggestion suggestion)
    {
        try
        {
            await _dbContext.Suggestions.AddAsync(suggestion);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {

            throw;
        }
    }
    public async Task<List<ChildDTO>> GetListOfChilds()
    {
        var childs = await _dbContext.Childs.Include(x => x.Parent).AsNoTracking().ToListAsync();
        var childsDto = new List<ChildDTO>();
        foreach (var item in childs)
            childsDto.Add(new ChildDTO() { Id = item.Id, ChildName = $"{item.FirstName} ({item.Parent.FirstName}) {item.LastName} " });

        return childsDto;
    }
    /*TODO: GetSuggestion */
}
