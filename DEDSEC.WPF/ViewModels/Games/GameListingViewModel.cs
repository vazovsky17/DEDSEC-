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
        private readonly AccountStore _accountStore;
        private readonly GamesStore _gamesStore;

        public bool IsAdmin => _accountStore?.IsAdmin ?? false;
        public ICommand AddGameCommand { get; }
        public ICommand EditGameCommand { get; }
        public ICommand DeleteGameCommand { get; }

        private readonly ObservableCollection<GameViewModel> _gameViewModels;
        public IEnumerable<GameViewModel> GameViewModels => _gameViewModels;
        public string GameViewModelsCountDisplay => setGameViewModelsCountDisplay();

        public GameListingViewModel(AccountStore accountStore,
            GamesStore gamesStore,
            INavigationService addGameNavigationService)
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

        private string setGameViewModelsCountDisplay()
        {
            var count = _gameViewModels.Count;
            return count + " " + GrammarGame(count);
        }

        /// <summary>
        /// НЕ РАБОТАЕТ
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private string GrammarGame(int num)
        {
            if (num % 10 == 0)
            {
                return "игр";
            }
            else if (num % 10 == 1 && num != 11)
            {
                return "игра";
            }
            else if ((num >= 4 && num <= 2) || (num % 10 >= 4 && num % 10 <= 2 && num < 12 && num > 14))
            {
                return "игры";
            }
            else
            {
                return "игр";
            }
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
                gameViewModel.Update(game);
                OnPropertyChanged(nameof(GameViewModelsCountDisplay));
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
