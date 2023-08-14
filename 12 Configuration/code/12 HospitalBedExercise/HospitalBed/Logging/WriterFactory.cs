using System;

namespace HospitalBed.Logging
{
    public class WriterFactory
    {
        public static IWriter CreateWriter(string descriptor)
        {
            switch (descriptor.ToLower())
            {
                case "console":
                    return new ConsoleWriter();
                case "file":
                    return
                        new FileWriter(@"..\..\log.txt"); // Note: filename should also be part of the configuration
            }
            throw new ArgumentException("Unknown log method: {0}", descriptor);
        }
    }
}