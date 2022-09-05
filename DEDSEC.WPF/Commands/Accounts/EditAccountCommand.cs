using DEDSEC.Domain.Services.Authentification;
using DEDSEC.WPF.Commands.Common;
using DEDSEC.WPF.Services;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.ViewModels.Accounts;
using System.Threading.Tasks;

namespace DEDSEC.WPF.Commands.Accounts
{
    public class EditAccountCommand : AsyncCommandBase
    {
        private readonly IAccountService _dataService;
        private readonly EditAccountViewModel _editAccountViewModel;
        private readonly IAuthenticatorService _authenticatorService;
        private readonly INavigationService _navigationService;

        public EditAccountCommand(EditAccountViewModel editAccountViewModel, IAccountService dataService, IAuthenticatorService authenticatorService, INavigationService navigationService)
        {
            _editAccountViewModel = editAccountViewModel;
            _authenticatorService = authenticatorService;
            _dataService = dataService;
            _navigationService = navigationService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            var account = _authenticatorService.CurrentAccount;
            if (account != null)
            {
                account.AccountHolder.Nickname = _editAccountViewModel.Nickname;
                account.AccountHolder.Password = _editAccountViewModel.Password;
                account.Name = _editAccountViewModel.Name;
                account.Age = _editAccountViewModel.Age;
                account.AboutMe = _editAccountViewModel.AboutMe;
                account.IsVisited = _editAccountViewModel.IsVisited;
                await _dataService.Update(account.Id, account).ContinueWith(task =>
                {
                    if (task.IsCompleted)
                    {
                        _authenticatorService.EditAccount(account);
                        _navigationService.Navigate();
                    }
                });
            }
        }
    }
}
