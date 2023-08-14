using System.Collections.Generic;

namespace Interfaces_ECG
{
    public class ECGContainer
    {
        public ECGContainer(IProcessing processing)
        {
            _processing = processing;
        }

        private List<int> _samples = new List<int>();
        private IProcessing _processing;

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

        public IProcessing Processing
        {
            set => _processing = value;
        }
    }
}
