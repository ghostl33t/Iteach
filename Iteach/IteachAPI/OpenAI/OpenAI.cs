using System.Text.Json;

namespace IteachAPI.OpenAI;
public class OpenAI : IOpenAI
{
    public async Task<string> OpenAIRequest(string question)
    {
        string apiKey = "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"; //TODO: set in config!
        string prompt = question;

        string openAiEndpoint = "https://api.openai.com/v1/completions";
        var res = "";
        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + apiKey);

            var requestData = new
            {
                model = "gpt-3.5-turbo-instruct",
                prompt = prompt
            };

            var jsonRequestData = JsonSerializer.Serialize(requestData);
            var httpContent = new StringContent(jsonRequestData, System.Text.Encoding.UTF8, "application/json");

            var response = await client.PostAsync(openAiEndpoint, httpContent);
            //var res = "";
            if (response.IsSuccessStatusCode)
            {
                var jsonResponse = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<TextCompletionResponse>(jsonResponse);
                if (result.choices != null && result.choices.Any())
                {
                    var completion = result.choices[0].text;
                    res = completion;
                    Console.WriteLine(completion);
                }
                else
                {
                    Console.WriteLine("No choices found in the response.");
                }
            }
            else
            {
                Console.WriteLine("Failed to retrieve response.");
            }
        }
        return res;
    }
}
public class TextCompletionResponse
{
    public string id { get; set; } = string.Empty;
    public string @object { get; set; } = string.Empty;
    public long created { get; set; }
    public string model { get; set; } = string.Empty;
    public Choice[]? choices { get; set; }
    public Usage? usage { get; set; }
}

public class Choice
{
    public string text { get; set; } = string.Empty;
    public int index { get; set; }
    public object logprobs { get; set; } = string.Empty;
    public string finish_reason { get; set; } = string.Empty;
}

public class Usage
{
    public int prompt_tokens { get; set; }
    public int completion_tokens { get; set; }
    public int total_tokens { get; set; }
}