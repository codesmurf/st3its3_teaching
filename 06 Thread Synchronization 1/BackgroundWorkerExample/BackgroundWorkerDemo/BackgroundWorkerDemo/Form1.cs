using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace BackgroundWorkerDemo
{
    public partial class Form1 : Form
    {
        private BackgroundWorker myWorker = new BackgroundWorker();

        public Form1()
        {
            InitializeComponent();

            myWorker.DoWork += new DoWorkEventHandler(myWorker_DoWork);
            myWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(myWorker_RunWorkerCompleted);
            myWorker.ProgressChanged += new ProgressChangedEventHandler(myWorker_ProgressChanged);

            myWorker.WorkerReportsProgress = true;
            myWorker.WorkerSupportsCancellation = true;
        }

        private void myWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // This method runs on the main thread

            int progressPercentage = e.ProgressPercentage;
            HeavyOperation.HeavyOperationUserState hoUserState = (HeavyOperation.HeavyOperationUserState) e.UserState;
            int iterationNo = hoUserState.IterationNo;
            lblStatus.Text = "Iteration number: " + iterationNo;
            progress.Value = progressPercentage;
        }

        private void myWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                lblStatus.Text = "Error: " + e.Error.Message;
            }
            else if (e.Cancelled)
            {
                lblStatus.Text = "User cancelled";
            }
            else
            {
                lblStatus.Text = "Done";
                textBox1.Text = textBox1.Text + "Total count: " + (int)(e.Result) + Environment.NewLine;
            }

            btnStart.Enabled = true;

        }

        private void myWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // This event handler is where the actual work is done.  
            // This method runs on the background thread.  

            // Get the BackgroundWorker object that raised this event.  
            BackgroundWorker worker = (BackgroundWorker)sender;

            // Get the HeavyOperation object and perform the 
            // heavy operation on the background thread.
            HeavyOperation ho = (HeavyOperation) e.Argument;
            int result = ho.PerformHeavyOperation(worker, e);
            e.Result = result;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            // This method runs on the main thread.  
            if (!myWorker.IsBusy) 
            {
                // ... do stuff with the GUI if you need to
                btnStart.Enabled = false;

                //Capture the user input and initialize the HeavyOperation
                int numericValue = (int)numericUpDownMax.Value;

                HeavyOperation ho = new HeavyOperation(numericValue);

                // Start the asynchronous operation.  
                myWorker.RunWorkerAsync(ho);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Cancel the asynchronous operation.  
            myWorker.CancelAsync();
        }
    }
}
