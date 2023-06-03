using System.Net;

namespace Extens.Errors.Exceptions;

public class TasksException : BaseException
{
    public TasksException(HttpStatusCode statusCode, string message) : base(statusCode, message)
    {
        
    }
}