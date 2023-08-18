using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SportClubISS.Infrastructure.Services;

namespace SportClubISS.Models.Competitions;

public class Competition
{

    [JsonProperty("id")] private Guid _id;
    [JsonProperty("name")] private string _name;
    [JsonProperty("event_date")] private DateTime _eventDate;
    [JsonProperty("specialization_id")] private Guid _specialization;
    [JsonProperty("status")] private CompetitionStatus _status;
    [JsonProperty("members")] private List<CompetitionResult> _members;
    
    [JsonIgnore]public Guid Id => _id;
    
    [JsonIgnore] public string Name => _name;

    [JsonIgnore] public DateTime EventDate => _eventDate;

    [JsonIgnore] public Guid Specialization => _specialization;

    [JsonIgnore] public CompetitionStatus Status => _status;

    [JsonIgnore] public List<CompetitionResult> Members => _members;

    [JsonIgnore] public string SpecializationName => Repository.Instance.GetSpecializationByGuid(Specialization).Title;
    
    [JsonConstructor]
    public Competition(
        [JsonProperty("id")] Guid id, 
        [JsonProperty("name")] string name, 
        [JsonProperty("event_date")]DateTime eventDate, 
        [JsonProperty("specialization_id")] Guid specialization, 
        [JsonProperty("status")] CompetitionStatus status,
        [JsonProperty("members")] List<CompetitionResult> members)
    {
        _id = id;
        _name = name;
        _eventDate = eventDate;
        _specialization = specialization;
        _status = status;
        _members = members;
    }

    public float TryGetMarkBySportsmanId(Guid sportsmanId)
    {
        foreach (var member in _members)
        {
            if (member.SportsmanId == sportsmanId)
                return member.Mark;
        }
        
        return 0f;
    }

    public void RemoveMember(Guid guid)
    {
        _members.RemoveAll(x => x.SportsmanId == guid);
    }
}