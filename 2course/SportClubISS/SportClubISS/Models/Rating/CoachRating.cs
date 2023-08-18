using System;
using System.Collections.Generic;
using System.Linq;
using SportClubISS.Infrastructure.Services;

namespace SportClubISS.Models.Rating;

public class CoachRating : IRating
{
    private Guid _coachId;
    
    public CoachRating(Guid coachId)
    {
        _coachId = coachId;
    }
    
    public float GetRatingScore()
    {
        float mark = 0f;

        var coachesSportsmen= Repository.Instance.GetAllSportsmen().Where(s => s.Coach == _coachId).ToList();
        
        foreach (var sportsman in coachesSportsmen)
        {
            mark += sportsman.GetRatingScore();
        }

        return mark;
    }
}