using System.Net.Sockets;
using System.Net;
using System.Text;

namespace ClientServerCommunicationWithSocket;

internal class SocketClient
{

    public void Run()
    {
        RunClient();
        //RunClientAsync().Wait();
    }

    public void RunClient()
    {
        IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
        IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 2000);

        using Socket client = new Socket(ipEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        client.Connect(ipEndPoint);

        for (int i = 0; i < 10; i++)
        {
            // Send message.
            var message = "Hello " + i;
            var messageBytes = Encoding.UTF8.GetBytes(message);
            client.Send(messageBytes, SocketFlags.None);
            Console.WriteLine($"Socket client sent message: {message}");

            // Receive ack.
            var buffer = new byte[1024];
            var received = client.Receive(buffer, SocketFlags.None);
            var response = Encoding.UTF8.GetString(buffer, 0, received);

            Console.WriteLine($"Client received: {response}");
            Thread.Sleep(1000);
        }

        client.Shutdown(SocketShutdown.Both);
    }

    public async Task RunClientAsync()
    {
        IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
        IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 2000);

        using Socket client = new Socket(ipEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        await client.ConnectAsync(ipEndPoint);

        // Send message.
        var message = "Hello";
        var messageBytes = Encoding.UTF8.GetBytes(message);
        await client.SendAsync(messageBytes, SocketFlags.None);
        Console.WriteLine($"Socket client sent message: {message}");

        // Receive ack.
        var buffer = new byte[1024];
        var received = await client.ReceiveAsync(buffer, SocketFlags.None);
        var response = Encoding.UTF8.GetString(buffer, 0, received);

        Console.WriteLine($"Client received: {response}");

        client.Shutdown(SocketShutdown.Both);
    }
}