using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1
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
                _totalCount.Count = _totalCount.Count + 1;
            }
        }
    }
}
