using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SportClubISS.Models;
using SportClubISS.Models.Competitions;

namespace SportClubISS.Infrastructure.Services;

[Serializable]
public class RepositoryData
{ 
    [JsonProperty("sport_clubs")]
    public List<SportClub> SportClubs { get; }
    
    [JsonProperty("coaches")]
    public List<Coach> Coaches { get; }
    
    [JsonProperty("sportsmen")]
    public List<Sportsman> Sportsmen { get; }
    
    [JsonProperty("specializations")]
    public List<Specialization> Specializations { get; }
    
    [JsonProperty("competition_results")]
    public List<Competition> Competitions { get; }

    public RepositoryData()
    {
        SportClubs = new List<SportClub>();
        Coaches = new List<Coach>();
        Sportsmen = new List<Sportsman>();
        Specializations = new List<Specialization>();
        Competitions = new List<Competition>();
    }
    
    [JsonConstructor]
    public RepositoryData(
        [JsonProperty("sport_clubs")] List<SportClub> sportClubs, 
        [JsonProperty("coaches")] List<Coach> coaches, 
        [JsonProperty("sportsmen")] List<Sportsman> sportsmen, 
        [JsonProperty("specializations")] List<Specialization> specializations, 
        [JsonProperty("competition_results")] List<Competition> competitions)
    {
        SportClubs = sportClubs;
        Coaches = coaches;
        Sportsmen = sportsmen;
        Specializations = specializations;
        Competitions = competitions;
    }
}