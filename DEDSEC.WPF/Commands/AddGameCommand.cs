using DEDSEC.Domain.Models;
using DEDSEC.WPF.Services;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels;
using System;
using System.Collections.Generic;

namespace DEDSEC.WPF.Commands
{
    public class AddGameCommand : CommandBase
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

        public override void Execute(object parameter)
        {
            _gamesStore.AddGame(new Game()
            {
                Id = Guid.NewGuid(),
                Name = _addGameViewModel.Name,
                Description = _addGameViewModel.Description,
                MinCountPlayers = _addGameViewModel.MinCountPlayers,
                MaxCountPlayers = _addGameViewModel.MaxCountPlayers,
                LinkHobbyGames = _addGameViewModel.LinkHobbyGames,
                Reviews = new List<Review>(),
            });

            _navigationService.Navigate();
        }
    }
}
