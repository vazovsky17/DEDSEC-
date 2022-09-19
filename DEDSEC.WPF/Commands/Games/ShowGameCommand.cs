using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands.Common;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels.Games;

namespace DEDSEC.WPF.Commands.Games
{
    public class ShowGameCommand : CommandBase
    {
        private readonly Game _game;
        private readonly AccountStore _accountStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public ShowGameCommand(Game game,
            AccountStore accountStore,
            ModalNavigationStore modalNavigationStore)
        {
            _game = game;
            _accountStore = accountStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public override void Execute(object parameter)
        {
            GameComponentViewModel gameComponentViewModel = new GameComponentViewModel(_game, _accountStore, _modalNavigationStore);
            _modalNavigationStore.CurrentViewModel = gameComponentViewModel;
        }
    }
}
