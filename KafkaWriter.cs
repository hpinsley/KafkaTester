namespace KafkaTester
{
    using System;
    using System.Threading;
    using Confluent.Kafka;

    public class MessageProducer : IDisposable
    {
        private ProducerConfig producerConfig;
        private readonly Producer<string, string> producer;

        public MessageProducer()
        {
            this.producerConfig = new ProducerConfig
            {
                BootstrapServers = "localhost:29092"
            };

            this.producer = new Producer<string,string>(this.producerConfig);
        }
        public void Dispose()
        {
            this.producer.Dispose();
        }

        public void ProduceMessage(string topic, string key, string value)
        {
            var message = new Message<string, string> {
                Key = key,
                Value = value
            };

            var result = this.producer.ProduceAsync(topic, message).Result;
            Console.WriteLine($"Produced {topic} key {key} at offset {result.Offset} ");
        }
    }
}
