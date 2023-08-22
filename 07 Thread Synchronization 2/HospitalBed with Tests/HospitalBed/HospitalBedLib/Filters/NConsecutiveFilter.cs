using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalBedLib.Filters
{
    public class NConsecutiveFilter : IFilter
    {
        public int NumberOfConsecutiveSamples { get; set; } = 3;

        private bool latestReturnValue = true;
        private readonly FixedSizedList<bool> samples = new FixedSizedList<bool>(3);

        public bool Filter(bool sample)
        {
            samples.AddData(sample);

            if (samples.GetData().TrueForAll(s => s == sample))
            {
                latestReturnValue = sample;
            }

            return latestReturnValue;
        }
    }

    internal class FixedSizedList<A>
    {
        private readonly int size;
        private readonly List<A> data = new List<A>();

        public  FixedSizedList(int size)
        {
            this.size = size;
        }

        public List<A> GetData()
        {
            return new List<A>(data);
        }

        public void AddData(A sample)
        {
            data.Add(sample);
            if (data.Count > size) data.RemoveAt(0);
        }
    }
}
