using Extens.Core.Entities;
using Task = Extens.Models.Task;

namespace Extens.Entities;

public class CreateTaskEntity : BaseApiResponse
{
    public Task Task { get; set; }
}