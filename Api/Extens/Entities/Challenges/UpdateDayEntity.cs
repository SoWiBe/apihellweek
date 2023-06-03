using Extens.Core.Entities;
using Extens.Models;

namespace Extens.Entities.Challenges;

public class UpdateDayEntity : BaseApiResponse
{
    public Day Day { get; set; }
}