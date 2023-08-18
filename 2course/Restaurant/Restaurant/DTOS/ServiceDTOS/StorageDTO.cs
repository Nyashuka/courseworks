using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class StorageDTO
    {
        [JsonProperty("ingredient_list")]
        public HashSet<IngredientWeightDTO> Ingredients { get; set; } = new HashSet<IngredientWeightDTO>();
       
        [JsonProperty("menu")]
        public List<DishDTO> Menu { get; set; } = new List<DishDTO>();
    }
}
