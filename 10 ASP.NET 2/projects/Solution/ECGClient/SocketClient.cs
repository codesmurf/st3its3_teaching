using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace ECGClient;

internal class SocketClient
{
    private readonly BlockingCollection<ECGReading> _ecgReadings;

    public SocketClient(BlockingCollection<ECGReading> ecgReadings)
    {
        _ecgReadings = ecgReadings;
    }

    public void Run()
    {
        IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
        IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 2000);

        using Socket client = new Socket(ipEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        client.Connect(ipEndPoint);

        while (!_ecgReadings.IsCompleted)
        {
            try
            {
                ECGReading ecgReading = _ecgReadings.Take();

                string objectAsJson = JsonSerializer.Serialize(ecgReading);
                var messageBytes = Encoding.UTF8.GetBytes(objectAsJson);
                client.Send(messageBytes, SocketFlags.None);
                Console.WriteLine($"Socket client sent message: {objectAsJson}");
            }
            catch (InvalidOperationException)
            {
                // IOE means that Take() was called on a completed collection.
            }
        }
        Console.WriteLine("No more data expected");

        client.Shutdown(SocketShutdown.Both);
    }
}