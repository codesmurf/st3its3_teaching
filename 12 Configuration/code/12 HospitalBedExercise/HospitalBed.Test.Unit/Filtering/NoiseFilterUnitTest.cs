using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalBed.Filtering;
using NUnit.Framework;

namespace HospitalBed.Test.Unit
{
    [TestFixture]
    public class NoiseFilterUnitTest
    {
        private NoiseFilter uut;

        [SetUp]
        public void SetUp()
        {
            uut = new NoiseFilter();
        }

        [Test]
        public void Ctor_FalseSampleFiltered_OutputIsFalse()
        {
            bool result = uut.FilterSample(false);
            Assert.That( result, Is.False);
        }

        [Test]
        public void Ctor_TrueSampleFiltered_OutputIsFalse()
        {
            bool result = uut.FilterSample(true);
            Assert.That(result, Is.False);
        }


        [Test]
        public void FilterSample_TwoTrueSamplesFiltered_OutputIsFalse()
        {
            uut.FilterSample(true);
            bool result = uut.FilterSample(true);
            Assert.That(result, Is.False);
        }

        [Test]
        public void FilterSample_ThreeTrueSamplesFiltered_OutputIsTrue()
        {
            uut.FilterSample(true);
            uut.FilterSample(true);
            bool result = uut.FilterSample(true);
            Assert.That(result, Is.True);
        }

        [TestCase(false, false, false, false)]
        [TestCase(false, false, true, false)]
        [TestCase(false, true, true, false)]
        [TestCase(false, true, false, false)]
        public void FilterSample_ThreeSamplesFilteredInitiallyFalse_OutputIsFalse(bool s1, bool s2, bool s3, bool expectedResult)
        {
            uut.FilterSample(s1);
            uut.FilterSample(s2);
            bool result = uut.FilterSample(s3);
            Assert.That(result, Is.EqualTo(expectedResult));
        }


        [TestCase(true, true, false, true)]
        [TestCase(true, false, false, true)]
        [TestCase(false, false, false, false)]
        public void FilterSample_ThreeSamplesFilteredInitiallyTrue_OutputIsFalse(bool s1, bool s2, bool s3, bool expectedResult)
        {
            uut.FilterSample(true);
            uut.FilterSample(true);
            uut.FilterSample(true);
            uut.FilterSample(s1);
            uut.FilterSample(s2);
            bool result = uut.FilterSample(s3);
            Assert.That(result, Is.EqualTo(expectedResult));
        }

    }
}
