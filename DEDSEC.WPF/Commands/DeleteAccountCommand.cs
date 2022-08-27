using DEDSEC.Domain.Models;
using DEDSEC.Domain.Services;
using DEDSEC.WPF.Services;
using DEDSEC.WPF.Stores;
using System.Threading.Tasks;

namespace DEDSEC.WPF.Commands
{
    public class DeleteAccountCommand : AsyncCommandBase
    {
        private readonly IDataService<Account> _dataService;
        private readonly AccountStore _accountStore;
        private readonly INavigationService _navigationService;

        public DeleteAccountCommand(IDataService<Account> dataService, AccountStore accountStore, INavigationService navigationService)
        {
            _dataService = dataService;
            _accountStore = accountStore;
            _navigationService = navigationService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await _dataService.Delete(_accountStore.CurrentAccount.Id).ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    _accountStore.Logout();
                    _navigationService.Navigate();
                }
            });
        }
    }
}
