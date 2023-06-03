using Extens.Entities.Challenges;

namespace Extens.Core.Services;

public interface IChallengesService
{
    Task<GetChallengesEntity> GetChallenges();
    Task<GetChallengeEntity> GetChallenge(GetChallengeRequest request);
    Task<CreateChallengeEntity> CreateChallenge(CreateChallengeRequest request);
    Task<UpdateChallengeEntity> UpdateChallenge(UpdateChallengeRequest request);
    Task<RemoveChallengeEntity> RemoveChallenge(RemoveChallengeRequest request);
    Task<CreateDayEntity> CreateDay(CreateDayRequest request);
    Task<AddTaskInDayEntity> AddTaskInDay(AddTaskInDayRequest request);
    Task<GetDayEntity> GetDay(GetDayRequest request);
    Task<GetDaysEntity> GetDays();
    Task<GetDayTasksEntity> GetDayTasks();
    Task<UpdateDayEntity> UpdateDay(UpdateDayRequest request);
    Task<RemoveDayEntity> RemoveDay(RemoveDayRequest request);
}