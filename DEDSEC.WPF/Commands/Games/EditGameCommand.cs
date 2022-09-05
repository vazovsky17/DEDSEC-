using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands.Common;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels.Games;
using System.Threading.Tasks;
namespace DEDSEC.WPF.Commands.Games
{
    public class EditGameCommand : AsyncCommandBase
    {
        private readonly GameViewModel _gameViewModel;
        private readonly GamesStore _gamesStore;
        private readonly INavigationService _navigationService;

        public EditGameCommand(GameViewModel gameViewModel,
            GamesStore gamesStore,
            INavigationService navigationService)
        {
            _gameViewModel = gameViewModel;
            _gamesStore = gamesStore;
            _navigationService = navigationService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            var game = new Game()
            {
                Id = _gameViewModel.Id,
                Name = _gameViewModel.Name,
                Description = _gameViewModel.Description,
                LinkHobbyGames = _gameViewModel.LinkHobbyGames,
                MinCountPlayers = _gameViewModel.MinCountPlayers,
                MaxCountPlayers = _gameViewModel.MaxCountPlayers,
                Reviews = _gameViewModel.Reviews
            };

            await _gamesStore.Update(game).ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    _navigationService.Navigate();
                }
            });
        }
    }
}
