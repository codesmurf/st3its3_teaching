namespace ECGClient;

internal class ECGSensor : IECGSensor
{
    readonly Random _random = new Random();
    public int GenerateSample()
    {
        int sample = _random.Next(0, 50);
        return sample;
    }
}