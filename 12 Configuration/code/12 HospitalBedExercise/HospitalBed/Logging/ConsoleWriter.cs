using System;

namespace HospitalBed.Logging
{
    internal class ConsoleWriter : IWriter
    {
        public void Write(string s)
        {
            Console.WriteLine(s);
        }
    }
}