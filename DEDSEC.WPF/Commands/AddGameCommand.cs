using DEDSEC.Domain.Models;
using DEDSEC.Domain.Services;
using DEDSEC.WPF.Services;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DEDSEC.WPF.Commands
{
    public class AddGameCommand : AsyncCommandBase
    {
        private readonly AddGameViewModel _addGameViewModel;
        private readonly IDataService<Game> _dataService;
        private readonly GamesStore _gamesStore;
        private readonly INavigationService _navigationService;

        public AddGameCommand(AddGameViewModel addGameViewModel, IDataService<Game> dataService, GamesStore gamesStore, INavigationService navigationService)
        {
            _addGameViewModel = addGameViewModel;
            _dataService = dataService;
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
            await _dataService.Create(game).ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    _gamesStore.AddGame(game);
                    _navigationService.Navigate();
                }
            });
        }
    }
}
