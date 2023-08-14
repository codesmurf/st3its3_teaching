using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces_ECG
{
    public class ProcessingExtremes : IProcessing
    {
        public void Process(List<int> samples)
        {
            int min = samples[0];
            int max = samples[0];

            foreach (int sample in samples)
            {
                if (sample < min)
                {
                    min = sample;
                }

                if (sample > max)
                {
                    max = sample;
                }
            }

            Console.WriteLine("Min: {0}, max: {1}", min, max);
        }
    }
}
