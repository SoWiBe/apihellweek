using System.Net;

namespace Extens.Errors.Exceptions;

public class FacadeException : BaseException
{
    public FacadeException(HttpStatusCode statusCode, string message) : base(statusCode, message)
    {
        
    }
}