namespace Exercise2
{
    class Counter
    {
        private readonly int _numberOfTimes = 0;
        private readonly TotalCount _totalCount;

        public Counter(int numberOfTimes, TotalCount totalCount)
        {
            _numberOfTimes = numberOfTimes;
            _totalCount = totalCount;
        }

        public void StartCounting()
        {
            for (int i = 0; i < _numberOfTimes; i++)
            {
                _totalCount.Increment();
            }
        }
    }
}
