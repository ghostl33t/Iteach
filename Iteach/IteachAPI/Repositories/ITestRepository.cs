using IteachAPI.DTO.TestsDTOs;
using IteachAPI.Models;
using IteachAPI.Models.MtMTables;
using System.Runtime.CompilerServices;
using static System.Net.Mime.MediaTypeNames;

namespace IteachAPI.Repositories;
public interface ITestRepository
{
    public Task<bool> AddGeneratedTest(Test newTest);
    public Task<bool> FeedbackTestResults(ChildTest childTest);
    public Task<Test> GetTestById(int id);
    public Task<List<ChildTestAndFeedbackDTO>> GetTestAndResult(TestsGetDTO testsDto); 
    public Task<List<TestsGetDataDTO>> GetTests();
}
