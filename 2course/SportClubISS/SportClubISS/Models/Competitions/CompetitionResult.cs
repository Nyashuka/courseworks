using System;
using Newtonsoft.Json;
using SportClubISS.Infrastructure.Services;

namespace SportClubISS.Models.Competitions;

public class CompetitionResult
{
    [JsonProperty("sportsman_id")] private Guid _sportsman;
    [JsonProperty("mark")] private float _mark;

    [JsonIgnore] public Guid SportsmanId => _sportsman;
    [JsonIgnore] public string SportsmanName => Repository.Instance.GetSportsmenByGuid(_sportsman).FullName;
    [JsonIgnore] public float Mark => _mark;
    
    [JsonConstructor]
    public CompetitionResult([JsonProperty("sportsman_id")] Guid sportsman,  [JsonProperty("mark")] float mark)
    {
        _sportsman = sportsman;
        _mark = mark;
    }
    
    public void AddHalfMark()
    {
        _mark += 0.5f;
    }

    public void SubtractHalfMark()
    {
        if (Mark <= 0f)
        {
            _mark = 0f;
        }
        else
        {
            _mark -= 0.5f;
        }
    }
}