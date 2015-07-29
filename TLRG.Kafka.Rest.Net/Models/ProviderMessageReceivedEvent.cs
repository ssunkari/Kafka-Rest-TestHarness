using Newtonsoft.Json;

namespace Tlrg.Kafka.Rest.Net.Models
{
    public class ProviderMessageReceivedEvent
    {
        [JsonProperty("ProviderName")]
        public string ProviderName { get; set; }
        [JsonProperty("CorrelationId")]
        public string CorrelationId { get; set; }
        [JsonProperty("ContentType")]
        public string ContentType { get; set; }
        [JsonProperty("Body")]
        public string Body { get; set; }
    }
}