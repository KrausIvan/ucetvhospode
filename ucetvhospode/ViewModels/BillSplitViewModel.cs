using System.ComponentModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using ucetvhospode.Models;

namespace ucetvhospode.ViewModels
{
    public class BillSplitViewModel : INotifyPropertyChanged
    {
        private BillSplitModel model;

        public event PropertyChangedEventHandler PropertyChanged;

        public BillSplitViewModel()
        {
            model = new BillSplitModel();
        }

        public decimal BillAmount
        {
            get => model.BillAmount;
            set
            {
                if (model.BillAmount != value)
                {
                    model.BillAmount = value;
                    OnPropertyChanged(nameof(BillAmount));
                    OnPropertyChanged(nameof(TotalAmount));
                    OnPropertyChanged(nameof(Share));
                    OnPropertyChanged(nameof(ShareWithTip));
                }
            }
        }

        public decimal TipPercentage
        {
            get => model.TipPercentage;
            set
            {
                if (model.TipPercentage != value)
                {
                    model.TipPercentage = value;
                    OnPropertyChanged(nameof(TipPercentage));
                    OnPropertyChanged(nameof(TotalAmount));
                    OnPropertyChanged(nameof(ShareWithTip));
                }
            }
        }

        public int NumberOfGuests
        {
            get => model.NumberOfGuests;
            set
            {
                if (model.NumberOfGuests != value)
                {
                    model.NumberOfGuests = value;
                    OnPropertyChanged(nameof(NumberOfGuests));
                    OnPropertyChanged(nameof(Share));
                    OnPropertyChanged(nameof(ShareWithTip));
                }
            }
        }

        public decimal TotalAmount => model.TotalAmount;

        public decimal Share => model.Share;

        public decimal ShareWithTip => model.ShareWithTip;

        public ICommand IncreaseGuestsCommand => new Command(IncreaseGuests);
        public ICommand DecreaseGuestsCommand => new Command(DecreaseGuests, () => NumberOfGuests > 1);

        private void IncreaseGuests()
        {
            NumberOfGuests++;
            OnPropertyChanged(nameof(NumberOfGuests));
            OnPropertyChanged(nameof(Share));
            OnPropertyChanged(nameof(ShareWithTip));
        }

        private void DecreaseGuests()
        {
            if (NumberOfGuests > 1)
            {
                NumberOfGuests--;
                OnPropertyChanged(nameof(NumberOfGuests));
                OnPropertyChanged(nameof(Share));
                OnPropertyChanged(nameof(ShareWithTip));
                (DecreaseGuestsCommand as Command)?.ChangeCanExecute();

            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
