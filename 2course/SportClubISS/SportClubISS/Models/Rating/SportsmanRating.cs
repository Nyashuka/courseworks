using System;
using SportClubISS.Infrastructure.Services;

namespace SportClubISS.Models.Rating;

public class SportsmanRating : IRating
{
    private Guid _sportsmanId;

    public SportsmanRating(Guid sportsmanId)
    {
        _sportsmanId = sportsmanId;
    }
    
    public float GetRatingScore()
    {
        var competitions = Repository.Instance.GetAllCompetitions();
        float mark = 0f;

        foreach (var competition in competitions)
        {
            mark += competition.TryGetMarkBySportsmanId(_sportsmanId);
        }

        return mark;
    }
}