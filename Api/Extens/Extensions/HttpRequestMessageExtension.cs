using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Extens.Extensions;

public static class HttpRequestMessageExtension
{
    public static void SetJsonAsContent(this HttpRequestMessage request, object data)
    {
        var json = JsonConvert.SerializeObject(data);
        request.Content = new StringContent(json, Encoding.UTF8, "application/json");
    }

    public static void SetAuthorization(this HttpRequestMessage request, string? token)
    {
        if (token == null)
            return;

        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }
}