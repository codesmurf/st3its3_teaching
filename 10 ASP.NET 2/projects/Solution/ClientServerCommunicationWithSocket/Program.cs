namespace ClientServerCommunicationWithSocket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            SocketServer socketServer = new SocketServer();
            SocketClient socketClient = new SocketClient();

            Thread t1 = new Thread(socketServer.RunServer);
            Thread t2 = new Thread(socketClient.RunClient);

            t1.Start();
            t2.Start();

        }
    }
}