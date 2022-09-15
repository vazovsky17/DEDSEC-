using DEDSEC.Domain.Models;
using DEDSEC.Domain.Services.Authentification;
using DEDSEC.WPF.Commands.Common;
using DEDSEC.WPF.Services;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels.Accounts;
using System;
using System.Threading.Tasks;

namespace DEDSEC.WPF.Commands.Accounts
{
    public class EditAccountCommand : AsyncCommandBase
    {
        private readonly EditAccountViewModel _editAccountViewModel;
        private readonly IAccountService _dataService;
        private readonly AccountStore _accountStore;
        private readonly INavigationService _navigationService;

        public EditAccountCommand(EditAccountViewModel editAccountViewModel,
            IAccountService dataService,
            AccountStore accountStore,
            INavigationService navigationService)
        {
            _editAccountViewModel = editAccountViewModel;
            _accountStore = accountStore;
            _dataService = dataService;
            _navigationService = navigationService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            var account = new Account()
            {
                Id = _editAccountViewModel.CurrentAccount?.Id ?? Guid.NewGuid(),
                AccountHolder = new User()
                {
                    Id = _editAccountViewModel.CurrentAccount?.AccountHolder?.Id ?? Guid.NewGuid(),
                    Nickname = _editAccountViewModel.AccountFormViewModel.Nickname,
                    Password = _editAccountViewModel.AccountFormViewModel.Password,
                    IsAdmin = _editAccountViewModel.CurrentAccount?.AccountHolder?.IsAdmin ?? false,
                },
                Name = _editAccountViewModel.AccountFormViewModel.Name,
                Age = _editAccountViewModel.AccountFormViewModel.Age,
                AboutMe = _editAccountViewModel.AccountFormViewModel.AboutMe,
                IsVisited = _editAccountViewModel.AccountFormViewModel.IsVisited,
                FavoriteGames = _editAccountViewModel.CurrentAccount?.FavoriteGames ?? new()
            };
            if (account != null)
            {
                await _dataService.Update(account.Id, account).ContinueWith(task =>
                {
                    if (task.IsCompleted)
                    {
                        _accountStore.EditAccount(account);
                        _navigationService.Navigate();
                    }
                });
            }
        }
    }
}
