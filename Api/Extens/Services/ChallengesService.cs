using System.Net;
using Extens.Core.Api;
using Extens.Core.Repositories;
using Extens.Core.Services;
using Extens.Entities;
using Extens.Entities.Challenges;
using Extens.Errors.Exceptions;
using Extens.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Extens.Services;

public class ChallengesService : IChallengesService
{
    private readonly IApiRepository _apiRepository;
    public ChallengesService(IApiRepository apiRepository)
    {
        _apiRepository = apiRepository;
    }
    
    public async Task<GetChallengesEntity> GetChallenges()
    {
        var url = "https://localhost:7276/Challenges/GetChallenges";
        var result = await _apiRepository.GetResponseAsync(url);

        var content = await result.Content.ReadAsStringAsync();

        if (result.StatusCode != HttpStatusCode.OK)
            throw new ChallengesException(result.StatusCode, content);

        var response = JsonConvert.DeserializeObject<GetChallengesEntity>(content);
        return response;
    }

    public async Task<GetChallengeEntity> GetChallenge(GetChallengeRequest request)
    {
        var url = "https://localhost:7276/Challenges/GetChallenge";
        var result = await _apiRepository.GetResponseWithDataAsync(url, request);

        var content = await result.Content.ReadAsStringAsync();

        if (result.StatusCode != HttpStatusCode.OK)
            throw new ChallengesException(result.StatusCode, content);

        var response = JsonConvert.DeserializeObject<GetChallengeEntity>(content);
        return response;
    }

    public async Task<CreateChallengeEntity> CreateChallenge(CreateChallengeRequest request)
    {
        var url = "https://localhost:7276/Challenges/CreateChallenge";
        var result = await _apiRepository.PostDataWithResponseAsync(url, request);

        var content = await result.Content.ReadAsStringAsync();

        if (result.StatusCode != HttpStatusCode.OK) 
            throw new ChallengesException(result.StatusCode, content);

        var response = JsonConvert.DeserializeObject<CreateChallengeEntity>(content);
        return response;
    }

    public async Task<UpdateChallengeEntity> UpdateChallenge(UpdateChallengeRequest request)
    {
        var url = "https://localhost:7276/Challenges/UpdateChallenge";
        var result = await _apiRepository.PatchDataWithResponseAsync(url, request);

        var content = await result.Content.ReadAsStringAsync();

        if (result.StatusCode != HttpStatusCode.OK)
            throw new ChallengesException(result.StatusCode, content);

        var response = JsonConvert.DeserializeObject<UpdateChallengeEntity>(content);
        return response;
    }

    public async Task<RemoveChallengeEntity> RemoveChallenge(RemoveChallengeRequest request)
    {
        var url = "https://localhost:7276/Challenges/RemoveChallenge";
        var result = await _apiRepository.DeleteDataWithResponseAsync(url, request);

        var content = await result.Content.ReadAsStringAsync();

        if (result.StatusCode != HttpStatusCode.OK)
            throw new ChallengesException(result.StatusCode, content);

        var entity = JsonConvert.DeserializeObject<RemoveChallengeEntity>(content);
        return entity;
    }

    public async Task<CreateDayEntity> CreateDay(CreateDayRequest request)
    {
        var url = "https://localhost:7276/Challenges/CreateDay";
        var result = await _apiRepository.PostDataWithResponseAsync(url, request);

        var content = await result.Content.ReadAsStringAsync();

        if (result.StatusCode != HttpStatusCode.OK)
            throw new ChallengesException(result.StatusCode, content);

        var response = JsonConvert.DeserializeObject<CreateDayEntity>(content);
        return response;
    }

    public async Task<AddTaskInDayEntity> AddTaskInDay(AddTaskInDayRequest request)
    {
        var url = "https://localhost:7276/Challenges/AddTaskInDay";
        var result = await _apiRepository.PostDataWithResponseAsync(url, request);

        var content = await result.Content.ReadAsStringAsync();

        if (result.StatusCode != HttpStatusCode.OK)
            throw new ChallengesException(result.StatusCode, content);

        var response = JsonConvert.DeserializeObject<AddTaskInDayEntity>(content);
        return response;
    }

    public async Task<GetDayEntity> GetDay(GetDayRequest request)
    {
        var url = "https://localhost:7276/Challenges/GetDay";
        var result = await _apiRepository.GetResponseWithDataAsync(url, request);

        var content = await result.Content.ReadAsStringAsync();

        if (result.StatusCode != HttpStatusCode.OK)
            throw new ChallengesException(result.StatusCode, content);

        var response = JsonConvert.DeserializeObject<GetDayEntity>(content);
        return response;
    }

    public async Task<GetDaysEntity> GetDays()
    {
        var url = "https://localhost:7276/Challenges/GetDays";
        var result = await _apiRepository.GetResponseAsync(url);

        var content = await result.Content.ReadAsStringAsync();

        if (result.StatusCode != HttpStatusCode.OK)
            throw new ChallengesException(result.StatusCode, content);

        var response = JsonConvert.DeserializeObject<GetDaysEntity>(content);
        return response;
    }

    public async Task<GetDayTasksEntity> GetDayTasks()
    {
        var url = "https://localhost:7276/Challenges/GetDayTasks";
        var result = await _apiRepository.GetResponseAsync(url);

        var content = await result.Content.ReadAsStringAsync();

        if (result.StatusCode != HttpStatusCode.OK)
            throw new ChallengesException(result.StatusCode, content);

        var response = JsonConvert.DeserializeObject<GetDayTasksEntity>(content);
        return response;
    }

    public async Task<UpdateDayEntity> UpdateDay(UpdateDayRequest request)
    {
        var url = "https://localhost:7276/Challenges/UpdateDay";
        var result = await _apiRepository.PatchDataWithResponseAsync(url, request);

        var content = await result.Content.ReadAsStringAsync();

        if (result.StatusCode != HttpStatusCode.OK)
            throw new ChallengesException(result.StatusCode, content);

        var response = JsonConvert.DeserializeObject<UpdateDayEntity>(content);
        return response;
    }

    public async Task<RemoveDayEntity> RemoveDay(RemoveDayRequest request)
    {
        var url = "https://localhost:7276/Challenges/RemoveDay";
        var result = await _apiRepository.DeleteDataWithResponseAsync(url, request);

        var content = await result.Content.ReadAsStringAsync();

        if (result.StatusCode != HttpStatusCode.OK)
            throw new ChallengesException(result.StatusCode, content);

        var entity = JsonConvert.DeserializeObject<RemoveDayEntity>(content);
        return entity;
    }
}