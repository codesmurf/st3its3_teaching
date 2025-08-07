using System.Collections.Concurrent;

namespace ECGClient;

internal class ECGReadingProducer
{
    private readonly BlockingCollection<ECGReading> _ecgReadings;
    private readonly IECGSensor _sensor;
    public bool ShallStop { get; set; } = false;

    public ECGReadingProducer(BlockingCollection<ECGReading> ecgReadings, IECGSensor sensor)
    {
        _ecgReadings = ecgReadings;
        _sensor = sensor;
    }

    public void Run()
    {
        while(!ShallStop)
        {
            int sample = _sensor.GenerateSample();
            ECGReading ecgReading = new ECGReading();
            ecgReading.Reading = sample;
            _ecgReadings.Add(ecgReading);
            Thread.Sleep(1000);
        }
        _ecgReadings.CompleteAdding();
    }

}