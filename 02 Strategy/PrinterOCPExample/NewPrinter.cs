using System;
using System.Collections.Generic;

namespace PrinterOCPExample
{
    public class NewPrinter : IPrinter
    {
        public void Print(List<string> text)
        {
            foreach (string s in text)
            {
                Console.WriteLine(s);
            }
        }
    }
}
