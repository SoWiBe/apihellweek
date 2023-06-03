using Extens.Core.Entities;
using Task = Extens.Models.Task;

namespace Extens.Entities;

public class GetTaskEntity : BaseApiResponse
{
    public Task Task { get; set; }
}