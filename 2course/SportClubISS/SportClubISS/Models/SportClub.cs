using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SportClubISS.Infrastructure.Services;

namespace SportClubISS.Models;

public class SportClub
{
    [JsonProperty("id")] private Guid _id;
    [JsonProperty("name")] private string _name;
    [JsonProperty("specialization_id")] private Guid _specializationId;

    [JsonProperty("coaches")] private List<Guid> _coaches;

    [JsonIgnore] public Guid Id => _id;
    [JsonIgnore] public string Name => _name;
    public Specialization Specialization => Repository.Instance.GetSpecializationByGuid(_specializationId);

    public SportClub(Guid id, string name, Guid specializationId)
    {
        _id = id;
        _name = name;
        _specializationId = specializationId;
        _coaches = new List<Guid>();
    }

    [JsonConstructor]
    public SportClub(
        [JsonProperty("id")] Guid id, 
        [JsonProperty("name")] string name, 
        [JsonProperty("specializationId")] Guid specializationId, 
        [JsonProperty("coaches")] List<Guid> coaches)
        : this(id, name, specializationId)
    {
        _coaches = coaches;
    }
}