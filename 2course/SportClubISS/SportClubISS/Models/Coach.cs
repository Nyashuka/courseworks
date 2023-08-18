using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SportClubISS.Models.Rating;

namespace SportClubISS.Models;

public class Coach : SportMember
{
    [JsonProperty("sportsmen")] private List<Guid> _sportsmen;

    [JsonIgnore] public List<Guid> Sportsmen => _sportsmen;

    public Coach(Guid id, string fullName, int age, string phoneNumber, Guid specialization, Guid sportClubGuid, 
        [JsonProperty("sportsmen")]List<Guid> sportsmen ) : 
        base(id, fullName, age, phoneNumber,specialization, sportClubGuid)
    {
        _sportsmen = sportsmen;
        _ratingCalculator = new CoachRating(id);
    }
}