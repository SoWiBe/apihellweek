using Extens.Core.Entities;
using Extens.Models;

namespace Extens.Entities.Challenges;

public class CreateChallengeEntity : BaseApiResponse
{
    public Challenge Challenge { get; set; }
}