using Extens.Core.Api;

namespace Extens.Core.Entities;

public abstract class BaseApiResponse
{
    public ApiError? Error { get; set; }
}