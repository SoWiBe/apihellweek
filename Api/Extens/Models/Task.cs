using Extens.Models.Core;

namespace Extens.Models;

public class Task
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; }
    public string Description { get; set; }
    public string Tag { get; set; }
}