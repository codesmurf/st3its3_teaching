using System.Collections.Concurrent;
using ECGServer.Data;

namespace ECGServer;

internal class ECGReadingConsumer
{
    private readonly BlockingCollection<ECGReading> _ecgReadings;
    private readonly ECGContainer _ecgContainer;
    private readonly EcgServerHandler _ecgServerHandler;

    public ECGReadingConsumer(BlockingCollection<ECGReading> ecgReadings, ECGContainer ecgContainer,
        EcgServerHandler ecgServerHandler)
    {
        _ecgReadings = ecgReadings;
        _ecgContainer = ecgContainer;
        _ecgServerHandler = ecgServerHandler;
    }

    public void Run()
    {
        while (!_ecgReadings.IsCompleted)
        {
            try
            {
                ECGReading ecgReading = _ecgReadings.Take();
                int value = ecgReading.Reading;
                Console.WriteLine("Got: {0}", value);
                _ecgContainer.AddSample(value);

                int count = 10;
                if (_ecgContainer.Count() % count == 0)
                {
                    var dataSnapshot = _ecgContainer.CreateDataSnapshot(count);
                    var httpStatusCode = _ecgServerHandler.AddSummary(dataSnapshot).Result;
                    
                }

            }
            catch (InvalidOperationException)
            {
                // IOE means that Take() was called on a completed collection.
            }
        }
        Console.WriteLine("No more data expected");
    }
}