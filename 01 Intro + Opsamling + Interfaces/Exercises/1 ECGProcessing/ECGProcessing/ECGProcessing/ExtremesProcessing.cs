using System;
using System.Collections.Generic;

namespace Interfaces_ECG
{
    public class ExtremesProcessing : IProcessing
    {
        public void Process(List<int> samples)
        {
            int min = Int32.MaxValue;
            int max = Int32.MinValue;

            foreach (var sample in samples)
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


            Console.WriteLine("Maximum value: {0}", max);
            Console.WriteLine("Minimum value: {0}", min);
        }
    }
}