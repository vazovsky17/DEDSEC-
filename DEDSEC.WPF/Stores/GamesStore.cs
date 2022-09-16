using DEDSEC.Domain.Models;
using DEDSEC.Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DEDSEC.WPF.Stores
{
    public class GamesStore
    {
        private readonly IDataService<Game> _dataService;
        private readonly AccountStore _accountStore;
        private readonly List<Game> _games;
        public IEnumerable<Game> Games => _games;

        public event Action GamesLoaded;
        public event Action<Game> GameAdded;
        public event Action<Game> GameUpdated;
        public event Action<Guid> GameDeleted;
        public event Action<Game> GameToFavoriteAdded;
        public event Action<Game> GameFromFavoriteDeleted;

        public GamesStore(IDataService<Game> dataService,
             AccountStore accountStore)
        {
            _games = new();
            _dataService = dataService;
            _accountStore = accountStore;
        }

        public async Task Load()
        {
            IEnumerable<Game> games = await _dataService.GetAll();
            _games.Clear();
            _games.AddRange(games);
            GamesLoaded?.Invoke();
        }

        public async Task Add(Game game)
        {
            await _dataService.Create(game);
            _games.Add(game);
            GameAdded?.Invoke(game);
        }

        public async Task Update(Game game)
        {
            await _dataService.Update(game.Id, game);
            _games.Add(game);
            GameUpdated?.Invoke(game);
        }

        public async Task Delete(Game game)
        {
            await _dataService.Delete(game.Id);
            _games.Remove(game);
            GameDeleted?.Invoke(game.Id);
        }

        public async Task AddToFavorite(Game game)
        {
            await _accountStore.AddToFavoriteGames(game).ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    GameToFavoriteAdded?.Invoke(game);
                }
            });
        }

        public async Task DeleteFromFavorite(Game game)
        {
            await _accountStore.DeleteFromFavoriteGames(game).ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    GameFromFavoriteDeleted?.Invoke(game);
                }
            });
        }
    }
}
