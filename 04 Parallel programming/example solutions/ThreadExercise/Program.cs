namespace ThreadExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HelloWriter helloWriter = new HelloWriter("Michael");
            HelloWriter helloWriter1 = new HelloWriter("Henrik");

            NeverEndingStory neverEndingStory = new NeverEndingStory();

            Console.WriteLine("Hello, World!");

            Thread threadMichael = new Thread(() => helloWriter.SayHello(20));
            Thread threadHenrik = new Thread(() => helloWriter1.SayHello(25));
            helloWriter.SleepTime = 200;
            helloWriter1.SleepTime = 500;

            Thread neverEndingThread = new Thread(neverEndingStory.Run);

            //helloWriter.NumberOfTimes = 20;
            //helloWriter1.NumberOfTimes = 25;

            threadMichael.Start();
            threadHenrik.Start();
            neverEndingThread.Start();

            //neverEndingThread.IsBackground = true;

            threadMichael.Join();
            threadHenrik.Join();

            neverEndingStory.ShallRun = false;

            Console.WriteLine("hello from main");
        }
    }
}
