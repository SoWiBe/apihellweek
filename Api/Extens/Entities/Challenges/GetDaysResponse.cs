using Extens.Models;

namespace Extens.Entities.Challenges;

public class GetDaysResponse
{
    public IEnumerable<Day> Days { get; set; }
}