using Extens.Core.Repositories;
using Extens.Extensions;

namespace Extens.Repositories;

public class ApiRepository : IApiRepository
{
    private readonly IHttpClientFactory _httpClientFactory;

    public ApiRepository(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    
    public async Task<HttpResponseMessage> PostDataWithResponseAsync(string url, object data, string? token = null)
    {
        var client = _httpClientFactory.CreateClient();
        
        var request = new HttpRequestMessage(HttpMethod.Post, url);
        request.SetJsonAsContent(data);
        request.SetAuthorization(token);

        var result = await client.SendAsync(request, HttpCompletionOption.ResponseContentRead);
        return result;
    }

    public async Task<HttpResponseMessage> GetResponseAsync(string url, string? token = null)
    {
        var client = _httpClientFactory.CreateClient();

        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.SetAuthorization(token);

        var result = await client.SendAsync(request, HttpCompletionOption.ResponseContentRead);
        return result;
    }

    public async Task<HttpResponseMessage> GetResponseWithDataAsync(string url, object data, string? token = null)
    {
        var client = _httpClientFactory.CreateClient();

        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.SetJsonAsContent(data);
        request.SetAuthorization(token);

        var result = await client.SendAsync(request, HttpCompletionOption.ResponseContentRead);
        return result;
    }

    public async Task<HttpResponseMessage> PutDataWithResponseAsync(string url, object data, string? token = null)
    {
        var client = _httpClientFactory.CreateClient();
        
        var request = new HttpRequestMessage(HttpMethod.Put, url);
        request.SetJsonAsContent(data);
        request.SetAuthorization(token);

        var result = await client.SendAsync(request, HttpCompletionOption.ResponseContentRead);
        return result;
    }

    public async Task<HttpResponseMessage> PatchDataWithResponseAsync(string url, object data, string? token = null)
    {
        var client = _httpClientFactory.CreateClient();
        
        var request = new HttpRequestMessage(HttpMethod.Patch, url);
        request.SetJsonAsContent(data);
        request.SetAuthorization(token);

        var result = await client.SendAsync(request, HttpCompletionOption.ResponseContentRead);
        return result;
    }

    public async Task<HttpResponseMessage> DeleteDataWithResponseAsync(string url, object data, string? token = null)
    {
        var client = _httpClientFactory.CreateClient();
        
        var request = new HttpRequestMessage(HttpMethod.Delete, url);
        request.SetJsonAsContent(data);
        request.SetAuthorization(token);

        var result = await client.SendAsync(request, HttpCompletionOption.ResponseContentRead);
        return result;
    }
}