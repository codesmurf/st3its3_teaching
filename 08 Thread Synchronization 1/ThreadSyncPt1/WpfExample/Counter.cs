using System.Threading;

namespace WpfExample
{
    public class Counter
    {
        readonly MainWindow _mainWindow;

        public Counter(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
        }

        public void Run()
        {
            for (int i = 0; i < 1000; i++)
            {
                _mainWindow.UpdateCounter(i);
                Thread.Sleep(100);
            }
        }
    }
}
