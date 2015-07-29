using System.Collections.Generic;
using Newtonsoft.Json;
using Tlrg.Kafka.Rest.Net.Models;

namespace Tlrg.Kafka.Rest.Net.Extensions
{
    public class JsonParser
    {
        public static List<ProviderMessageReceivedEvent> JsonToProviderMessage(string json)
        {
            return JsonConvert.DeserializeObject<List<ProviderMessageReceivedEvent>>(json);
        }
    }
}