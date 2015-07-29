using Newtonsoft.Json;

namespace Tlrg.Kafka.Rest.Net.Models
{
    public class Offset
    {
        [JsonProperty("partition")]
        public int Partition { get; set; }
        [JsonProperty("offset")]
        public int OffsetId { get; set; }
        [JsonProperty("error_code")]
        public string ErrorCode { get; set; }
        [JsonProperty("error")]
        public string Error { get; set; }
    }
}