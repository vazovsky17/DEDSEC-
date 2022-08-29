using DEDSEC.Domain.Models;
using DEDSEC.Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DEDSEC.WPF.Stores
{
    public class PlayersStore
    {
        private readonly IDataService<Account> _dataService;
        private readonly List<Account> _players;
        public IEnumerable<Account> Players => _players;

        public event Action PlayersLoaded;
        public event Action<Account> PlayerAdded;
        public event Action<Account> PlayerUpdated;
        public event Action<Guid> PlayerDeleted;

        public PlayersStore(IDataService<Account> dataService)
        {
            _players = new List<Account>();
            _dataService = dataService;
        }

        public async Task Load()
        {
            IEnumerable<Account> players = await _dataService.GetAll();
            _players.Clear();
            _players.AddRange(players);
            PlayersLoaded?.Invoke();
        }

        public async Task Add(Account player)
        {
            await _dataService.Create(player);
            _players.Add(player);
            PlayerAdded?.Invoke(player);
        }

        public async Task Update(Account player)
        {
            await _dataService.Update(player.Id, player);
            _players.Add(player);
            PlayerUpdated?.Invoke(player);
        }

        public async Task Delete(Account player)
        {
            await _dataService.Delete(player.Id);
            _players.Remove(player);
            PlayerDeleted?.Invoke(player.Id);
        }
    }
}
