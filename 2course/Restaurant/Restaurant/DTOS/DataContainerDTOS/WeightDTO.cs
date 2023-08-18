using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public struct WeightDTO
    {
        [JsonProperty("amount")]
        public double Amount { get; set; }

        [JsonProperty("unit")]
        public UnitOfWeight Unit { get; set; }
    }
}
