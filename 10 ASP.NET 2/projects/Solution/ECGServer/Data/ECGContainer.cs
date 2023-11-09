namespace ECGServer.Data;

public class ECGContainer
{
    private readonly List<int> _samples;
    private readonly string _cpr;

    public ECGContainer(string cpr)
    {
        _cpr = cpr;
        _samples = new List<int>();
    }

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

    public SnapShot CreateDataSnapshot(int size)
    {
        var samples = _samples.GetRange(_samples.Count - size, size);
        return new SnapShot()
        {
            Max = samples.Max(),
            Min = samples.Min(),
            Average = (int) samples.Average(),
            Cpr = _cpr
                
        };
    }
}