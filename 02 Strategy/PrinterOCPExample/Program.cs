using System;

namespace PrinterOCPExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //OldPrinter oldPrinter = new OldPrinter();
            //TextEditor editor = new TextEditor(oldPrinter);

            NewPrinter newPrinter = new NewPrinter();
            TextEditor editor = new TextEditor(newPrinter);

            editor.AddLine("hej mor");
            editor.AddLine("hej far");

            editor.OnButtonPrint();
        }
    }
}
