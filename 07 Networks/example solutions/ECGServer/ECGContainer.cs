namespace ECGServer;

internal class ECGContainer
{
    private List<int> _samples = new List<int>();

    public void AddSample(int sample)
    {
        _samples.Add(sample);
    }

    public int Count()
    {
        return _samples.Count;
    }

    public void ProcessSamples()
    {
        for (int i = 0; i < Count(); i++)
        {
            Console.WriteLine("Sample no: {0}, value: {1}", i, _samples[i]);
        }
    }

}