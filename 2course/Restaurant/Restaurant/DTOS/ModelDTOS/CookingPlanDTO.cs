using Newtonsoft.Json;
using System.Collections.Generic;


namespace Restaurant
{
    public class CookingPlanDTO
    {
        [JsonProperty("orders")]
        public HashSet<OrderDTO> Orders { get; set; } = new HashSet<OrderDTO>();
    }
}
