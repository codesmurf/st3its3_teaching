using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void SetCounter(int count)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((Action) delegate 
                {
                    textBoxCount.Text = "" + count;
                });
            }
            else
            {
                textBoxCount.Text = "" + count;
            }
        }
    }
}
