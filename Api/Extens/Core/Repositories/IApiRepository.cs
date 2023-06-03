namespace Extens.Core.Repositories;

public interface IApiRepository
{
    Task<HttpResponseMessage> PostDataWithResponseAsync(string url, object data, string? token = null);
    Task<HttpResponseMessage> GetResponseAsync(string url, string? token = null);
    Task<HttpResponseMessage> GetResponseWithDataAsync(string url, object data, string? token = null);
    Task<HttpResponseMessage> PutDataWithResponseAsync(string url, object data, string? token = null);
    Task<HttpResponseMessage> PatchDataWithResponseAsync(string url, object data, string? token = null);
    Task<HttpResponseMessage> DeleteDataWithResponseAsync(string url, object data, string? token = null);
}