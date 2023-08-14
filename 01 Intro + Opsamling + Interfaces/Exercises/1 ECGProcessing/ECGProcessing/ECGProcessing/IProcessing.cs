using System.Collections.Generic;

namespace Interfaces_ECG
{
    public interface IProcessing
    {
        void Process(List<int> samples);
    }
}