using Extens.Core.Entities;
using Extens.Models;

namespace Extens.Entities.Challenges;

public class CreateDayEntity : BaseApiResponse
{
    public Day Day { get; set; }
}