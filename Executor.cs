using System;

namespace KafkaTester
{
    internal class Executor
    {
        private readonly MessageProducer messageProducer;

        public Executor()
        {
            this.messageProducer = new MessageProducer();
        }

        internal void Run()
        {
            Console.WriteLine("Running...");
        }
    }
}