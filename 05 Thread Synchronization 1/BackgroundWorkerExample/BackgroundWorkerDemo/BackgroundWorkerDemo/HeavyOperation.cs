using System.ComponentModel;
using System.Threading;

namespace BackgroundWorkerDemo
{
    class HeavyOperation
    {
        // Object used to pass state to the GUI
        public class HeavyOperationUserState
        {
            public int IterationNo { get; set; }
        }

        private readonly int _anArgument;

        public HeavyOperation(int anArgument)
        {
            _anArgument = anArgument;
        }

        public int PerformHeavyOperation(BackgroundWorker worker, DoWorkEventArgs e)
        {
            int maxValue = _anArgument;
            int totalSum = 0;

            for (int i = 0; i < maxValue; i++)
            {
                if (!worker.CancellationPending)
                {
                    totalSum = totalSum + i;
                    Thread.Sleep(250);

                    HeavyOperationUserState userState = new HeavyOperationUserState();
                    userState.IterationNo = i;

                    int percentComplete = ((i + 1) * 100) / maxValue;
                    worker.ReportProgress(percentComplete, userState);
                }
                else
                {
                    e.Cancel = true;
                    break;
                }
            }

            return totalSum;
        }
    }
}
