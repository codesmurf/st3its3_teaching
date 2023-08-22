using System;
using System.Collections.Concurrent;
using System.Threading;
using HospitalBedLib.Filters;

namespace HospitalBedLib.Sensors
{
    public class SensorDataProducer
    {
        public int WaitTimeInMillies { get; set; } = 1000;
        private readonly BlockingCollection<DataContainer> queue;
        private readonly ISensor sensor;
        private readonly IFilter filter
            ;
        private bool notStopped = true;

        public SensorDataProducer(BlockingCollection<DataContainer> queue, ISensor sensor, IFilter filter)
        {
            this.queue = queue;
            this.sensor = sensor;
            this.filter = filter;
        }

        public void Run()
        {
            while (notStopped)
            {
                var sample = sensor.IsPressed();
                var isPressed = filter.Filter(sample);
                DataContainer dc = new DataContainer()
                {
                    Pressed = isPressed
                };
                queue.Add(dc);
                Thread.Sleep(WaitTimeInMillies); // Should be abstracted away to unit test
            }
            queue.CompleteAdding();
            Console.WriteLine("Producer stopping...");
        }

        public void Stop()
        {
            notStopped = false;
        }
    }
}
