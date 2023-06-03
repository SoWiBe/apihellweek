using System.ComponentModel.DataAnnotations;
using Extens.Models.Core;

namespace Extens.Models;

public class Challenge : BaseEntity
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; }
    public string Description { get; set; }
    public string StartDate { get; set; }
    public string EndDate { get; set; }
    public bool IsPrivate { get; set; }
    public IEnumerable<Day> Days { get; set; }
}