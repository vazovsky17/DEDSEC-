using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands.Common;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels.Games;

namespace DEDSEC.WPF.Commands.Games
{
    public class OpenEditGameCommand : CommandBase
    {
        private readonly GameViewModel _gameViewModel;
        private readonly GamesStore _gamesStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public OpenEditGameCommand(GameViewModel gameViewModel,
            GamesStore gamesStore,
            ModalNavigationStore modalNavigationStore)
        {
            _gameViewModel = gameViewModel;
            _gamesStore = gamesStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public override void Execute(object parameter)
        {
            Game game = _gameViewModel.Game;

            EditGameViewModel editGameViewModel = new EditGameViewModel(
                game, _gamesStore, _modalNavigationStore);
            _modalNavigationStore.CurrentViewModel = editGameViewModel;
        }
    }
}
