using IntroWebAPI.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntroWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AIController : ControllerBase
    {
        private readonly ISemanticKernelService _semanticKernelService;

        public AIController(ISemanticKernelService semanticKernelService)
        {
            _semanticKernelService = semanticKernelService;
        }

        [HttpPost("ask")]
        public async Task<IActionResult> Ask([FromBody] QuestionRequest request)
        {
            var answer = await _semanticKernelService.AskAsync(request.Question);
            return Ok(new { answer });
        }
    }
}
public class QuestionRequest
{
    public string Question { get; set; } = "";
}
