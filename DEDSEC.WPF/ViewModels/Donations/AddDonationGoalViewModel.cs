using DEDSEC.WPF.Commands;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels.Donations
{
    public class AddDonationGoalViewModel : ViewModelBase
    {
        private string _title = string.Empty;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }

        private string _description = string.Empty;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        private int _currentValue = 0;
        public int CurrentValue
        {
            get
            {
                return _currentValue;
            }
            set
            {
                _currentValue = value;
                OnPropertyChanged(nameof(CurrentValue));
            }
        }

        private int _targetValue = 0;
        public int TargetValue
        {
            get
            {
                return _targetValue;
            }
            set
            {
                _targetValue = value;
                OnPropertyChanged(nameof(TargetValue));
            }
        }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public AddDonationGoalViewModel(DonationGoalStore donationGoalStore, INavigationService closeNavigationService)
        {
            SubmitCommand = new AddDonationGoalCommand(this, donationGoalStore, closeNavigationService);
            CancelCommand = new NavigateCommand(closeNavigationService);
        }
    }
}
