using System.Net;

namespace Extens.Errors.Exceptions;

public class BaseException : Exception
{
    public BaseException() : base()
    {
        
    }

    public BaseException(HttpStatusCode statusCode) : this()
    {
        StatusCode = statusCode;
    }

    public BaseException(HttpStatusCode statusCode, string message) : this(statusCode)
    {
        Message = message;
    }

    public BaseException(Exception innerException) : this(HttpStatusCode.InternalServerError)
    {
        InnerException = innerException;
    }
    
    public HttpStatusCode StatusCode { get; }
    public string Message { get; }
    public Exception InnerException { get; }
    
}