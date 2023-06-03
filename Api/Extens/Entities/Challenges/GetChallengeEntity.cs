using Extens.Core.Entities;
using Extens.Models;

namespace Extens.Entities.Challenges;

public class GetChallengeEntity : BaseApiResponse
{
    public Challenge Challenge { get; set; }
}