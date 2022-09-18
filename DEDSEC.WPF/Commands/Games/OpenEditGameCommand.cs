using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands.Common;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels.Games;

namespace DEDSEC.WPF.Commands.Games
{
    public class OpenEditGameCommand : CommandBase
    {
        private readonly GameViewModel _gameViewModel;
        private readonly AccountStore _accountStore;
        private readonly GamesStore _gamesStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public OpenEditGameCommand(GameViewModel gameViewModel,
            AccountStore accountStore,
            GamesStore gamesStore,
            ModalNavigationStore modalNavigationStore)
        {
            _gameViewModel = gameViewModel;
            _accountStore = accountStore;
            _gamesStore = gamesStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public override void Execute(object parameter)
        {
            var game = _gameViewModel.Game;

            EditGameViewModel editGameViewModel = new EditGameViewModel(
                game, _accountStore, _gamesStore, _modalNavigationStore);
            _modalNavigationStore.CurrentViewModel = editGameViewModel;
        }
    }
}
