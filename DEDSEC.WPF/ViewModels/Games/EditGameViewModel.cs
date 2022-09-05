using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands.Common;
using DEDSEC.WPF.Commands.Games;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels.Forms;

namespace DEDSEC.WPF.ViewModels.Games
{
    public class EditGameViewModel : ViewModelBase
    {
        public Game Game { get; }
        public GameFormViewModel GameFormViewModel { get; }

        public EditGameViewModel(Game game,
            GamesStore gamesStore,
            ModalNavigationStore modalStore)
        {
            Game = game;
            var SubmitCommand = new EditGameCommand(this, gamesStore, modalStore);
            var CancelCommand = new CloseModalCommand(modalStore);

            GameFormViewModel = new GameFormViewModel(SubmitCommand, CancelCommand)
            {
                Name = Game.Name,
                Description = Game.Description,
                MinCountPlayers = Game.MinCountPlayers,
                MaxCountPlayers = Game.MaxCountPlayers,
                LinkHobbyGames = Game.LinkHobbyGames
            };
        }
    }
}
