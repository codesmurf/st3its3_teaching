using System;
using System.Collections.Generic;

namespace PrinterOCPExample
{
    internal class TextEditor
    {
        private List<string> text = new List<String>();

        public IPrinter MyPrinter { private get; set; }

        public void SetPrinter(IPrinter printer) // property injection
        {
            MyPrinter = printer;
        }

        public TextEditor(IPrinter printer) // constructor injection
        {
            MyPrinter = printer;
        }

        public void AddLine(string line)
        {
            text.Add(line);
        }

        public void OnButtonPrint()
        {
            MyPrinter.Print(text);
        }
    }
}