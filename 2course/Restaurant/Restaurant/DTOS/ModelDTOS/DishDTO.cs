using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace Restaurant
{
    public class DishDTO
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("price_per_serving")]
        public double PricePerServing { get; set; }

        [JsonProperty("weight_in_one_serving")]
        public WeightDTO WeightInOneServing { get; set; }

        [JsonProperty("recipe")]
        public HashSet<IngredientWeightDTO> Recipe { get; set; } = new HashSet<IngredientWeightDTO>();
    }
}
