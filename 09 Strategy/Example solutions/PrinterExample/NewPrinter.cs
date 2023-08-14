using System;
using System.Collections.Generic;
using System.Text;

namespace PrinterExample
{
    internal class NewPrinter : IPrinting
    {
        public void Print(string text)
        {
            Console.WriteLine("NewPrinter: {0}", text);
        }
    }
}
