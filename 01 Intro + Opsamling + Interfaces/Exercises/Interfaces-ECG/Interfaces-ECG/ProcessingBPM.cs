using System;
using System.Collections.Generic;

namespace Interfaces_ECG
{
    public class ProcessingBPM : IProcessing
    {
        int samplesPerSecond = 1000;

        public void Process(List<int> samples)
        {
            bool inPeak = false;
            int peaks = 0;

            foreach (int sample in samples)
            {
                if (sample >= 20
                    && !inPeak)
                {
                    peaks++;
                    inPeak = true;
                }
                else if (sample < 20)
                {
                    inPeak = false;
                }
            }

            float samplesCount = samples.Count;
            float seconds = samplesCount / samplesPerSecond;

            float beatsPerSecond = peaks / seconds;
            float beatsPerMinute = beatsPerSecond * 60;

            Console.WriteLine("Beats per minute: {0}", beatsPerMinute);
        }
    }
}