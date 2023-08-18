using System;
using Newtonsoft.Json;


namespace SportClubISS.Models;

public class Specialization
{
    [JsonProperty("id")] public Guid Id { get; }
    [JsonProperty("title")] public string Title { get; }

    [JsonConstructor]
    public Specialization([JsonProperty("id")] Guid id, [JsonProperty("title")] string title)
    {
        Id = id;
        Title = title;
    }
}
