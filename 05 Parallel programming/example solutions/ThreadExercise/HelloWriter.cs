using System.Net.Http.Headers;

namespace ThreadExercise
{
    internal class HelloWriter
    {
        public HelloWriter(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public int SleepTime { get; set; } = 1;

        public void SayHello(int times)
        {
            for (int i = 0; i < times; i++)
            {
                Console.WriteLine("Hello from {0} # {1}", Name, i);
                Thread.Sleep(SleepTime);
            }
        }
    }
}