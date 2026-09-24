namespace ThreadExercise
{
    internal class NeverEndingStory
    {
        public NeverEndingStory()
        {
        }

        public bool ShallRun { get; set; } = true;

        public void Run()
        {
            while(ShallRun)
            {
                Console.WriteLine("Never ending story");
                Thread.Sleep(5000);
            }
        }
    }
}