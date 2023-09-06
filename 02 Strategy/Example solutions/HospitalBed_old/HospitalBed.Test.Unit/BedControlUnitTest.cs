using System.Threading;
using NUnit.Framework;

namespace HospitalBed.Test.Unit
{
    [TestFixture]
    public class BedControlUnitTest
    {
        private AutoResetEvent _dataReadyEvent;
        private AutoResetEvent _dataConsumedEvent;
        private PresenceSensorDataContainer _container;
        private FakeAlarm _alarm;
        private FakeFilter _filter;
        private BedControl _uut;

        [SetUp]
        public void SetUp()
        {
            _dataReadyEvent = new AutoResetEvent(false);
            _dataConsumedEvent = new AutoResetEvent(false);
            _container = new PresenceSensorDataContainer();
            _alarm = new FakeAlarm();
            _filter = new FakeFilter();

            _uut = new BedControl(_dataConsumedEvent, _dataReadyEvent, _container, _alarm, _filter);
        }


        [Test]
        public void DataReadyEventSet_HandleSample_DataConsumedEventSet()
        { 
            _dataReadyEvent.Set();
            _uut.HandleOneSample();
            
            Assert.True(_dataConsumedEvent.WaitOne(0));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void PresenceDataReady_HandleSample_FilterCalled(bool sample)
        {
            // arrange
            _container.PresenceDetected = sample;
            
            // act
            _dataReadyEvent.Set();
            _uut.HandleOneSample();
            
            // assert
            Assert.AreEqual(_filter.lastSample, sample);
            Assert.AreEqual(_filter.filterCalledCount, 1);
        }

        [Test]
        public void PresenceDataReady_FilterReturnsFalse_AlarmSounded()
        {
            _filter.returnValue = false; // fake the return value from the filter

            _dataReadyEvent.Set();
            _uut.HandleOneSample();

            Assert.AreEqual(_alarm.soundCalledCount, 1);
            Assert.AreEqual(_alarm.silenceCalledCount, 0);
        }

        [Test]
        public void PresenceDataReady_FilterReturnsTrue_AlarmSilenced()
        {
            _filter.returnValue = true; // fake the return value from the filter

            _dataReadyEvent.Set();
            _uut.HandleOneSample();

            Assert.AreEqual(_alarm.silenceCalledCount, 1);
            Assert.AreEqual(_alarm.soundCalledCount, 0);
        }

    }

    class FakeFilter : IFilter
    {
        public bool lastSample = false;
        public int filterCalledCount = 0;
        public bool returnValue = false;
        
        public bool FilterSample(bool sample)
        {
            lastSample = sample;
            filterCalledCount++;
            return returnValue;
        }
    }

    class FakeAlarm : IAlarm
    {
        public int soundCalledCount = 0;
        public int silenceCalledCount = 0;

        public void TurnOn()
        {
            soundCalledCount++;
        }

        public void TurnOff()
        {
            silenceCalledCount++;
        }
    }
}
