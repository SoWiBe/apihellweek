using System.Net;

namespace Extens.Errors.Exceptions;

public class ChallengesException : BaseException
{
    public ChallengesException(HttpStatusCode statusCode, string message) : base(statusCode, message)
    {
        
    }
}