using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalBedLib.Filters;
using NUnit.Framework;

namespace HospitalBedUnitTests.Filters
{
    [TestFixture]
    public class NConsecutiveFilterTest
    {
        private NConsecutiveFilter filter;

        [SetUp]
        public void Setup()
        {
            filter = new NConsecutiveFilter();
        }

        [Test]
        public void Test_Filter_OneSample_SampleValue()
        {
            bool actual = filter.Filter(true);
            Assert.That(actual, Is.True);
        }

        [Test]
        public void Test_Filter_TwoDifferentSamples_True()
        {
            filter.Filter(true);
            bool actual = filter.Filter(false);

            Assert.That(actual, Is.True);
        }

        [Test]
        public void Test_Filter_TwoDifferentSamples_False()
        {
            filter.Filter(false);
            bool actual = filter.Filter(true);

            Assert.That(actual, Is.False);
        }

        [Test]
        public void Test_Filter_ThreeEqualSamples_SampleValue()
        {
            filter.Filter(false);
            filter.Filter(false);
            bool actual = filter.Filter(false);

            Assert.That(actual, Is.False);
        }

        [Test]
        public void Test_Filter_ThreeEqualSamplesThenNew_SampleValue()
        {
            filter.Filter(false);
            filter.Filter(false);
            filter.Filter(false);
            bool actual = filter.Filter(true);

            Assert.That(actual, Is.False);
        }
    }
}
