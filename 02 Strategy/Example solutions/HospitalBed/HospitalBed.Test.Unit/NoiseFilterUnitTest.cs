using NUnit.Framework;

namespace HospitalBed.Test.Unit
{
    [TestFixture]
    class NoiseFilterUnitTest
    {
        private NoiseFilter _uut;
        private int Threshold = 3;
        [SetUp]
        public void SetUp()
        {
            _uut = new NoiseFilter(Threshold);
        }

        private void SetFilterOutput(bool output)
        {
            for (int i = 0; i < Threshold; i++) _uut.FilterSample(output);
        }


        [TestCase(false, false, false)]
        [TestCase(false, false, true)]
        [TestCase(false, true, false)]
        [TestCase(false, true, true)]
        [TestCase(true, false, false)]
        [TestCase(true, false, true)]
        [TestCase(true, true, false)]
        public void FilterOutputFalse_SequenceOfVaryingSamples_FilterOutputRemainsFalse(bool s1, bool s2, bool s3)
        {
            _uut.FilterSample(s1);
            _uut.FilterSample(s2);
            var output = _uut.FilterSample(s3);
            Assert.That(output, Is.False);
        }

        public void FilterOutputFalse_CurOutputFalse_SequenceOfThreeTrueSamples_FilterOutputTrue()
        {
            _uut.FilterSample(true);
            _uut.FilterSample(true);
            var output = _uut.FilterSample(true);
            Assert.That(output, Is.True);
        }

        [TestCase(false, false, true)]
        [TestCase(false, true, false)]
        [TestCase(false, true, true)]
        [TestCase(true, false, false)]
        [TestCase(true, false, true)]
        [TestCase(true, true, false)]
        public void FilterOutputTrue_SequenceOfVaryingSamples_FilterOutputRemainsTrue(bool s1, bool s2, bool s3)
        {
            SetFilterOutput(true);

            _uut.FilterSample(s1);
            _uut.FilterSample(s2);
            var output = _uut.FilterSample(s3);
            Assert.That(output, Is.True);
        }

        public void FilterOutputTrue_SequenceOfThreeFalseSamples_FilterOutputFalse()
        {
            SetFilterOutput(true);

            _uut.FilterSample(false);
            _uut.FilterSample(false);
            var output = _uut.FilterSample(false);
            Assert.That(output, Is.False);
        }


    }
}
