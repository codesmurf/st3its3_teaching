using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor
{
    // TheNewPrinter: A concrete strategy (i.e. a concrete printer)
    class TheNewPrinter : IPrinter
    {
        public void PrintText(string currentText)
        {
            Console.WriteLine("TheNewPrinter: {0}", currentText);
        }
    }
}

