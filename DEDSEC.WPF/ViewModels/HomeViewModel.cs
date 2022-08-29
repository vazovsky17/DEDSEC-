using DEDSEC.WPF.Commands;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels.Donations;
using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly AccountStore _accountStore;
        public DonationGoalMiniViewModel DonationGoalMiniViewModel { get; }

        public string WelcomeMessage => "Добро пожаловать в DEDSEC";
        public bool IsUnlogged => !_accountStore?.IsLoggedIn ?? true;

        public ICommand NavigateLoginCommand { get; }

        public HomeViewModel(DonationGoalMiniViewModel donationGoalMiniViewModel, AccountStore accountStore,INavigationService loginNavigationService)
        {
            _accountStore = accountStore;
            DonationGoalMiniViewModel = donationGoalMiniViewModel;
            NavigateLoginCommand = new NavigateCommand(loginNavigationService);
        }
    }
}
