using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor
{
    // YeOlePrinter: A concrete strategy (i.e. a concrete printer)
    class YeOlePrinter : IPrinter
    {
        public void PrintText(string text)
        {
            Console.WriteLine("YeOldPrinter: {0}", text);
        }
    }
}
