using Extens.Core.Entities;
using Extens.Models;

namespace Extens.Entities.Challenges;

public class GetChallengesEntity : BaseApiResponse
{
    public IEnumerable<Challenge> Challenges { get; set; }
}