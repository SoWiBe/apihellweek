using Extens.Core.Entities;
using Extens.Models;

namespace Extens.Entities.Challenges;

public class UpdateChallengeEntity : BaseApiResponse
{
    public Challenge Challenge { get; set; }
}