namespace IteachAPI.OpenAI;
public interface IOpenAI
{
    public Task<string> OpenAIRequest(string question);
}
