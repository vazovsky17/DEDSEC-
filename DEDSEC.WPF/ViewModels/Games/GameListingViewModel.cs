using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels.Games
{
    public class GameListingViewModel : ViewModelBase
    {
        public bool IsAdmin => _accountStore?.IsAdmin ?? false;
        public ICommand AddGameCommand { get; }

        private readonly AccountStore _accountStore;
        private readonly GamesStore _gamesStore;

        private readonly ObservableCollection<GameViewModel> _gameViewModels;
        public IEnumerable<GameViewModel> GameViewModels => _gameViewModels;

        public GameListingViewModel(AccountStore accountStore, GamesStore gamesStore, INavigationService addGameNavigationService)
        {
            _accountStore = accountStore;
            _gamesStore = gamesStore;

            _gameViewModels = new ObservableCollection<GameViewModel>();

            Load();
            _gamesStore.GamesLoaded += GamesStore_Loaded;
            _gamesStore.GameAdded += GamesStore_Added;
            _gamesStore.GameUpdated += GamesStore_Updated;
            _gamesStore.GameDeleted += GamesStore_Deleted;

            AddGameCommand = new NavigateCommand(addGameNavigationService);
        }

        private async void Load()
        {
            await _gamesStore.Load();
        }

        private void GamesStore_Loaded()
        {
            _gameViewModels.Clear();
            foreach (var game in _gamesStore.Games)
            {
                AddGameViewModel(game);
            }
        }

        private void GamesStore_Added(Game game)
        {
            AddGameViewModel(game);
        }

        private void GamesStore_Updated(Game game)
        {
            GameViewModel gameViewModel = _gameViewModels.FirstOrDefault(x => x.Id == game.Id);
            if (gameViewModel != null)
            {
                gameViewModel.Update(game);
            }
        }

        private void GamesStore_Deleted(Guid id)
        {
            GameViewModel gameViewModel = _gameViewModels.FirstOrDefault(y => y.Id == id);

            if (gameViewModel != null)
            {
                _gameViewModels.Remove(gameViewModel);
            }
        }

        private void AddGameViewModel(Game game)
        {
            GameViewModel itemViewModel = new GameViewModel(game);
            _gameViewModels.Add(itemViewModel);
        }

        public override void Dispose()
        {
            _gamesStore.GamesLoaded -= GamesStore_Loaded;
            _gamesStore.GameAdded -= GamesStore_Added;
            _gamesStore.GameUpdated -= GamesStore_Updated;
            _gamesStore.GameDeleted -= GamesStore_Deleted;

            base.Dispose();
        }
    }
}
