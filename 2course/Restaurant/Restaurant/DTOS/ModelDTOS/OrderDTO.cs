using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class OrderDTO
    {
        [JsonProperty("date")]
        public DateTimeContainerDTO Date { get;  set; }

        [JsonProperty("dishes_list")]
        public HashSet<DishCountDTO> Dishes { get;  set; } = new HashSet<DishCountDTO>();
    }
}
