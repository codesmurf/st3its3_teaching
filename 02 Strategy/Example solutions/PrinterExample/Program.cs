using System;
using System.Net.Mime;

namespace PrinterExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OldPrinter printer = new OldPrinter();
            TextEditor editor = new TextEditor(printer);
            editor.SetPrinter(printer);

            editor.SetText("Hej med dig");
            editor.OnButtonPrint();

            NewPrinter printer2 = new NewPrinter();
            editor.SetPrinter(printer2);
            editor.OnButtonPrint();
        }
    }
}
