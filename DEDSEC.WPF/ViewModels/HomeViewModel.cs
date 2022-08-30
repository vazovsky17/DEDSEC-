using DEDSEC.WPF.Commands;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly AccountStore _accountStore;

        public string WelcomeMessage => "Добро пожаловать в DEDSEC";
        public bool IsUnlogged => !_accountStore?.IsLoggedIn ?? true;

        public ICommand NavigateLoginCommand { get; }

        public HomeViewModel(AccountStore accountStore, INavigationService loginNavigationService)
        {
            _accountStore = accountStore;
            NavigateLoginCommand = new NavigateCommand(loginNavigationService);
        }
    }
}
