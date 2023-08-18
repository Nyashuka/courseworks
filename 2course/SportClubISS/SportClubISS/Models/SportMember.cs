using System;
using Newtonsoft.Json;
using SportClubISS.Infrastructure.Services;
using SportClubISS.Models.Rating;

namespace SportClubISS.Models;

public class SportMember : Person, IRating
{
    [JsonProperty("specialization_id")] protected Guid _specialization;
    [JsonProperty("sport_club_id")] protected Guid _sportClubId;
    [JsonIgnore] protected IRating _ratingCalculator;
    
    [JsonIgnore] public Guid SportClubId => _sportClubId;
    [JsonIgnore] public Guid SpecializationId => _specialization;
    [JsonIgnore] public string SpecializationName => Repository.Instance.GetSpecializationByGuid(_specialization).Title;
    [JsonIgnore] public float Rating => GetRatingScore();
    
    [JsonConstructor]
    public SportMember(Guid id, 
        string fullName, int age, string phoneNumber,
        [JsonProperty("specialization_id")]Guid specialization, Guid sportClubGuid) : 
        base(id, fullName, age, phoneNumber)
    {
        _specialization = specialization;
        _sportClubId = sportClubGuid;
    }


    public float GetRatingScore()
    {
        return _ratingCalculator.GetRatingScore();
    }
}