namespace HospitalBed.Filtering
{
    public class NoiseFilter : IFilter
    {
        private readonly int _threshold;
        private bool _currentOutput;
        private int _falseCount;
        private int _trueCount;

        public NoiseFilter(int threshold = 3)
        {
            _threshold = threshold;
            _trueCount = 0;
            _falseCount = 0;
            _currentOutput = false;
        }

        public bool FilterSample(bool sample)
        {
            if (sample)
            {
                ++_trueCount;
                _falseCount = 0;
            }
            else
            {
                ++_falseCount;
                _trueCount = 0;
            }

            // Change output iff enough consecutive samples of same values have been detected
            if (_trueCount >= _threshold) _currentOutput = true;
            else if (_falseCount >= _threshold) _currentOutput = false;

            return _currentOutput;
        }
    }
}