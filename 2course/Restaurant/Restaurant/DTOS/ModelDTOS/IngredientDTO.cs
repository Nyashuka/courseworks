using Newtonsoft.Json;
using System;


namespace Restaurant
{
    public class IngredientDTO
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("price_per_one_kilogram")]
        public double PricePerOneKilogram { get; set; }
    }
}
