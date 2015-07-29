using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json;

namespace Tlrg.Kafka.Rest.Net.Models
{
    public class KafkaRestResponse
    {
        [JsonProperty("error_code")]
        public string ErrorCode { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        [JsonProperty("offsets")]
        public IEnumerable<Offset> Offsets { get; set; }
    }
}