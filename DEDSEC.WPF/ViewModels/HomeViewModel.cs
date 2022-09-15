using DEDSEC.WPF.Commands;
using DEDSEC.WPF.Services;
using DEDSEC.WPF.Services.Navigation;
using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly IAuthenticatorService _authenticatorService;

        public string WelcomeMessage => "Добро пожаловать в DEDSEC";
        public bool IsUnlogged => !_authenticatorService?.IsLoggedIn ?? true;

        public ICommand NavigateLoginCommand { get; }

        public HomeViewModel(IAuthenticatorService authenticatorService,
            INavigationService loginNavigationService)
        {
            _authenticatorService = authenticatorService;
            NavigateLoginCommand = new NavigateCommand(loginNavigationService);
        }
    }
}
