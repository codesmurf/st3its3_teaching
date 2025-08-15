using System.Net.Sockets;
using System.Net;
using System.Text;

namespace ClientServer;
internal class SocketClient
{
    private string _message = "";
    private bool _hasDataToSend = false;
    private bool _shallRun = true;

    public bool ShallRun { private get => _shallRun; set => _shallRun = value; }

    public void SendData(string message)
    {
        _message = message;
        _hasDataToSend = true;
    }

    public void RunClient()
    {
        IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
        IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 2000);

        using Socket client = new Socket(ipEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        client.Connect(ipEndPoint);

        while (ShallRun)
        {
            // Send message.
            if (_hasDataToSend)
            {
                var message = _message;
                var messageBytes = Encoding.UTF8.GetBytes(message);
                client.Send(messageBytes, SocketFlags.None);
                Console.WriteLine($"Socket client sent message: {message}");
                _hasDataToSend = false;
            }
            Thread.Sleep(0);
        }

        client.Shutdown(SocketShutdown.Both);
    }
}