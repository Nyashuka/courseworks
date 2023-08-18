using System;
using Newtonsoft.Json;
using SportClubISS.Infrastructure.Services;
using SportClubISS.Models.Rating;

namespace SportClubISS.Models;

public class Sportsman : SportMember
{
    [JsonProperty("coach")] private Guid _coach;
    [JsonIgnore] public Guid Coach => _coach;

    public void SetCoach(Guid newCoach) => _coach = newCoach;
    
    [JsonConstructor]
    public Sportsman(Guid id, string fullName, int age, string phoneNumber, Guid specialization, Guid sportClubGuid, 
        [JsonProperty("coach")] Guid coachId) : 
        base(id, fullName, age, phoneNumber, specialization, sportClubGuid)
    {
        _coach = coachId;
        _ratingCalculator = new SportsmanRating(id);
    }

    public float GetRatingScore()
    {
        var competitions = Repository.Instance.GetAllCompetitions();
        float mark = 0f;

        foreach (var competition in competitions)
        {
            mark += competition.TryGetMarkBySportsmanId(Id);
        }

        return mark;
    }

    public void UpdateInfo(string fullName, int age, string phoneNumber, Guid specializationId, Guid sportClubId, Guid coachId)
    {
        FullName = fullName;
        Age = age;
        PhoneNumber = phoneNumber;
        _specialization = specializationId;
        _sportClubId = sportClubId;
        _coach = coachId;
    }
}