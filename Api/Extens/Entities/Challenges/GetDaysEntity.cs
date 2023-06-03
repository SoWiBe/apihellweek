using Extens.Core.Entities;
using Extens.Models;

namespace Extens.Entities.Challenges;

public class GetDaysEntity : BaseApiResponse
{
    public IEnumerable<Day> Days { get; set; }
}