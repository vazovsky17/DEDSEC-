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
        private readonly AccountStore _accountStore;
        private readonly GamesStore _gamesStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public EditGameCommand(EditGameViewModel editGameViewModel,
            AccountStore accountStore,
            GamesStore gamesStore,
            ModalNavigationStore modalNavigationStore)
        {
            _editGameViewModel = editGameViewModel;
            _accountStore = accountStore;   
            _gamesStore = gamesStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            var form = _editGameViewModel.GameFormViewModel;
            var game = new Game()
            {
                Id = _editGameViewModel.Game.Id,
                Name = form.Name,
                Description = form.Description,
                LinkHobbyGames = form.LinkHobbyGames,
                MinCountPlayers = form.MinCountPlayers,
                MaxCountPlayers = form.MaxCountPlayers,
                Reviews = _editGameViewModel.Game.Reviews
            };
            if (game != null)
            {
                await _gamesStore.Update(game).ContinueWith(async task =>
                {
                    if (task.IsCompleted)
                    {
                        await _accountStore.EditFavoriteGame(game);
                        _modalNavigationStore.Close();
                    }
                });
            }
        }
    }
}
