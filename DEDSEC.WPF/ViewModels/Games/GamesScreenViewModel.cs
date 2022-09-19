using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands;
using DEDSEC.WPF.Extensions;
using DEDSEC.WPF.Services.Authenticator;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels.Games
{
    public class GamesScreenViewModel : ViewModelBase
    {
        private readonly GamesStore _gamesStore;
        private readonly AccountStore _accountStore;
        private readonly IAuthenticatorService _authenticatorService;
        private readonly ModalNavigationStore _modalNavigationStore;

        public bool IsAdmin => _accountStore?.IsAdmin ?? false;

        #region Bindings
        private readonly ObservableCollection<GameViewModel> _gameViewModels;
        public IEnumerable<GameViewModel> GameViewModels => _gameViewModels;
        public string GameViewModelsCountDisplay => GameViewModels.setGameViewModelsCountDisplay();
        #endregion

        #region Commands
        public ICommand AddGameCommand { get; }
        #endregion

        public GamesScreenViewModel(AccountStore accountStore,
            IAuthenticatorService authenticatorService,
            GamesStore gamesStore,
            ModalNavigationStore modalNavigationStore,
            INavigationService addGameNavigationService)
        {
            _accountStore = accountStore;
            _authenticatorService = authenticatorService;
            _gamesStore = gamesStore;
            _modalNavigationStore = modalNavigationStore;

            _gameViewModels = new();

            Load();
            _gamesStore.GamesLoaded += GamesStore_Loaded;
            _gamesStore.GameAdded += GamesStore_Added;
            _gamesStore.GameUpdated += GamesStore_Updated;
            _gamesStore.GameDeleted += GamesStore_Deleted;
            _gamesStore.GameToFavoriteAdded += GameStore_GameToFavoriteAdded;
            _gamesStore.GameFromFavoriteDeleted += GameStore_GameFromFavoriteDeleted;


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
            OnPropertyChanged(nameof(GameViewModelsCountDisplay));
        }

        private void GamesStore_Added(Game game)
        {
            AddGameViewModel(game);
            OnPropertyChanged(nameof(GameViewModelsCountDisplay));
        }

        private void GamesStore_Updated(Game game)
        {
            GameViewModel gameViewModel = _gameViewModels.FirstOrDefault(x => x.Id == game.Id);
            if (gameViewModel != null)
            {
                _gameViewModels.Remove(gameViewModel);
                gameViewModel.Update(game);
                _gameViewModels.Add(gameViewModel);
            }
        }

        private void GamesStore_Deleted(Guid id)
        {
            GameViewModel gameViewModel = _gameViewModels.FirstOrDefault(y => y.Id == id);
            if (gameViewModel != null)
            {
                _gameViewModels.Remove(gameViewModel);
                OnPropertyChanged(nameof(GameViewModelsCountDisplay));
            }
        }

        private void GameStore_GameToFavoriteAdded(Game game)
        {
            GameViewModel gameViewModel = _gameViewModels.FirstOrDefault(x => x.Id == game.Id);
            if (gameViewModel != null)
            {
                gameViewModel.UpdateIsFavorite();
            }
        }

        private void GameStore_GameFromFavoriteDeleted(Game game)
        {
            GameViewModel gameViewModel = _gameViewModels.FirstOrDefault(x => x.Id == game.Id);
            if (gameViewModel != null)
            {
                gameViewModel.UpdateIsFavorite();
            }
        }

        private void AddGameViewModel(Game game)
        {
            var itemViewModel = new GameViewModel(game, _gamesStore, _accountStore, _authenticatorService, _modalNavigationStore);
            _gameViewModels.Add(itemViewModel);
        }

        public override void Dispose()
        {
            _gamesStore.GamesLoaded -= GamesStore_Loaded;
            _gamesStore.GameAdded -= GamesStore_Added;
            _gamesStore.GameUpdated -= GamesStore_Updated;
            _gamesStore.GameDeleted -= GamesStore_Deleted;
            _gamesStore.GameToFavoriteAdded -= GameStore_GameToFavoriteAdded;
            _gamesStore.GameFromFavoriteDeleted -= GameStore_GameFromFavoriteDeleted;

            base.Dispose();
        }
    }
}
