using System;
using Newtonsoft.Json;

namespace SportClubISS.Models;

public class Person : IComparable<Person>, IEquatable<Person>
{
    [JsonProperty("id")]
    public Guid Id { get; }
    
    [JsonProperty("full_name")]
    public string FullName { get; protected set;}
    
    [JsonProperty("age")]
    public int Age { get; protected set;}
    
    [JsonProperty("phone_number")]
    public string PhoneNumber { get; protected set;}

    
    [JsonConstructor]
    public Person(
        [JsonProperty("id")]Guid id, 
        [JsonProperty("full_name")]string fullName, 
        [JsonProperty("age")]int age, 
        [JsonProperty("phone_number")] string phoneNumber)
    {
        Id = id;
        FullName = fullName;
        Age = age;
        PhoneNumber = phoneNumber;
    }

    public string GetPersonInfo()
    {
        return $"Full name: {FullName}\nAge: {Age}";
    }

    public int CompareTo(Person? other)
    {
        if (other == null) return 1;

        return string.Compare(FullName, other.FullName, StringComparison.Ordinal);
    }

    public bool Equals(Person? other)
    {
        if (other == null)
            return false;

        return Id.Equals(other.Id);
    }
}