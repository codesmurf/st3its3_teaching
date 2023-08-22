using System;
using System.Threading;
using System.Windows.Forms;
using CardCounterLib;

namespace WindowsFormsCardCounter
{
    public partial class Cardcounter : Form
    {
        private CardData cardData;
        private CardCounterForThread counter1;
        DisplayUpdater displayUpdater;

        public Cardcounter()
        {
            InitializeComponent();

            cardData = new CardData();
            counter1 = new CardCounterForThread("../../../Cards/cards.txt", cardData);
            textBoxCardFile.Text = "../../../Cards/cards.txt";
        }


        public void SetCardCounter(int count)
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action) delegate { textBoxNumberOfCards.Text = "" + count; });
            }
            else
            {
                {
                    textBoxNumberOfCards.Text = "" + count;
                }
            }
        }

        public void SetSpadesSum(int sum)
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action) delegate { textBoxSumOfSpades.Text = "" + sum; });
            }
            else
            {
                {
                    textBoxSumOfSpades.Text = "" + sum;
                }
            }
        }

        public void SetAcesCount(int cnt)
        {
            if (InvokeRequired)
            {
                BeginInvoke((Action) delegate { textBoxNumberOfAces.Text = "" + cnt; });
            }
            else
            {
                textBoxNumberOfAces.Text = "" + cnt;
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            displayUpdater = new DisplayUpdater(cardData, this);
            Thread displayUpdateThread = new Thread(displayUpdater.Run);
            displayUpdateThread.Start();
            displayUpdateThread.IsBackground = true;

            Thread counterThread = new Thread(counter1.CountTheCards);
            counterThread.Start();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            displayUpdater.Stop = true;
        }

    }

    public class DisplayUpdater
    {
        private CardData _cardData;
        private Cardcounter _cardCounterForm;
        public bool Stop = false;

        public DisplayUpdater(CardData cardData, Cardcounter cardCounterForm)
        {
            _cardData = cardData;
            _cardCounterForm = cardCounterForm;
        }

        public void Run()
        {
            while (!Stop)
            {
                UpdateCardDataOnDisplay();
                Thread.Sleep(1);
            }
        }

        private void UpdateCardDataOnDisplay()
        {
            _cardCounterForm.SetCardCounter(_cardData.NumberOfCards);
            _cardCounterForm.SetAcesCount(_cardData.NumberOfAces);
            _cardCounterForm.SetSpadesSum(_cardData.NumberOfSpades);
        }

    }
}
