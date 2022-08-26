using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands;
using DEDSEC.WPF.Services;
using DEDSEC.WPF.Stores;
using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels
{
    public class AddDonationViewModel : ViewModelBase
    {
        private Account _donater;
        public Account Donater
        {
            get
            {
                return _donater;
            }
            set
            {
                _donater = value;
                OnPropertyChanged(nameof(Donater));
            }
        }

        private int _value;
        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                OnPropertyChanged(nameof(Value));
            }
        }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public AddDonationViewModel(DonationStore donationStore, INavigationService closeNavigationService)
        {
            SubmitCommand = new AddDonationCommand(this, donationStore, closeNavigationService);
            CancelCommand = new NavigateCommand(closeNavigationService);
        }
    }
}
