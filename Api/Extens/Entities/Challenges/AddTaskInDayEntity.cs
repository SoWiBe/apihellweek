using Extens.Core.Entities;
using Extens.Models;

namespace Extens.Entities.Challenges;

public class AddTaskInDayEntity : BaseApiResponse
{
    public Day Day { get; set; }
}