using DEDSEC.WPF.Commands;
using DEDSEC.WPF.Services;
using DEDSEC.WPF.Stores;
using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels
{
    public class NavigationBarViewModel : ViewModelBase
    {
        private readonly AccountStore _accountStore;

        public ICommand NavigateHomeCommand { get; }
        public ICommand NavigateAccountCommand { get; }
        public ICommand NavigateLoginCommand { get; }

        public bool IsLoggedIn => _accountStore.IsLoggedIn;

        public NavigationBarViewModel(AccountStore accountStore,
            INavigationService<HomeViewModel> homeNavigationService,
            INavigationService<AccountViewModel> accountNavigationService,
            INavigationService<LoginViewModel> loginNavigationService)
        {
            _accountStore = accountStore;
            NavigateHomeCommand = new NavigateCommand<HomeViewModel>(homeNavigationService);
            NavigateAccountCommand = new NavigateCommand<AccountViewModel>(accountNavigationService);
            NavigateLoginCommand = new NavigateCommand<LoginViewModel>(loginNavigationService);
        }
    }
}
