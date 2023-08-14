using System;
using System.Collections.Generic;

namespace Interfaces_ECG
{
    public class ECGContainer
    {
        private List<int> _samples = new List<int>();
        private IProcessing _processing = new ExtremesProcessing();

        public ECGContainer(IProcessing processing)
        {
            _processing = processing;
        }

        public void AddSample(int sample)
        {
            _samples.Add(sample);
        }

        public void ProcessSamples()
        {
            _processing.Process(_samples);
        }

        public int Count
        {
            get { return _samples.Count; }
        }
    }
}
