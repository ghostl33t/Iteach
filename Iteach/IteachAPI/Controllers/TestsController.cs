using IteachAPI.DTO.TestsDTOs;
using IteachAPI.Models;
using IteachAPI.Models.MtMTables;
using IteachAPI.OpenAI;
using IteachAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Data;

namespace IteachAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestsController : Controller
{
    private readonly IOpenAI _openAiService;
    private readonly ITestRepository _testRepository;
    private readonly IChildRepository _childRepository;
    private readonly IUserRepository _userRepository;
    public TestsController(IOpenAI openAiService, ITestRepository testRepository, IChildRepository childRepository,IUserRepository userRepository)
    {
        _openAiService = openAiService;
        _testRepository = testRepository;
        _childRepository = childRepository;
        _userRepository = userRepository;
    }
    [Route("create-test")]
    [HttpPost]
    public async Task<IActionResult> GenerateTests([FromBody]AddTestDTO testDto)
    {
        var chatGPT_res = await _openAiService.OpenAIRequest(testDto.Prompt);
        testDto.Description = chatGPT_res;

        var test = new Test();
        test.Name = testDto.Name;
        test.Description = chatGPT_res;
        testDto.Role = 0;
        test.Teacher = await _userRepository.GetUserById(testDto.UserId, testDto.Role);

        var generatedTest = await _testRepository.AddGeneratedTest(test);
        if (generatedTest)
            return Ok(testDto);

        return BadRequest("Error while generating tests!");
    }
    [Route("teacher-feedback")]
    [HttpPost]
    public async Task<IActionResult> CreateTeacherFeedbackOnTest([FromBody] ChildTestFeedbackDTO testFeedbackDto)
    {
        var test = await _testRepository.GetTestById(testFeedbackDto.TestId);
        if (test == null)
            return BadRequest("Test not found!");
        var child = await _childRepository.GetChildById(testFeedbackDto.ChildId);
        if (child == null)
            return BadRequest("Child not found!");


        var childTest = new ChildTest();
        childTest.Test = test;
        childTest.Child = child;
        childTest.TeacherFeedback = testFeedbackDto.TeacherFeedback;
        var testFeedback = await _testRepository.FeedbackTestResults(childTest);

        if (testFeedback)
            return Ok("Test feedback added successfully!");

        return BadRequest("Addition of test feedback failed!");
    }
    [Route("child-suggestion")]
    [HttpPost]
    public async Task<IActionResult> GetSuggestionForChild(int childId)
    {
        var child = await _childRepository.GetChildWithParentById(childId);
        if (child == null)
            return BadRequest("Child doesn't exist");

        var listsOfResults = await _childRepository.GetSuggestionForChild(childId);
        var listOfSuggestions = "";
        var listOfTests = "";

        foreach(var result in listsOfResults)
        {
            var chatGPT_res = await _openAiService.OpenAIRequest($"How should small kid fix these issues: {result}");
            listOfSuggestions += chatGPT_res + "\n";
            listOfTests += result.Test.Name + "; ";
        }
        var suggestionDto = new SuggestionDTO();
        suggestionDto.SuggestionText = listOfSuggestions;
        suggestionDto.SuggestionDate = DateTime.Today;
        suggestionDto.ChildId = childId;
        suggestionDto.ChildName = child.FirstName + " " + child.LastName;
        suggestionDto.ParentName = child.Parent.FirstName + " " + child.Parent.LastName;

        /* call suggestion writer */
        var suggestion = new Suggestion()
        {
            Child = child,
            SuggestionText = listOfSuggestions,
            SuggestionBasedOnTests = listOfTests,
            DateOfSuggestion = suggestionDto.SuggestionDate
        };
        await _childRepository.WriteSuggestionForChild(suggestion);

        return Ok(suggestionDto);
    }
    [Route("get-tests-results")]
    [HttpPost]
    public async Task<IActionResult> GetTestAndResult([FromBody]TestsGetDTO testsDto)
    {
        var res = await _testRepository.GetTestAndResult(testsDto);
        return Ok(res);
    }
    [Route("get-tests-list")]
    [HttpGet]
    public async Task<IActionResult> GetTestsList()
    {
        var res = await _testRepository.GetTests();
        return Ok(res);
    }
}
