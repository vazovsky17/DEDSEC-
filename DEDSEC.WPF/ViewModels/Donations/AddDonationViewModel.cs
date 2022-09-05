using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands;
using DEDSEC.WPF.Commands.Donations;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels.Donations
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

        private int _value = 0;
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

        public AddDonationViewModel(DonationGoalStore donationGoalStore,
            AccountStore accountStore,
            INavigationService closeNavigationService)
        {
            SubmitCommand = new AddDonationCommand(this, accountStore, donationGoalStore, closeNavigationService);
            CancelCommand = new NavigateCommand(closeNavigationService);
        }
    }
}
