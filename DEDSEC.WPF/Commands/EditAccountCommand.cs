using DEDSEC.Domain.Models;
using DEDSEC.Domain.Services;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels.Accounts;
using System.Threading.Tasks;

namespace DEDSEC.WPF.Commands
{
    public class EditAccountCommand : AsyncCommandBase
    {
        private readonly IDataService<Account> _dataService;
        private readonly EditAccountViewModel _editAccountViewModel;
        private readonly AccountStore _accountStore;
        private readonly INavigationService _navigationService;

        public EditAccountCommand(EditAccountViewModel editAccountViewModel, IDataService<Account> dataService, AccountStore accountStore, INavigationService navigationService)
        {
            _editAccountViewModel = editAccountViewModel;
            _dataService = dataService;
            _accountStore = accountStore;
            _navigationService = navigationService;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            var account = _accountStore.CurrentAccount;
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
                    _accountStore.CurrentAccount = account;
                    _navigationService.Navigate();
                }
            });
        }
    }
}
