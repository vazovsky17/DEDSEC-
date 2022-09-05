using DEDSEC.WPF.Commands.Common;
using DEDSEC.WPF.Services;
using DEDSEC.WPF.Services.Navigation;

namespace DEDSEC.WPF.Commands.Authorization
{
    public class LogoutCommand : CommandBase
    {
        private readonly IAuthenticatorService _authenticatorService;
        private readonly INavigationService _navigationService;

        public LogoutCommand(IAuthenticatorService authenticatorService,
            INavigationService navigationService)
        {
            _authenticatorService = authenticatorService;
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            _authenticatorService.Logout();
            _navigationService.Navigate();
        }
    }
}
