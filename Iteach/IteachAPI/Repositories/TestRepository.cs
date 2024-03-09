using IteachAPI.Data;
using IteachAPI.Models;
using IteachAPI.Models.MtMTables;
using Microsoft.EntityFrameworkCore;

namespace IteachAPI.Repositories;
public class TestRepository : ITestRepository
{
    private readonly ApplicationDbContext _dbContext;
    public TestRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;   
    }
    public async Task<bool> AddGeneratedTest(Test newTest)
    {
        try
        {
            await _dbContext.TestTable.AddAsync(newTest);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {

            throw;
        }
    }
    public async Task<bool> FeedbackTestResults(ChildTest childTest)
    {
        try
        {
            await _dbContext.ChildTestTable.AddAsync(childTest);
            await _dbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            throw;
        }
        
    }
    public async Task<Test> GetTestById(int id)
    {
        return await _dbContext.TestTable.FirstOrDefaultAsync(x => x.TestId == id);
    }
}
