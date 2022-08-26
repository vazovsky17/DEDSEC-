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
            _gamesStore.AddGame(new Game(
                Guid.NewGuid(),
                _addGameViewModel.Name,
                _addGameViewModel.Description,
                _addGameViewModel.MinCountPlayers,
                _addGameViewModel.MaxCountPlayers,
                _addGameViewModel.LinkHobbyGames,
                new List<Review>()
                ));
            _navigationService.Navigate();
        }
    }
}
