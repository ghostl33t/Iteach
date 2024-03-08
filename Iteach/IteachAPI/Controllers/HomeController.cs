using Azure.AI.OpenAI;
using IteachAPI.Services;
using Microsoft.AspNetCore.Mvc;
using OpenAI_API;
namespace IteachAPI.Controllers;


[ApiController]
[Route("[controller]")]
public class HomeController : Controller
{
    [HttpGet]
    public async Task<IActionResult> TestChatGPTRes()
    {
        //OpenAIClient client = new OpenAIClient("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");
        //var openAiResponse = await client.GetCompletionsAsync("text-davinci-003", "Koliko je 2 + 2");
        return Ok("");
    } 
}
