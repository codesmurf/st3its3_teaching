using System;
using System.Collections.Generic;

namespace Interfaces_ECG
{
    public class ProcessingPrint : IProcessing
    {
        public void Process(List<int> samples)
        {
            foreach (var sample in samples)
            {
                Console.WriteLine("Sample: {0}", sample);
            }
        }
    }
}
