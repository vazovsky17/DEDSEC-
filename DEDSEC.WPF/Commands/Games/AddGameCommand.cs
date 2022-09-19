using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands.Common;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels.Games;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DEDSEC.WPF.Commands.Games
{
    /// <summary>
    /// Добавление игры
    /// </summary>
    public class AddGameCommand : AsyncCommandBase
    {
        private readonly AddGameViewModel _addGameViewModel;
        private readonly GamesStore _gamesStore;
        private readonly INavigationService _navigationService;

        public AddGameCommand(AddGameViewModel addGameViewModel,
            GamesStore gamesStore,
            INavigationService navigationService)
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
                Name = _addGameViewModel.GameFormViewModel.Name,
                Description = _addGameViewModel.GameFormViewModel.Description,
                MinCountPlayers = _addGameViewModel.GameFormViewModel.MinCountPlayers,
                MaxCountPlayers = _addGameViewModel.GameFormViewModel.MaxCountPlayers,
                LinkHobbyGames = _addGameViewModel.GameFormViewModel.LinkHobbyGames
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
