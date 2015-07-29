using Newtonsoft.Json;

namespace Tlrg.Kafka.Rest.Net.Models
{
    public class ConsumerResponse
    {
        [JsonProperty("instance_id")]
        public string InstanceId { get; set; }

        [JsonProperty("base_uri")]
        public string BaseUri { get; set; }
    }
}