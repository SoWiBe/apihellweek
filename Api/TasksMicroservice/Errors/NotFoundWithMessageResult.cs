using System.Net;
using System.Web.Http;
namespace HellWeekBack.Errors;

public class NotFoundWithMessageResult : IHttpActionResult
{
    private string _message;
    
    public NotFoundWithMessageResult(string message)
    {
        _message = message;
    }
    
    public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
    {
        var response = new HttpResponseMessage(HttpStatusCode.NotFound);
        response.Content = new StringContent(_message);
        return Task.FromResult(response);
    }
}