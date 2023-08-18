using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using SportClubISS.Models;
using SportClubISS.Models.Competitions;
using SportClubISS.Models.Rating;

namespace SportClubISS.Infrastructure.Services;

public class Repository
{
    private const string StoragePath = "storage.json";
    public static Repository Instance { get; } = new Repository();

    private readonly List<SportClub> _sportClubs;
    private readonly List<Coach> _coaches;
    private readonly List<Sportsman> _sportsmen;
    private readonly List<Specialization> _specializations;
    private readonly List<Competition> _competitions;

    private Repository()
    {
        RepositoryData data = ReadData();

        _sportClubs = data.SportClubs ?? new List<SportClub>();
        _coaches = data.Coaches ?? new List<Coach>();
        _sportsmen = data.Sportsmen ?? new List<Sportsman>();
        _specializations = data.Specializations ?? new List<Specialization>();
        _competitions = data.Competitions ?? new List<Competition>();
    }

    private RepositoryData ReadData()
    {
        if (File.Exists(StoragePath))
            return CJsonSerializator.Instance.Deserialize<RepositoryData>(StoragePath);

        return new RepositoryData();
    }

    public void SaveData()
    {
        RepositoryData data = new RepositoryData(_sportClubs, _coaches, _sportsmen, _specializations, _competitions);

        CJsonSerializator.Instance.Serialize(data, StoragePath);
    }

    public List<Specialization> GetAllSpecializations()
    {
        return _specializations;
    }

    public Specialization GetSpecializationByGuid(Guid specializationId)
    {
        try
        {
            return _specializations.FirstOrDefault(p => p.Id == specializationId);
        }
        catch (Exception e)
        {
            throw new NullReferenceException();
        }
    }

    public List<Coach> GetAllCoaches()
    {
        return _coaches;
    }

    public List<Sportsman> GetAllSportsmen()
    {
        return _sportsmen;
    }

    public void CreateSpecialization(string name)
    {
        _specializations.Add(new Specialization(Guid.NewGuid(), name));
    }

    public void DeleteSpecializationByGuid(Guid guid)
    {
        var specializationToDelete = _specializations.FirstOrDefault(p => p.Id == guid);
        if (specializationToDelete != null) _specializations.Remove(specializationToDelete);
    }

    public void CreateSportsman(string fullName, int age, string phoneNumber, Guid specGuid, Guid sportClubGuid,
        Guid coach)
    {
        var id = Guid.NewGuid();
        _sportsmen.Add(new Sportsman(id, fullName, age, phoneNumber, specGuid, sportClubGuid,
            coach));
    }

    public void DeleteSportsmanByGuid(Guid guid)
    {
        var sportsmanToDelete = _sportsmen.FirstOrDefault(p => p.Id == guid);
        if (sportsmanToDelete != null) _sportsmen.Remove(sportsmanToDelete);

        foreach (var competition in _competitions)
        {
            competition.RemoveMember(guid);
        }
    }

    public void CreateCoach(string fullName, int age, string phoneNumber, Guid specGuid, Guid sportClubGuid)
    {
        _coaches.Add(new Coach(Guid.NewGuid(), fullName, age, phoneNumber,
            specGuid, sportClubGuid,
            new List<Guid>()));
    }

    public void DeleteCoachByGuid(Guid guid)
    {
        var coachToDelete = _coaches.FirstOrDefault(p => p.Id == guid);
        if (coachToDelete != null) _coaches.Remove(coachToDelete);
    }

    public void CreateSportClub(string name, Guid specGuid)
    {
        _sportClubs.Add(new SportClub(Guid.NewGuid(), name, specGuid));
    }

    public void DeleteSportClubByGuid(Guid guid)
    {
        var sportClubToDelete = _sportClubs.FirstOrDefault(p => p.Id == guid);
        if (sportClubToDelete != null) _sportClubs.Remove(sportClubToDelete);
    }

    public List<SportClub> GetAllSportClubs()
    {
        return _sportClubs;
    }

    public List<Competition> GetAllCompetitions()
    {
        return _competitions;
    }

    public bool TryGetSportsmenByGuid([DisallowNull] ref Sportsman? sportsman, Guid sportsmanId)
    {
        sportsman = _sportsmen.FirstOrDefault(s => s.Id == sportsmanId);

        if (sportsman == null) return false;

        return true;
    }

    public Sportsman GetSportsmenByGuid(Guid sportsmanId)
    {
        return _sportsmen.FirstOrDefault(s => s.Id == sportsmanId);
    }

    public void CreateCompetition(Guid newGuid, string name, DateTime eventDate, Guid specializationId,
        CompetitionStatus status, List<CompetitionResult> members)
    {
        _competitions.Add(new Competition(newGuid, name, eventDate, specializationId, status, members));
    }

    public Coach GetCoachByGuid(Guid coachGuid)
    {
        return _coaches.FirstOrDefault(c => c.Id == coachGuid);
    }

    public SportClub GetSportClubByGuid(Guid sportClubId)
    {
        return _sportClubs.FirstOrDefault(c => c.Id == sportClubId);
    }

    public void DeleteCompetition(Guid id)
    {
        var competitionToDelete = _competitions.FirstOrDefault(p => p.Id == id);
        if (competitionToDelete != null) _competitions.Remove(competitionToDelete);
    }
}