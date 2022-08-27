using DEDSEC.Domain.Models;
using DEDSEC.Domain.Services;
using DEDSEC.WPF.Commands;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels
{
    public class GameListingViewModel : ViewModelBase
    {
        public ICommand AddGameCommand { get; }
        private readonly IDataService<Game> _dataService;
        private readonly GamesStore _gamesStore;

        private IEnumerable<Game> _games;
        public IEnumerable<Game> Games
        {
            get
            {
                return _games;
            }
            set
            {
                _games = value;
                OnPropertyChanged(nameof(Games));
            }
        }

        public GameListingViewModel(IDataService<Game> dataService, GamesStore gamesStore, INavigationService addGameNavigationService)
        {
            _dataService = dataService;
            _gamesStore = gamesStore;

            AddGameCommand = new NavigateCommand(addGameNavigationService);

            LoadGames();
            _gamesStore.GameAdded += OnGameAdded;
        }

        private void OnGameAdded(Game game)
        {
            _games.Append(game);
        }

        private async void LoadGames()
        {
            await _dataService.GetAll().ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    _games = task.Result;
                    OnPropertyChanged(nameof(Games));
                }
            });
        }
    }
}
