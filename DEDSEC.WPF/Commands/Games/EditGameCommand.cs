using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands.Common;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels.Games;
using System.Threading.Tasks;
namespace DEDSEC.WPF.Commands.Games
{
    public class EditGameCommand : AsyncCommandBase
    {
        private readonly EditGameViewModel _editGameViewModel;
        private readonly GamesStore _gamesStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public EditGameCommand(EditGameViewModel editGameViewModel,
            GamesStore gamesStore,
            ModalNavigationStore modalNavigationStore)
        {
            _editGameViewModel = editGameViewModel;
            _gamesStore = gamesStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            var game = new Game()
            {
                Id = _editGameViewModel.Game.Id,
                Name = _editGameViewModel.GameFormViewModel.Name,
                Description = _editGameViewModel.GameFormViewModel.Description,
                LinkHobbyGames = _editGameViewModel.GameFormViewModel.LinkHobbyGames,
                MinCountPlayers = _editGameViewModel.GameFormViewModel.MinCountPlayers,
                MaxCountPlayers = _editGameViewModel.GameFormViewModel.MaxCountPlayers,
                Reviews = _editGameViewModel.Game.Reviews
            };
            if (game != null)
            {
                await _gamesStore.Update(game).ContinueWith(task =>
                {
                    if (task.IsCompleted)
                    {
                        _modalNavigationStore.Close();
                    }
                });
            }
        }
    }
}
