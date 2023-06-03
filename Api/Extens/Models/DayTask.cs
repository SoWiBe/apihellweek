using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Extens.Models.Core;

namespace Extens.Models;

public class DayTask : BaseEntity
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid DayId { get; set; }
    public Guid TaskId { get; set; }
}