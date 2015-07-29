using Newtonsoft.Json;

namespace Tlrg.Kafka.Rest.Net.Models
{
    public class CreateConsumerRequest
    {
        public CreateConsumerRequest()
        {
            Format = "binary";
            AutoOffsetReset = "smallest";
        }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "format")]
        public string Format { get; set; }

        [JsonProperty(PropertyName = "auto.offset.reset")]
        public string AutoOffsetReset { get; set; }

        [JsonProperty(PropertyName = "auto.commit.enable")]
        public bool AutoCommitEnabled { get; set; }
    }
}