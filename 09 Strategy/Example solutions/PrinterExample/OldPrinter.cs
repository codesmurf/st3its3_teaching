using System;
using System.Collections.Generic;
using System.Text;

namespace PrinterExample
{
    internal class OldPrinter : IPrinting
    {
        public void Print(string text)
        {
            Console.WriteLine("Oldprinter: {0}", text);
        }
    }
}
