using DEDSEC.Domain.Services.Authentification;
using DEDSEC.WPF.Commands;
using DEDSEC.WPF.Commands.Accounts;
using DEDSEC.WPF.Services;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels.Accounts
{
    public class AccountScreenViewModel : ViewModelBase
    {
        private readonly AccountStore _accountStore;

        public AccountViewModel CurrentAccountViewModel { get; private set; }

        public ICommand EditAccountCommand { get; }
        public ICommand DeleteAccountCommand { get; }

        public AccountScreenViewModel(IAccountService dataService,
            AccountStore accountStore,
            IAuthenticatorService authenticatorService,
            INavigationService editAccountNavigationService,
            INavigationService logoutNavigationService)
        {
            _accountStore = accountStore;
            CurrentAccountViewModel =  new AccountViewModel(_accountStore.CurrentAccount);
            EditAccountCommand = new NavigateCommand(editAccountNavigationService);
            DeleteAccountCommand = new DeleteAccountCommand(dataService, authenticatorService, logoutNavigationService);

            _accountStore.CurrentAccountChanged += OnCurrentAccountChanged;
        }

        private void OnCurrentAccountChanged()
        {
            OnPropertyChanged(nameof(CurrentAccountViewModel));
        }

        public override void Dispose()
        {
            _accountStore.CurrentAccountChanged -= OnCurrentAccountChanged;

            base.Dispose();
        }
    }
}
