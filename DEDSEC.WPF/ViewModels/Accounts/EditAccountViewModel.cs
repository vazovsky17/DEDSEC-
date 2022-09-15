using DEDSEC.Domain.Models;
using DEDSEC.Domain.Services.Authentification;
using DEDSEC.WPF.Commands;
using DEDSEC.WPF.Commands.Accounts;
using DEDSEC.WPF.Services;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels.Forms;

namespace DEDSEC.WPF.ViewModels.Accounts
{
    public class EditAccountViewModel : ViewModelBase
    {
        public Account? CurrentAccount { get; }
        public AccountFormViewModel AccountFormViewModel { get; }

        public EditAccountViewModel(IAccountService dataService,
            AccountStore accountStore,
            INavigationService closeNavigationService)
        {
            CurrentAccount = accountStore.CurrentAccount;

            var SubmitCommand = new EditAccountCommand(this, dataService, accountStore, closeNavigationService);
            var CancelCommand = new NavigateCommand(closeNavigationService);

            AccountFormViewModel = new AccountFormViewModel(SubmitCommand, CancelCommand)
            {
                Nickname = CurrentAccount?.AccountHolder.Nickname ?? string.Empty,
                Password = CurrentAccount?.AccountHolder.Password ?? string.Empty,
                Name = CurrentAccount?.Name ?? string.Empty,
                Age = CurrentAccount?.Age ?? 0,
                AboutMe = CurrentAccount?.AboutMe ?? string.Empty,
                IsVisited = CurrentAccount?.IsVisited ?? false,
            };
        }
    }
}
