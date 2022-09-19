using DEDSEC.Domain.Services.Authentification;
using DEDSEC.WPF.Commands.Common;
using DEDSEC.WPF.Services.Authenticator;
using DEDSEC.WPF.Services.Navigation;
using System.Threading.Tasks;
using System.Windows;

namespace DEDSEC.WPF.Commands.Accounts
{
    /// <summary>
    /// Удаление аккаунта
    /// </summary>
    public class DeleteAccountCommand : AsyncCommandBase
    {
        private readonly IAccountDataService _dataService;
        private readonly IAuthenticatorService _authenticatorService;
        private readonly INavigationService _navigationService;

        public DeleteAccountCommand(IAccountDataService dataService,
            IAuthenticatorService authenticatorService,
            INavigationService navigationService)
        {
            _dataService = dataService;
            _authenticatorService = authenticatorService;
            _navigationService = navigationService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            var message = MessageBox.Show("Вы действительно хотите удалить аккаунт?", "Это весьма смелое решение.", MessageBoxButton.YesNoCancel);
            if (message == MessageBoxResult.Yes)
            {
                var account = _authenticatorService.CurrentAccount;
                if (account != null)
                {
                    await _dataService.Delete(account.Id).ContinueWith(task =>
                    {
                        if (task.IsCompleted)
                        {
                            _authenticatorService.Logout();
                            _navigationService.Navigate();
                        }
                    });
                }
            }
        }
    }
}
