using DEDSEC.WPF.Commands;
using DEDSEC.WPF.Commands.Players;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels.Accounts;

namespace DEDSEC.WPF.ViewModels.Players
{
    public class AddPlayerViewModel : ViewModelBase
    {
        public AccountFormViewModel AccountFormViewModel { get; }

        public AddPlayerViewModel(PlayersStore playersStore,
            INavigationService closeNavigationService)
        {
            var SubmitCommand = new AddPlayerCommand(this, playersStore, closeNavigationService);
            var CancelCommand = new NavigateCommand(closeNavigationService);

            AccountFormViewModel = new AccountFormViewModel(SubmitCommand, CancelCommand)
            {
                Nickname = string.Empty,
                Password = string.Empty,
                Name = string.Empty,
                Age = 0,
                AboutMe = string.Empty,
                IsVisited = false,
            };
        }
    }
}
