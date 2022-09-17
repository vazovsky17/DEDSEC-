using DEDSEC.WPF.Commands;
using DEDSEC.WPF.Services;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels.Games;
using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels
{
    public class HomeScreenViewModel : ViewModelBase
    {
        private readonly IAuthenticatorService _authenticatorService;
        private readonly GamesStore _gamesStore;

        public string WelcomeMessage => "Добро пожаловать в DEDSEC!";
        public bool IsLoggedIn => _authenticatorService?.IsLoggedIn ?? false;

        public ICommand NavigateLoginCommand { get; }

        public HomeScreenViewModel(IAuthenticatorService authenticatorService,
            INavigationService loginNavigationService)
        {
            _authenticatorService = authenticatorService;
            NavigateLoginCommand = new NavigateCommand(loginNavigationService);
        }

    }
}
