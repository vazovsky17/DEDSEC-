using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands.Common;
using DEDSEC.WPF.Commands.Games;
using DEDSEC.WPF.Stores;

namespace DEDSEC.WPF.ViewModels.Games
{
    public class EditGameViewModel : ViewModelBase
    {
        public Game Game { get; }
        public GameFormViewModel GameFormViewModel { get; }

        public EditGameViewModel(Game game,
            AccountStore accountStore,
            GamesStore gamesStore,
            ModalNavigationStore modalNavigationStore)
        {
            Game = game;
            var submitCommand = new EditGameCommand(this, accountStore, gamesStore, modalNavigationStore);
            var cancelCommand = new CloseModalCommand(modalNavigationStore);

            GameFormViewModel = new GameFormViewModel(submitCommand, cancelCommand)
            {
                Name = Game.Name ?? string.Empty,
                Description = Game.Description ?? string.Empty,
                MinCountPlayers = Game.MinCountPlayers,
                MaxCountPlayers = Game.MaxCountPlayers,
                LinkHobbyGames = Game.LinkHobbyGames ?? string.Empty
            };
        }
    }
}
