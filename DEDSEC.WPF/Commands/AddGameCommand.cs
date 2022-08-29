using DEDSEC.Domain.Models;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels.Games;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DEDSEC.WPF.Commands
{
    public class AddGameCommand : AsyncCommandBase
    {
        private readonly AddGameViewModel _addGameViewModel;
        private readonly GamesStore _gamesStore;
        private readonly INavigationService _navigationService;

        public AddGameCommand(AddGameViewModel addGameViewModel, GamesStore gamesStore, INavigationService navigationService)
        {
            _addGameViewModel = addGameViewModel;
            _gamesStore = gamesStore;
            _navigationService = navigationService;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            var game = new Game()
            {
                Id = Guid.NewGuid(),
                Name = _addGameViewModel.Name,
                Description = _addGameViewModel.Description,
                MinCountPlayers = _addGameViewModel.MinCountPlayers,
                MaxCountPlayers = _addGameViewModel.MaxCountPlayers,
                LinkHobbyGames = _addGameViewModel.LinkHobbyGames,
                Reviews = new List<Review>(),
            };
            await _gamesStore.Add(game).ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    _navigationService.Navigate();
                }
            });
        }
    }
}
