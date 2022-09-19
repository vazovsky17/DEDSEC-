using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands.Common;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels.Players;

namespace DEDSEC.WPF.Commands.Players
{
    public class ShowPlayerCommand : CommandBase
    {
        private readonly Account _player;
        private readonly ModalNavigationStore _modalNavigationStore;

        public ShowPlayerCommand(Account player,
            ModalNavigationStore modalNavigationStore)
        {
            _player = player;
            _modalNavigationStore = modalNavigationStore;
        }

        public override void Execute(object parameter)
        {
            PlayerComponentViewModel playerComponentViewModel = new PlayerComponentViewModel(_player, _modalNavigationStore);
            _modalNavigationStore.CurrentViewModel = playerComponentViewModel;
        }
    }
}
