using System;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace WpfExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void UpdateCounter(int count)
        {
            if (Dispatcher.CheckAccess())
            {
                LabelCounter.Text = "" + count;
            }
            else
            {
                Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(
                    () =>
                    {
                        LabelCounter.Text = "" + count;
                    })
                );
            }
        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            Counter counter = new Counter(this);

            Thread theThread = new Thread(counter.Run);
            theThread.IsBackground = true;
            
            theThread.Start();
        }
    }
}
