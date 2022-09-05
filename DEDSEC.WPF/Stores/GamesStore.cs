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
        private readonly List<Game> _games;
        public IEnumerable<Game> Games => _games;

        public event Action GamesLoaded;
        public event Action<Game> GameAdded;
        public event Action<Game> GameUpdated;
        public event Action<Guid> GameDeleted;

        public GamesStore(IDataService<Game> dataService)
        {
            _games = new();
            _dataService = dataService;
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
    }
}
