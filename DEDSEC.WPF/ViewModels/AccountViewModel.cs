using DEDSEC.WPF.Commands;
using DEDSEC.WPF.Services;
using DEDSEC.WPF.Stores;
using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels
{
    public class AccountViewModel : ViewModelBase
    {
        private readonly AccountStore _accountStore;

        public string Nickname => _accountStore.CurrentAccount?.AccountHolder.Nickname ?? "Unknown";

        public ICommand NavigateHomeCommand { get; }

        public AccountViewModel(AccountStore accountStore, INavigationService<HomeViewModel> homeNavigationService)
        {
            _accountStore = accountStore;
            NavigateHomeCommand = new NavigateCommand<HomeViewModel>(homeNavigationService);
        }
    }
}
