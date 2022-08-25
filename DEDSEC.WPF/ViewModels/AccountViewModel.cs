using DEDSEC.WPF.Commands;
using DEDSEC.WPF.Services;
using DEDSEC.WPF.Stores;
using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels
{
    public class AccountViewModel : ViewModelBase
    {
        public NavigationBarViewModel NavigationBarViewModel { get; }
        private readonly AccountStore _accountStore;

        public string Nickname => _accountStore.CurrentAccount?.AccountHolder.Nickname ?? "Unknown";

        public ICommand NavigateHomeCommand { get; }

        public AccountViewModel(NavigationBarViewModel navigationBarViewModel, AccountStore accountStore, NavigationService<HomeViewModel> homeNavigationService)
        {
            _accountStore = accountStore;
            NavigationBarViewModel = navigationBarViewModel;
            NavigateHomeCommand = new NavigateCommand<HomeViewModel>(homeNavigationService);
        }
    }
}
