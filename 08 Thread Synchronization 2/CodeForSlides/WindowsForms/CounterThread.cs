using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public class CounterThread
    {
        private readonly Form1 _form;

        public CounterThread(Form1 form)
        {
            _form = form;
        }

        public void Run()
        {
            for (int i = 0; i < 1000; i++)
            {
                _form.SetCounter(i);
                Thread.Sleep(100);
            }
        }
    }
}
