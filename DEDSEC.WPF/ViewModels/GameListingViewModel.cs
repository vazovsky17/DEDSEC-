using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands;
using DEDSEC.WPF.Services;
using DEDSEC.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels
{
    public class GameListingViewModel : ViewModelBase
    {
        private readonly GamesStore _gamesStore;
        private readonly ObservableCollection<GameViewModel> _games;

        public IEnumerable<GameViewModel> Games => _games;
        public ICommand AddGameCommand { get; }

        public GameListingViewModel(GamesStore gamesStore, INavigationService addGameNavigationService)
        {
            _gamesStore = gamesStore;

            AddGameCommand = new NavigateCommand(addGameNavigationService);
            _games = new ObservableCollection<GameViewModel>();

            _games.Add(new GameViewModel(new Game()
            {
                Id = Guid.NewGuid(),
                Name = "Таверна",
                Description = "Пьем и играем",
                MinCountPlayers = 2,
                MaxCountPlayers = 20,
                LinkHobbyGames = "ссылочка",
                Reviews = new List<Review>(),
            }));

            _gamesStore.GameAdded += OnGameAdded;
        }

        private void OnGameAdded(Game game)
        {
            _games.Add(new GameViewModel(game));
        }
    }
}
