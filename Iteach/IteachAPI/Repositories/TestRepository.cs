using IteachAPI.Data;
using IteachAPI.DTO.TestsDTOs;
using IteachAPI.Models;
using IteachAPI.Models.MtMTables;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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
            await _dbContext.Tests.AddAsync(newTest);
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
            await _dbContext.ChildTests.AddAsync(childTest);
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
        return await _dbContext.Tests.FirstOrDefaultAsync(x => x.Id == id);
    }
    public async Task<List<ChildTestAndFeedbackDTO>> GetTestAndResult(TestsGetDTO testsDto)
    {
        var listDto = new List<ChildTestAndFeedbackDTO>();
        var res = await _dbContext.ChildTests.Include(x => x.Test)
                                                 .Include(x => x.Child)
                                                 .AsNoTracking()
                                                 .ToListAsync();
        if (testsDto.Role == 0)
        {
            foreach(var item in res)
            {
                listDto.Add(new ChildTestAndFeedbackDTO()
                {
                    ChildName = item.Child.FirstName + " " + item.Child.LastName,
                    TestDescription = item.Test.Description,
                    TestName = item.Test.Name,
                    TestId = item.Test.Id,
                    TeacherFeedback = item.TeacherFeedback

                });
            }
        }
        else
        {
            var childIds = await _dbContext.Childs.Include(x => x.Parent).AsNoTracking()
                                                 .Where(x => x.Parent.Id == testsDto.UserId)
                                                 .Select(x => x.Id)
                                                 .ToListAsync();
            foreach(var childId in childIds)
            {
                var childTests = res.Where(x => x.Child.Id == childId).ToList();
                foreach (var item in childTests)
                {
                    listDto.Add(new ChildTestAndFeedbackDTO()
                    {
                        ChildName = item.Child.FirstName + " " + item.Child.LastName,
                        TestDescription = item.Test.Description,
                        TestName = item.Test.Name,
                        TestId = item.Test.Id,
                        TeacherFeedback = item.TeacherFeedback

                    });
                }
            }
        }
        return listDto;
    }
    public async Task<List<TestsGetDataDTO>> GetTests()
    {
        var tests = await _dbContext.Tests.ToListAsync();
        var testsDto = new List<TestsGetDataDTO>();
        foreach(var test in tests)
        {
            testsDto.Add(new TestsGetDataDTO()
            {
                Id = test.Id,
                Name = test.Name,
            });
        }
        return testsDto;
    }

}
