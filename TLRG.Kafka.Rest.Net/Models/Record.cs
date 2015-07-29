using Newtonsoft.Json;

namespace Tlrg.Kafka.Rest.Net.Models
{
    public class Record
    {
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }
    }
}