using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 mainForm = new Form1();

            CounterThread counter = new CounterThread(mainForm);
            Thread counterThread = new Thread(counter.Run);
            counterThread.IsBackground = true;

            counterThread.Start();

            Application.Run(mainForm);
        }
    }
}
