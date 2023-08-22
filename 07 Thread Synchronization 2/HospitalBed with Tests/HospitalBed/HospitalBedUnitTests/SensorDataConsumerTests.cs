using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalBedLib;
using HospitalBedLib.Buzzers;
using NUnit.Framework;

namespace HospitalBedUnitTests
{
    [TestFixture]
    public class SensorDataConsumerTests
    {
        private FakeBuzzer fakeBuzzer;
        private BlockingCollection<DataContainer> queue;
        private SensorDataConsumer sensorDataConsumer;

        [SetUp]
        public void Setup()
        {
            fakeBuzzer = new FakeBuzzer();
            queue = new BlockingCollection<DataContainer>();
            sensorDataConsumer = new SensorDataConsumer(fakeBuzzer, queue)
            {
                WaitTimeInMillies = 10
            };
        }

        [Test]
        public void Test_TrueSent_NoBuzzExpected()
        {
            AddToQueue(true);
            queue.CompleteAdding();

            sensorDataConsumer.Run();

            Assert.That(fakeBuzzer.called, Is.EqualTo(0));
        }

        [Test]
        public void Test_FalseSent_BuzzExpected()
        {
            AddToQueue(false);
            queue.CompleteAdding();

            sensorDataConsumer.Run();

            Assert.That(fakeBuzzer.called, Is.EqualTo(1));
        }

        [Test]
        public void Test_FalseFalseSent_BuzzExpected()
        {
            AddToQueue(false);
            AddToQueue(false);
            queue.CompleteAdding();

            sensorDataConsumer.Run();

            Assert.That(fakeBuzzer.called, Is.EqualTo(2));
        }

        [Test]
        public void Test_FalseTrueSent_BuzzExpected()
        {
            AddToQueue(false);
            AddToQueue(true);
            queue.CompleteAdding();

            sensorDataConsumer.Run();

            Assert.That(fakeBuzzer.called, Is.EqualTo(1));
        }

        private void AddToQueue(bool sample)
        {
            queue.Add(new DataContainer()
            {
                Pressed = sample
            });

        }

        private class FakeBuzzer: IBuzzer
        {
            public int called = 0;
            public void Buzz()
            {
                called++;
            }
        }
    }
}
