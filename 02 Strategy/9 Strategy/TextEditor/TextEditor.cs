using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEditor
{
    // TextEditor: The "Context" of the GoF Strategy pattern
    class TextEditor
    {
        private IPrinter _printer; // The "strategy"

        public string CurrentText { set; private get; }

        public TextEditor(IPrinter p)
        {
            _printer = p;
        }

        public void OnButtonPrint()
        {
            _printer.PrintText(CurrentText);
        }

        // GoF Strategy: Allow run-time changes to the strategy (i.e. the printer)
        public void SetPrinter(IPrinter p)
        {
            _printer = p;
        }
    }
}
