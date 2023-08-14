using System;
using System.Collections.Generic;

namespace PrinterOCPExample
{
    internal class OldPrinter : IPrinter  
    {
        private void Print(char c)
        {
            Console.WriteLine(c);
        }

        public void Print(List<string> text)
        {
            foreach (string s in text)
            {
                foreach (char c in s)
                {
                    Print(c);
                }
            }
        }
    }
}