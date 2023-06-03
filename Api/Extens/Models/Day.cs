using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Extens.Models.Core;

namespace Extens.Models;

public class Day : BaseEntity
{
    [Key] public Guid Id { get; set; } = Guid.NewGuid();
    public string Description { get; set; }
    public Guid ChallengeId { get; set; }
    public string Date { get; set; }
    
    public IEnumerable<Task> Tasks { get; set; }
}