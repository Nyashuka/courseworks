using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public struct DateTimeContainerDTO
    {
        [JsonProperty("date_time")]
        public DateTime DateTime { get; set; }
    }
}
