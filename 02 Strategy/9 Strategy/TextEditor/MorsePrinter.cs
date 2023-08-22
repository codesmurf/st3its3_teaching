using System;

namespace TextEditor
{
    // MorsePrinter: A concrete strategy (i.e. a concrete printer)
    // OCP makes it very easy to extend the set of printers with
    // zero changes to the client (the TextEditor)
    class MorsePrinter : IPrinter
    {
        public void PrintText(string currentText)
        {
            Console.WriteLine("MoresPrinter: {0}", currentText);
        }
    }
}