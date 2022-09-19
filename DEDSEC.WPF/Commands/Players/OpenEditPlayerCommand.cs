using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands.Common;
using DEDSEC.WPF.Services.Authenticator;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels.Players;

namespace DEDSEC.WPF.Commands.Players
{
    public class OpenEditPlayerCommand : CommandBase
    {
        private readonly AccountStore _accountStore;
        private readonly PlayerViewModel _playerViewModel;
        private readonly PlayersStore _playersStore;
        private readonly ModalNavigationStore _modalStore;

        public OpenEditPlayerCommand(PlayerViewModel playerViewModel,
            AccountStore accountStore,
            PlayersStore playersStore,
            ModalNavigationStore modalStore
            )
        {
            _accountStore = accountStore;
            _playerViewModel = playerViewModel;
            _playersStore = playersStore;
            _modalStore = modalStore;
        }

        public override void Execute(object parameter)
        {
            Account player = _playerViewModel.Player;

            EditPlayerViewModel editPlayerViewModel = new EditPlayerViewModel(
                player, _accountStore, _playersStore, _modalStore);
            _modalStore.CurrentViewModel = editPlayerViewModel;
        }
    }
}
