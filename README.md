# Kafka-Rest-TestHarness
This application is used to test the long polling behaviour for Kafka Rest Proxy

        //Default Message size is apprx 5KB
        //Run the ConsumerpollingTests.Cs Unit tests
        //Ran Tests Under Kafka Rest Default Settings
        //Please Look at the Output Console.
        //Behavoiur I observed is Consumer.request.timeout.ms has to meet first (i.e default is 1sec) and responds back with 1st batch which is max bytes
        //When I start Polling For Messages KafkaRest waits for 1 second request timeout and responds with batch of messages
        //What I really want is I want to recieve a message as soon as it arrives (Low Latency under 200ms)
        //I want to be able to open a connection and poll mesasges without making too many http requests.
