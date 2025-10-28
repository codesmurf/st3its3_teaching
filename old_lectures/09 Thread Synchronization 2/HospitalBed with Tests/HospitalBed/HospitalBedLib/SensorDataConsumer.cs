using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HospitalBedLib.Buzzers;

namespace HospitalBedLib
{
    public class SensorDataConsumer
    {
        public int WaitTimeInMillies { get; set; } = 1000;
        private BlockingCollection<DataContainer> queue
            ;
        private IBuzzer buzzer;

        public SensorDataConsumer(IBuzzer buzzer, BlockingCollection<DataContainer> queue)
        {
            this.buzzer = buzzer;
            this.queue = queue;
        }

        public void Run()
        {
            while(!queue.IsCompleted)
            {
                try
                {
                    DataContainer dc = queue.Take();
                    if (!dc.Pressed)
                    {
                        buzzer.Buzz();
                    }

                } catch (InvalidOperationException)
                {
                    Console.WriteLine("Called take from queue that is completed");
                }
                Thread.Sleep(WaitTimeInMillies);
            }

            Console.WriteLine("SensorDataConsumer stopping");
        }
    }
}
