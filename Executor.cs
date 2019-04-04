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