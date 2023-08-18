using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class IngredientWeightDTO
    {
        [JsonProperty("ingredient")]
        public IngredientDTO Ingredient { get; set; } = new IngredientDTO();

        [JsonProperty("weight")]
        public WeightDTO Weight { get; set; }
    }
}
