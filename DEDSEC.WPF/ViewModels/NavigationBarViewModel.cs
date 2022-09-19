using DEDSEC.WPF.Commands;
using DEDSEC.WPF.Commands.Authorization;
using DEDSEC.WPF.Extensions;
using DEDSEC.WPF.Services.Authenticator;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels
{
    public class NavigationBarViewModel : ViewModelBase
    {
        private readonly AccountStore _accountStore;

        #region Bindings
        public string Nickname => _accountStore.CurrentAccount.SetNicknameDisplay();
        public bool IsAdmin => _accountStore?.IsAdmin ?? false;
        public bool IsLoggedIn => _accountStore.CurrentAccount != null;
        public bool IsUnlogged => !IsLoggedIn;
        #endregion

        #region Commands
        public ICommand NavigateAccountCommand { get; }
        public ICommand NavigateLoginCommand { get; }
        public ICommand NavigateMeetingListingCommand { get; }
        public ICommand NavigatePlayerListingCommand { get; }
        public ICommand NavigateGameListingCommand { get; }
        public ICommand NavigateDonationGoalCommand { get; }
        public ICommand LogoutCommand { get; }
        #endregion

        public NavigationBarViewModel(AccountStore accountStore,
            IAuthenticatorService authenticatorService,
            INavigationService homeNavigationService,
            INavigationService accountNavigationService,
            INavigationService loginNavigationService,
            INavigationService meetingListingNavigationService,
            INavigationService playerListingNavigationService,
            INavigationService gameListingNavigationService)
        {
            _accountStore = accountStore;
            NavigateAccountCommand = new NavigateCommand(accountNavigationService);
            NavigateLoginCommand = new NavigateCommand(loginNavigationService);
            NavigateMeetingListingCommand = new NavigateCommand(meetingListingNavigationService);
            NavigatePlayerListingCommand = new NavigateCommand(playerListingNavigationService);
            NavigateGameListingCommand = new NavigateCommand(gameListingNavigationService);
            LogoutCommand = new LogoutCommand(authenticatorService, homeNavigationService);

            _accountStore.CurrentAccountChanged += OnCurrentAccountChanged;
        }

        private void OnCurrentAccountChanged()
        {
            OnPropertyChanged(nameof(IsLoggedIn));
            OnPropertyChanged(nameof(IsUnlogged));
        }

        public override void Dispose()
        {
            _accountStore.CurrentAccountChanged -= OnCurrentAccountChanged;

            base.Dispose();
        }
    }
}
