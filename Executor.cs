using System;
using Newtonsoft.Json;

namespace KafkaTester
{
    internal class Executor
    {
        private readonly MessageProducer messageProducer;
        private readonly MockDb mockDb;

        public Executor()
        {
            this.messageProducer = new MessageProducer();
            this.mockDb = new MockDb();
        }

        internal void Run()
        {
            Console.WriteLine("Running...");
            WriteAllSecurities();
            WriteRandomPositions(10);
        }

        private void WriteRandomPositions(int count)
        {
            var positions = this.mockDb.GenerateRandomPositions(count);
            var topic = "Positions";

            foreach (var position in positions)
            {
                var key = JsonConvert.SerializeObject(position.SecurityMasterId);
                var value = JsonConvert.SerializeObject(position);
                this.messageProducer.ProduceMessage(topic, key, value);
            }
        }

        private void WriteAllSecurities()
        {
            var securities = this.mockDb.GetAllSecurities();
            var topic = "SecurityMaster";

            foreach (var security in securities)
            {
                var key = JsonConvert.SerializeObject(security.SecurityMasterId);
                var value = JsonConvert.SerializeObject(security);
                Console.WriteLine($"Key: {key} Body: {value}");
                this.messageProducer.ProduceMessage(topic, key, value);
            }
        }
    }
}