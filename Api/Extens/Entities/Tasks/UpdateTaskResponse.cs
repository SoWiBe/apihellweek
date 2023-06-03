using Extens.Core.Entities;
using Task = Extens.Models.Task;

namespace Extens.Entities.Tasks;

public class UpdateTaskResponse
{
    public Task Task { get; set; }
}