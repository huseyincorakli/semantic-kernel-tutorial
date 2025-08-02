using System.ComponentModel;
using Intro;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

DotNetEnv.Env.Load();

//api key ve base url .env dosyasına ekle

var key = Environment.GetEnvironmentVariable("GROQ_API_KEY")!;
var baseURL = Environment.GetEnvironmentVariable("BASE_URL")!;

//openai base url değiştirmek
HttpClient httpClient = new(new CustomDelegatingHandler(baseURL));

//kernel builder oluştur
var kernelBuilder = Kernel.CreateBuilder();

//kernel builder'a model, key, ve httpclient nesnesini geçtik
kernelBuilder.AddOpenAIChatCompletion("llama-3.3-70b-versatile", key, httpClient: httpClient);


//kernel build ettik.
var kernel = kernelBuilder.Build();

#region  giriş
// while (true)
// {
//     Console.WriteLine("Soru sor :");
//     string input = Console.ReadLine();
//     var response = await kernel.InvokePromptAsync(input);
//     Console.WriteLine($"Cevap :\n------------------------\n{response}\n------------------------");
// }

#endregion



#region promptTemplate

// var promptTemplate = "Yandaki kelimeyi türkçeye çevir {{$kelime}}";

// var function = kernel.CreateFunctionFromPrompt(promptTemplate);

// var argument = new KernelArguments { ["kelime"] = "banana" };

// var result = await function.InvokeAsync(kernel, argument);
// System.Console.WriteLine(result);

#endregion


#region history
// var history = new ChatHistory();
// history.AddUserMessage("Selam benim adım hüseyin.şuanda semantic kernel öğreniyorum. Senin adın nedir?");

// var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();
// var response = await chatCompletionService.GetChatMessageContentAsync(history);

// System.Console.WriteLine($"############ MESSAGE: {response}\n ##########################################################");


// history.AddAssistantMessage(response.ToString());

// history.AddUserMessage("Beni tanıyor musun? Tanıyorsan adımı ve öğrenmekte olduğum şeyi bilirsin");
// var response2 = await chatCompletionService.GetChatMessageContentAsync(history);
// System.Console.WriteLine($"############ MESSAGE: {response2}\n ##########################################################");

// history.AddAssistantMessage(response2.ToString());

// Console.Read();

#endregion


#region Plugin Yapılanması

kernel.Plugins.AddFromType<CalculatorPlugin>();

var chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();

var result = await chatCompletionService.GetChatMessageContentAsync(
    "100 x 45 kaçtır?",
    executionSettings: new PromptExecutionSettings
    {
        FunctionChoiceBehavior = FunctionChoiceBehavior.Auto()
    },
    kernel: kernel
    );
 
 
Console.WriteLine(result.ToString());


#endregion