
namespace Intro;

public class CustomDelegatingHandler(string url) : DelegatingHandler(new HttpClientHandler())
{
    
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        
        request.RequestUri =
                new Uri(request.RequestUri.ToString().Replace(
                    "https://api.openai.com/v1", url));
        return await base.SendAsync(request, cancellationToken);
    }
}
