using System;
using System.Collections.Generic;

namespace Interfaces_ECG
{
    public class BPMProcessing : IProcessing
    {
        private readonly int THRESHOLD = 20;
        private readonly int SAMPLES_PER_SECOND = 1000;
        public void Process(List<int> samples)
        {
            bool inPeak = false;
            int beats = 0;

            foreach (var sample in samples)
            {
                if (sample > THRESHOLD && !inPeak)
                {
                    inPeak = true;
                    beats += 1;
                }

                if (sample <= THRESHOLD)
                {
                    inPeak = false;
                }
            }
            
            float samplesCount = samples.Count;
            float seconds = samplesCount / SAMPLES_PER_SECOND;
            float beatsPerSecond = beats / seconds;
            float beatsPerMinute = beatsPerSecond * 60;

            Console.WriteLine("Beats per mimute: {0}", beatsPerMinute);
        }
    }
}