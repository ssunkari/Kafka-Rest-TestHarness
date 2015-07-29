using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tlrg.Kafka.Rest.Net.Models
{
    public class PublishRequest
    {
        [JsonProperty(PropertyName = "records")]
        public List<Record> Records { get; set; }
    }
}