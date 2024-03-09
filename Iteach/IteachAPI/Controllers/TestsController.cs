using IteachAPI.OpenAI;
using Microsoft.AspNetCore.Mvc;

namespace IteachAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestsController : Controller
{
    private IOpenAI _openAiService;
    public TestsController(IOpenAI openAiService)
    {
        _openAiService = openAiService;
    }

    [HttpPost]
    public async Task<IActionResult> GenerateTests([FromBody]string question)
    {
        var chatGPTres = await _openAiService.OpenAIRequest(question);
        return Ok(chatGPTres);
    }
}
