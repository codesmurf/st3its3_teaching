using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace ECGServer;

internal class SocketServer 
{
    private readonly BlockingCollection<ECGReading> _ecgReadings;

    public SocketServer(BlockingCollection<ECGReading> ecgReadings)
    {
        _ecgReadings = ecgReadings;
    }
    public void Run()
    {
        RunServer();
    }

    public void RunServer()
    {
        // listen to 'Any' which means all network addresses for this machine
        IPAddress ipAddress = IPAddress.Any;
        IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 2000);

        using Socket listener = new Socket(ipEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

        listener.Bind(ipEndPoint);

        Console.WriteLine($"Listening on: {ipAddress}");
        listener.Listen();

        var handler = listener.Accept();

        while (!ShallStop)
        {
            byte[] buffer = new byte[1024];
            int numberOfBytesReceived = handler.Receive(buffer, SocketFlags.None);
            if (numberOfBytesReceived > 0)
            {
                string receivedData = Encoding.UTF8.GetString(buffer, 0, numberOfBytesReceived);
                Console.WriteLine($"Server received:{receivedData}");

                try
                {
                    ECGReading? ecgReading = JsonSerializer.Deserialize<ECGReading>(receivedData);
                    if (ecgReading != null) _ecgReadings.Add(ecgReading);
                }
                catch (System.Text.Json.JsonException e)
                {
                    // log any parsing exceptions
                    Console.WriteLine(e);
                }
            }
        }
        listener.Close();
        _ecgReadings.CompleteAdding();
    }

    public bool ShallStop { get; set; } = false;
}