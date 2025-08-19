using System.Collections.Concurrent;

namespace HospitalBed
{
    internal class PresenseDataProvider
    {
        private readonly IPresenseSensor presenseSensor;
        private readonly BlockingCollection<PresenseData> presenseDataQueue;
        private bool shallStop = false;

        public PresenseDataProvider(IPresenseSensor presenseSensor, BlockingCollection<PresenseData> presenseDataQueue)
        {
            this.presenseSensor = presenseSensor;
            this.presenseDataQueue = presenseDataQueue;
        }

        public void StopThread()
        {
            shallStop = true;
        }

        public void Run()
        {

            while (!shallStop)
            {
                bool isPresent = presenseSensor.IsPresent();
                PresenseData data = new PresenseData();
                data.SetPresense(isPresent);
                presenseDataQueue.Add(data);
                Thread.Sleep(500);
            }

            presenseDataQueue.CompleteAdding();
        }
    }
}