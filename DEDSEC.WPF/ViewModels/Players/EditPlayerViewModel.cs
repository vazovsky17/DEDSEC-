using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands.Common;
using DEDSEC.WPF.Commands.Players;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels.Accounts;

namespace DEDSEC.WPF.ViewModels.Players
{
    public class EditPlayerViewModel : ViewModelBase
    {
        public Account Player { get; }
        public AccountFormViewModel AccountFormViewModel { get; }

        public EditPlayerViewModel(Account player,
            AccountStore accountStore,
            PlayersStore playersStore,
            ModalNavigationStore modalStore)
        {
            Player = player;

            var SubmitCommand = new EditPlayerCommand(this, accountStore, playersStore, modalStore);
            var CancelCommand = new CloseModalCommand(modalStore);

            AccountFormViewModel = new AccountFormViewModel(SubmitCommand, CancelCommand)
            {
                Nickname = Player?.AccountHolder.Nickname ?? string.Empty,
                Password = Player?.AccountHolder.Password ?? string.Empty,
                Name = Player?.Name ?? string.Empty,
                Age = Player?.Age ?? 0,
                AboutMe = Player?.AboutMe ?? string.Empty,
                IsVisited = Player?.IsVisited ?? false,
            };
        }
    }
}
