using DEDSEC.Domain.Models;
using DEDSEC.Domain.Services.Authentification;
using DEDSEC.WPF.Commands;
using DEDSEC.WPF.Commands.Accounts;
using DEDSEC.WPF.Services;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels.Accounts
{
    public class AccountViewModel : ViewModelBase
    {
        private readonly AccountStore _accountStore;

        public Account? CurrentAccount => _accountStore?.CurrentAccount;
        public string Nickname => !string.IsNullOrEmpty(CurrentAccount?.AccountHolder.Nickname) ? CurrentAccount.AccountHolder.Nickname : "Неизвестно";
        public string Name => !string.IsNullOrEmpty(CurrentAccount?.Name) ? CurrentAccount.Name : "Неизестно";
        public int Age => _accountStore.CurrentAccount?.Age ?? 0;
        public string AboutMe => !string.IsNullOrEmpty(CurrentAccount?.AboutMe) ? CurrentAccount.AboutMe : "Не заполнено";
        public bool IsVisited => _accountStore.CurrentAccount?.IsVisited ?? false;

        public ICommand EditAccountCommand { get; }
        public ICommand DeleteAccountCommand { get; }

        public AccountViewModel(IAccountService dataService,
            AccountStore accountStore,
            IAuthenticatorService authenticatorService,
            INavigationService editAccountNavigationService,
            INavigationService logoutNavigationService)
        {
            _accountStore = accountStore;
            EditAccountCommand = new NavigateCommand(editAccountNavigationService);
            DeleteAccountCommand = new DeleteAccountCommand(dataService, authenticatorService, logoutNavigationService);

            _accountStore.CurrentAccountChanged += OnCurrentAccountChanged;
        }

        private void OnCurrentAccountChanged()
        {
            OnPropertyChanged(nameof(Account));
        }

        public override void Dispose()
        {
            _accountStore.CurrentAccountChanged -= OnCurrentAccountChanged;

            base.Dispose();
        }
    }
}
