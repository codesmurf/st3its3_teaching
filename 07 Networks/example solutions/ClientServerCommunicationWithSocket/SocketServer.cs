using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ClientServerCommunicationWithSocket;

internal class SocketServer 
{
    public void Run()
    {
        RunServer();
        //RunServerAsync().Wait();
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
                Console.WriteLine($"Server received:{receivedData}");

                string reply = "ACK";
                byte[] replyBytes = Encoding.UTF8.GetBytes(reply);
                handler.Send(replyBytes, SocketFlags.None);
            }
            catch (SocketException e)
            {
                Console.WriteLine("Got exception: " + e.ToString());
                break;
            }
        }
    }

    public async Task RunServerAsync()
    {
        // listen to 'Any' which means all network addresses for this machine
        IPAddress ipAddress = IPAddress.Any;
        IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 2000);

        using Socket listener = new Socket(ipEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

        listener.Bind(ipEndPoint);

        Console.WriteLine($"Listening on: {ipAddress}");
        listener.Listen();

        var handler = await listener.AcceptAsync();

        while (true)
        {
            byte[] buffer = new byte[1024];
            int numberOfBytesReceived = await handler.ReceiveAsync(buffer, SocketFlags.None);
            string receivedData = Encoding.UTF8.GetString(buffer, 0, numberOfBytesReceived);
            Console.WriteLine($"Server received:{receivedData}");

            string reply = "ACK";
            byte[] replyBytes = Encoding.UTF8.GetBytes(reply);
            await handler.SendAsync(replyBytes, SocketFlags.None);
        }
    }

}