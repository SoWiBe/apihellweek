using System.Net;
using Extens.Core.Services;
using Extens.Errors.Exceptions;

namespace Extens.Services;

public class ValidationService : IValidationService
{
    public bool CheckNullOrEmpty(IEnumerable<object> array)
    {
        return array.All(elem => !string.IsNullOrEmpty((string)elem));
    }

    public bool CheckGuid(IEnumerable<object> array)
    {
        var isGuid = array.All(elem => Guid.TryParse((string)elem, out var newGuid));
        if(!isGuid)
            throw new ChallengesException(HttpStatusCode.BadRequest, 
                "Guid should contain 32 digits with 4 dashes (xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx)");
        
        return true;
    }
}