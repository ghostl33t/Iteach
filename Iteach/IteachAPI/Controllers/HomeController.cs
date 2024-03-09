using IteachAPI.OpenAI;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
namespace IteachAPI.Controllers;


[ApiController]
[Route("[controller]")]
public class HomeController : Controller
{
    private IOpenAI _openAiService;
    public HomeController(IOpenAI openAiService)
    {
        _openAiService = openAiService; 
    }
    [HttpPost]
    public async Task<IActionResult> TestChatGPTRes(string question)
    {
        var chatGPTres = await _openAiService.OpenAIRequest(question);
        return Ok(chatGPTres);
    } 
}