using System;
using System.Collections.Generic;
using System.Text;

namespace PrinterExample
{
    internal class TextEditor
    {
        private string text;
        private IPrinting printer;

        public TextEditor(IPrinting printer)
        {
            this.printer = printer;
        }

        public void SetPrinter(IPrinting printer)
        {
            this.printer = printer;
        }

        public void SetText(string text)
        {
            this.text = text;
        }

        public void OnButtonPrint()
        {
            printer.Print(text);
        }
    }
}
