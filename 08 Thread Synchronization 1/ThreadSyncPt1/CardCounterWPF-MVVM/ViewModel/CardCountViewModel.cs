using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Input;
using CardCounterWPF_MVVM.Annotations;
using CardCounterWPF_MVVM.CardCounter;
using CardCounterWPF_MVVM.Model;

namespace CardCounterWPF_MVVM.ViewModel
{
    public class CardCountViewModel : INotifyPropertyChanged, ICardCountObserver
    {
        private string _file = @"..\..\..\Cardfiles\cards.txt";
        private int _numberOfCards = 100;
        private int _sumOfSpades = 200;
        private int _numberOfAces = 300;
        private readonly CardData _cardCountModel = new CardData(); // could be dependency injected in the constructor

        public CardCountViewModel()
        {
            _cardCountModel.Add(this); // attach as observer to the model
        }

        public string File
        {
            get => _file;
            set
            {
                _file = value; 
                OnPropertyChanged();
            }
        }

        public int NumberOfCards
        {
            get => _numberOfCards;
            set
            {
                _numberOfCards = value; 
                OnPropertyChanged();
            }
        }

        public int SumOfSpades
        {
            get => _sumOfSpades;
            set
            {
                _sumOfSpades = value; 
                OnPropertyChanged();
            }
        }

        public int NumberOfAces
        {
            get => _numberOfAces;
            set
            {
                _numberOfAces = value; 
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void StartButtonClicked()
        {
            Console.WriteLine("Start clicked");
            CardCounterForThread cardCounterForThread = new CardCounterForThread(_file, _cardCountModel);
            Thread counterThread = new Thread(cardCounterForThread.CountTheCards);
            counterThread.Start();
        }

        private ICommand _startButtonClickedCommand;

        public ICommand StartButtonClickCommand => _startButtonClickedCommand ?? (_startButtonClickedCommand =
                                                     new RelayCommand(StartButtonClicked,
                                                         StartButtonClickedCanExecute));

        private bool StartButtonClickedCanExecute()
        {
            return true;
        }

        public void CancelButtonClicked()
        {
            Console.WriteLine("Cancel clicked");
        }

        private ICommand _cancelButtonClickedCommand;

        public ICommand CancelButtonClickCommand => _cancelButtonClickedCommand ?? (_cancelButtonClickedCommand =
                                                        new RelayCommand(CancelButtonClicked,
                                                            CancelButtonClickedCanExecute));

        private bool CancelButtonClickedCanExecute()
        {
            return true;
        }

        public void Update(CardCountSubject.UpdatedField field)
        {
            switch (field)
            {
                case CardCountSubject.UpdatedField.AcesCount:
                {
                    NumberOfAces = _cardCountModel.NumberOfAces;
                }
                break;
                case CardCountSubject.UpdatedField.SpadesSum:
                {
                    SumOfSpades = _cardCountModel.SumOfSpades;
                }
                break;
                case CardCountSubject.UpdatedField.CardsCount:
                {
                    NumberOfCards = _cardCountModel.NumberOfCards;
                }
                break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(field), field, null);
            }
        }
    }
}
