using DEDSEC.Domain.Services.Authentification;
using DEDSEC.WPF.Commands;
using DEDSEC.WPF.Services;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels.Accounts
{
    public class AccountViewModel : ViewModelBase
    {
        private readonly AccountStore _accountStore;

        public string Nickname => _accountStore.CurrentAccount?.AccountHolder.Nickname ?? "Unknown";
        public string Name => _accountStore.CurrentAccount?.Name ?? "Unknown";
        public int Age => _accountStore.CurrentAccount?.Age ?? 0;
        public string AboutMe => _accountStore.CurrentAccount?.AboutMe ?? "About me...";
        public bool IsVisited => _accountStore.CurrentAccount?.IsVisited ?? true;

        public ICommand EditAccountCommand { get; }
        public ICommand DeleteAccountCommand { get; }

        public AccountViewModel(IAccountService dataService, AccountStore accountStore,IAuthenticatorService authenticatorService, INavigationService editAccountNavigationService, INavigationService homeNavigationService)
        {
            _accountStore = accountStore;
            EditAccountCommand = new NavigateCommand(editAccountNavigationService);
            DeleteAccountCommand = new DeleteAccountCommand(dataService, authenticatorService, homeNavigationService);

            _accountStore.CurrentAccountChanged += OnCurrentAccountChanged;
        }

        private void OnCurrentAccountChanged()
        {
            OnPropertyChanged(nameof(Nickname));
        }

        public override void Dispose()
        {
            _accountStore.CurrentAccountChanged -= OnCurrentAccountChanged;

            base.Dispose();

        }
    }
}
