using System;

namespace IntroWebAPI.Abstract;

public interface ISemanticKernelService
{
     Task<string> AskAsync(string question);
}
