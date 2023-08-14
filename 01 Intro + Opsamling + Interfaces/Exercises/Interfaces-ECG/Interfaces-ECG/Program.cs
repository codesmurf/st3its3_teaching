using System;

namespace Interfaces_ECG
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose: a) print, b) extremes");
            IProcessing processing = new ProcessingPrint();

            ConsoleKeyInfo info = Console.ReadKey();
            char key = info.KeyChar;

            if (key == 'a')
            {
                processing = new ProcessingPrint();
            }
            else if (key == 'b')
            {
                processing = new ProcessingExtremes();
            }

            ECGContainer container = new ECGContainer(processing);

            for (int i = 0; i < 10; i++) // Add samples
            {
                for (int j = 0; j < 200; j++)
                {
                    container.AddSample(0); // flatline
                }

                for (int j = 0; j < 100; j++)
                {
                    container.AddSample(j); // rising peak
                }

                for (int j = 100; j > 0; j--)
                {
                    container.AddSample(j); // falling peak
                }
            }

            Console.WriteLine("Press 1 for print, press 2 for extremes, press 3 for BPM");
            ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
            char keyChar = consoleKeyInfo.KeyChar;

            bool waitingForChoice = true;
            while (waitingForChoice)
            {
                if (keyChar == '1')
                {
                    container.Processing = new ProcessingPrint();
                    waitingForChoice = false;

                }
                else if (keyChar == '2')
                {
                    container.Processing = new ProcessingExtremes();
                    waitingForChoice = false;
                }
                else if (keyChar == '3')
                {
                    container.Processing = new ProcessingBPM();
                    waitingForChoice = false;
                }
                else
                {
                    Console.WriteLine("Choose 1 or 2");
                    consoleKeyInfo = Console.ReadKey();
                    keyChar = consoleKeyInfo.KeyChar;
                }
            }

            container.ProcessSamples();

            // Wait for keypress before exiting (otherwise the program exits a debug session)
            Console.WriteLine("Press a key to exit.");
            Console.ReadKey();
        }
    }
}
