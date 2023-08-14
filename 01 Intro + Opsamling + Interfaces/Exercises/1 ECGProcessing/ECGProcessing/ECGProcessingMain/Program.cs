using System;

namespace Interfaces_ECG
{
    class Program
    {
        static void Main(string[] args)
        {
            ECGContainer container = null;
            Console.WriteLine("Choose processing tool: a) print, b) extremes, c) bpm");
            var consoleKeyInfo = Console.ReadKey();
            switch (consoleKeyInfo.KeyChar)
            {
                case 'a':
                case 'A':
                    container = new ECGContainer(new Processing());
                    break;
                case 'b':
                case 'B':
                    container = new ECGContainer(new ExtremesProcessing());
                    break;
                case 'c':
                case 'C':
                    container = new ECGContainer(new BPMProcessing());
                    break;
                default:
                    Console.WriteLine("No valid processor selected, exiting...");
                    Environment.Exit(0);
                    break;
            }

            Random r = new Random();
            for (int i = 0; i < 100; i++) // Add samples
            {
                container.AddSample(r.Next(22));
            }
            container.ProcessSamples();

            // Wait for keypress before exiting (otherwise the program exits a debug session)
            Console.WriteLine("Press a key to exit.");
            Console.ReadKey();
        }
    }
}
