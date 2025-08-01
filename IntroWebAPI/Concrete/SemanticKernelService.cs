using System;
using DotNetEnv;
using IntroWebAPI.Abstract;
using IntroWebAPI.Utils;
using Microsoft.SemanticKernel;

namespace IntroWebAPI.Concrete;

public class SemanticKernelService : ISemanticKernelService
{
    private readonly Kernel _kernel;
    public SemanticKernelService()
    {
         Env.Load();

        var apiKey = Environment.GetEnvironmentVariable("GROQ_API_KEY")!;
        var baseUrl = Environment.GetEnvironmentVariable("BASE_URL")!;

        var httpClient = new HttpClient(new CustomDelegatingHandler(baseUrl));

        var builder = Kernel.CreateBuilder();
        builder.AddOpenAIChatCompletion("llama-3.3-70b-versatile", apiKey, httpClient: httpClient);

        _kernel = builder.Build();
    }
     public async Task<string> AskAsync(string question)
    {
        var result = await _kernel.InvokePromptAsync(question);
        return result.ToString();
    }
}
