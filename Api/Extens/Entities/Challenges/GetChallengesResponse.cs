using Extens.Models;

namespace Extens.Entities.Challenges;

public class GetChallengesResponse
{
    public IEnumerable<Challenge> Challenges { get; set; }
}