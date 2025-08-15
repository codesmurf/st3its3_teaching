namespace ClientServer;

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

        socketClient.SendData("Data package 1");
        Thread.Sleep(1000);
        socketClient.SendData("Data package 2");
        Thread.Sleep(1000);

        socketClient.ShallRun = false;
    }
}
