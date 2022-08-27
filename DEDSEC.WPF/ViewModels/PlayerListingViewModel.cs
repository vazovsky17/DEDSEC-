using DEDSEC.Domain.Models;
using DEDSEC.Domain.Services;
using DEDSEC.WPF.Stores;
using System.Collections.Generic;
using System.Linq;

namespace DEDSEC.WPF.ViewModels
{
    public class PlayerListingViewModel : ViewModelBase
    {
        private readonly IDataService<Account> _dataService;
        private readonly AccountStore _accountStore;
        private readonly PlayersStore _playersStore;

        private IEnumerable<Account> _players;
        public IEnumerable<Account> Players
        {
            get
            {
                return _players;
            }
            set
            {
                _players = value;
                OnPropertyChanged(nameof(Players));
            }
        }
        public bool IsAdmin => _accountStore?.IsAdmin ?? false;

        public PlayerListingViewModel(IDataService<Account> dataService, AccountStore accountStore,PlayersStore playersStore)
        {
            _dataService = dataService;
            _accountStore = accountStore;
            _playersStore = playersStore;

            LoadPlayers();
            _playersStore.PlayerAdded += OnPlayerAdded;
        }

        private void OnPlayerAdded(Account account)
        {
            _players.Append(account);
        }

        private async void LoadPlayers()
        {
            await _dataService.GetAll().ContinueWith(task =>
            {
                if (task.IsCompleted)
                {
                    _players = task.Result;
                    OnPropertyChanged(nameof(Players));
                }
            });
        }
    }
}
