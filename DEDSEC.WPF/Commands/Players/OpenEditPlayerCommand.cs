using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands.Common;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels.Players;

namespace DEDSEC.WPF.Commands.Players
{
    public class OpenEditPlayerCommand : CommandBase
    {
        private readonly PlayerViewModel _playerViewModel;
        private readonly PlayersStore _playersStore;
        private readonly ModalNavigationStore _modalStore;

        public OpenEditPlayerCommand(PlayerViewModel playerViewModel,
            PlayersStore playersStore,
            ModalNavigationStore modalStore
            )
        {
            _playerViewModel = playerViewModel;
            _playersStore = playersStore;
            _modalStore = modalStore;
        }

        public override void Execute(object parameter)
        {
            Account player = _playerViewModel.Player;

            EditPlayerViewModel editPlayerViewModel = new EditPlayerViewModel(
                player, _playersStore, _modalStore);
            _modalStore.CurrentViewModel = editPlayerViewModel;
        }
    }
}
