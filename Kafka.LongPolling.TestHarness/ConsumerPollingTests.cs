using System;
using System.Threading;
using NUnit.Framework;
using Tlrg.Kafka.Rest.Net;

namespace Kafka.LongPolling.TestHarness
{
    public class ConsumerPollingTests : KafkaPubSubIntegrationTests
    {
        //Default Message size is apprx 5KB
        //Running Tests Under Kafka Rest Default Settings
        //Please Look at the Output Console.
        //Behavoiur I observed is timeout setting is meeting first (i.e default is 1sec) and responds back with 1st batch which is max bytes that I have supplied
        //When I start Polling For Messages KafkaRest waits for 1 second request timeout and responds with batch of messages
        //What I really want is I want to recieve a message as soon as it arrives (Low Latency under 200ms)
        //I want to be able to open a connection and poll mesasges without making too many http requests.
        [Test]
        public void ConsumerShouldPollOnlyOneMessagePerBatch()
        {
            PublishMessage(TestConstants.Topic);
            var waitHandle = new Semaphore(0, 1);
            var consumerClient = new ConsumerClient();
            consumerClient.Start(TestConstants.Topic, TestConstants.ConsumerGroup, 7500);
            try
            {
               
                waitHandle.WaitOne(10000);
            }
            finally
            {
                consumerClient.Dispose(TestConstants.ConsumerGroup);
            }
        }

        [Test]
        public void ConsumerShouldPollAtleastTwoMessagePerBatch()
        {
            PublishMessage(TestConstants.Topic);
            var waitHandle = new Semaphore(0, 1);
            var consumerClient = new ConsumerClient();
            consumerClient.Start(TestConstants.Topic, TestConstants.ConsumerGroup, 15000);
            try
            {
                waitHandle.WaitOne(10000);
            }
            finally
            {
                consumerClient.Dispose(TestConstants.ConsumerGroup);
            }
        }

        [Test]
        public void ConsumerShouldPollAtleastAMessageWithin200ms()
        {
            PublishMessage(TestConstants.Topic);
            var waitHandle = new Semaphore(0, 1);
            var consumerClient = new ConsumerClient();
            consumerClient.Start(TestConstants.Topic, TestConstants.ConsumerGroup, 7500);
            try
            {

                waitHandle.WaitOne(1800);
            }
            finally
            {
                consumerClient.Dispose(TestConstants.ConsumerGroup);
            }

        }
    }
}