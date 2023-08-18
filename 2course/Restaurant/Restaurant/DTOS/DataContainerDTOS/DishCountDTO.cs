using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class DishCountDTO
    {
        [JsonProperty("dish")]
        public DishDTO Dish { get; set; } = new DishDTO();
        [JsonProperty("count")]
        public int Count { get; set; }
    }
}
