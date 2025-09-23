using System.Collections.Concurrent;
using System.Reflection;

namespace HospitalBed
{
    internal class PatientMonitor
    {
        private BlockingCollection<PresenseData> presenseDataQueue;
        private Buzzer buzzer = new Buzzer();
        private IPresenseFilter presenseFilter;

        public PatientMonitor(BlockingCollection<PresenseData> presenseDataQueue, IPresenseFilter presenseFilter)
        {
            this.presenseDataQueue = presenseDataQueue;
            this.presenseFilter = presenseFilter;
        }

        public void Run()
        {
            while (!presenseDataQueue.IsAddingCompleted)
            {
                try
                {
                    PresenseData data = presenseDataQueue.Take();
                    // Use the filter to determine if the patient is present
                    bool presence = data.GetPresense();
                    // Log the presence status
                    Console.WriteLine($"Patient presence status: {presence}");
                        
                    if (presenseFilter.AddPresenseSample(presence))
                    {
                        buzzer.StopBuzzing();
                    }
                    else
                    {
                        buzzer.StartBuzzing();
                    }
                }
                catch (InvalidOperationException)
                {
                    // The collection has been marked as complete and no more items can be taken.
                    Console.WriteLine("Got InvalidOperationException. Collection marked as complete when trying to take data.");
                    break;
                }
            }
        }
    }
}