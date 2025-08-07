using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClientServer;
internal class SocketServer 
{
    private bool _hasUnreadData = false;
    private string _data = "";
    public bool HasUnreadData { get => _hasUnreadData; private set => _hasUnreadData = value; }

    public string Data
    {
        get
        {
            HasUnreadData = false;
            return _data;
        }
        private set
        {
            _data = value;
            HasUnreadData = true;
        }
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

        while (true)
        {
            try
            {
                byte[] buffer = new byte[1024];
                int numberOfBytesReceived = handler.Receive(buffer, SocketFlags.None);
                string receivedData = Encoding.UTF8.GetString(buffer, 0, numberOfBytesReceived);
                Console.WriteLine($"Server received: {receivedData}");
                Data = receivedData;
            }
            catch (SocketException e)
            {
                Console.WriteLine("Got exception: " + e.ToString());
                break;
            }
        }
    }
}