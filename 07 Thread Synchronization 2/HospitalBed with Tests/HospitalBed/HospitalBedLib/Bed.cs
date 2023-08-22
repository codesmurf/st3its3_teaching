using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HospitalBedLib.Buzzers;
using HospitalBedLib.Filters;
using HospitalBedLib.Sensors;

namespace HospitalBedLib
{
    public class Bed
    {
        private readonly BlockingCollection<DataContainer> sensorDataQueue;
        private readonly SensorDataConsumer sensorDataConsumer;
        private readonly SensorDataProducer sensorDataProducer;

        public Bed()
        {
            sensorDataQueue = new BlockingCollection<DataContainer>();
            sensorDataConsumer = new SensorDataConsumer(new Buzzer(), sensorDataQueue);
            sensorDataProducer = new SensorDataProducer(sensorDataQueue, new RandomSensor(), new NConsecutiveFilter());

        }

        public void Start()
        {
            Thread producer = new Thread(sensorDataProducer.Run);
            Thread consumer = new Thread(sensorDataConsumer.Run);

            producer.Start();
            consumer.Start();
        }

        public void Stop()
        {
            sensorDataProducer.Stop();
        }
    }
}
