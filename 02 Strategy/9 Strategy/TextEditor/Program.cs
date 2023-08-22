using System;

namespace TextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            IPrinter printer = new YeOlePrinter();
            TextEditor editor = new TextEditor(printer);    // Constructor injection

            editor.CurrentText = "Hej mor!";
            editor.OnButtonPrint();

            IPrinter newPrinter = new TheNewPrinter();  
            editor.SetPrinter(newPrinter);          // GoF Strategy: Set new "printing strategy"

            editor.OnButtonPrint();

            IPrinter morsePrinter = new MorsePrinter();
            editor.SetPrinter(morsePrinter);
            editor.OnButtonPrint();

            Console.ReadKey();

        }
    }
}
