using DEDSEC.Domain.Models;
using DEDSEC.Domain.Services;
using DEDSEC.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DEDSEC.WPF.ViewModels
{
    public class PlayerListingViewModel : ViewModelBase
    {
        private readonly IDataService<Account> _dataService;
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

        public PlayerListingViewModel(IDataService<Account> dataService, PlayersStore playersStore)
        {
            _dataService = dataService;
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
