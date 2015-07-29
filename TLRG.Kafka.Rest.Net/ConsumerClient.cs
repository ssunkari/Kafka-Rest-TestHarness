using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Tlrg.Kafka.Rest.Net.Extensions;
using Tlrg.Kafka.Rest.Net.Models;

namespace Tlrg.Kafka.Rest.Net
{
    public class ConsumerClient
    {
        private readonly ConfluentClient _client;
        private ConsumerResponse _consumer;

        public ConsumerClient()
        {
            _client = new ConfluentClient(KafkaClientConfig.Uri);
        }
        public void Start(string topic, string consumerGroup, int? maxbytes = null)
        {
            Task.Run(() =>
            {
                _consumer = CreateConsumer(consumerGroup);
                int messageCtr = 0;

                while (true)
                {
                    string messages = null;

                    try
                    {
                        if (_consumer == null)
                        {
                            _consumer = CreateConsumer(consumerGroup);
                        }

                        messages = _client.Consume(topic, consumerGroup, _consumer.InstanceId, maxbytes).Result;


                        if (messages != null)
                        {
                            messages = messages.Replace("\\", "");
                            var serializedMsgs = JsonParser.JsonToProviderMessage(messages);
                            Console.WriteLine("No. of Messages Received {0}", serializedMsgs.Count);

                            messageCtr += serializedMsgs.Count();

                            if (messageCtr % 10 == 0)
                            {
                                var response = _client.CommitOffSet(consumerGroup, _consumer.InstanceId).Result;
                                Console.WriteLine("Commited the offset for Instance Id {0}, Response Returned : {1}", _consumer.InstanceId, response);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No Messages Received");
                        }
                    }
                    catch (Exception ex)
                    {
                        _consumer = null;
                        Console.WriteLine("Exception Occured stack trace{0} and actual response {1}", ex.Message, messages);
                        Thread.Sleep(1000);
                    }
                }
            });
        }

        private ConsumerResponse CreateConsumer(string consumerGroup)
        {
            ConsumerResponse consumerResponse = null;
            string result = null;

            try
            {
                result = _client.CreateConsumer(consumerGroup).Result;
                consumerResponse =
                    JsonConvert.DeserializeObject<ConsumerResponse>(result);
                Console.WriteLine("Consumer Created Instance with Id : {0}", consumerResponse.InstanceId);
            }
            catch (Exception ex)
            {

                Console.WriteLine("Consumer Could not be created stack trace{0} and actual response {1}", ex.Message, result);
            }

            return consumerResponse;
        }


        public void Dispose(string consumerGroup)
        {
            if (_client != null)
            {
                DisposeConsumer(consumerGroup);
                _client.Dispose();
            }
        }

        private string DisposeConsumer(string consumerGroup)
        {
            try
            {
                var disposeConsumer = _client.DeleteConsumer(consumerGroup, _consumer.InstanceId).Result;
                Console.WriteLine("Disposed the Consumer Instance with response {0}", disposeConsumer);
                return disposeConsumer;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Consumer could not be disposed stack trace{0}", ex.Message);
            }
            return null;
        }
    }
}
