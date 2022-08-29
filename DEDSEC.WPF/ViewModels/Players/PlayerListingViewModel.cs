using DEDSEC.Domain.Models;
using DEDSEC.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DEDSEC.WPF.ViewModels.Players
{
    public class PlayerListingViewModel : ViewModelBase
    {
        public bool IsAdmin => _accountStore?.IsAdmin ?? false;

        private readonly AccountStore _accountStore;
        private readonly PlayersStore _playersStore;

        private readonly ObservableCollection<PlayerViewModel> _playerViewModels;
        public IEnumerable<PlayerViewModel> PlayerViewModels => _playerViewModels;

        public PlayerListingViewModel(AccountStore accountStore, PlayersStore playersStore)
        {
            _accountStore = accountStore;
            _playersStore = playersStore;

            _playerViewModels = new ObservableCollection<PlayerViewModel>();

            Load();
            _playersStore.PlayersLoaded += PlayersStore_Loaded;
            _playersStore.PlayerAdded += PlayersStore_Added;
            _playersStore.PlayerUpdated += PlayersStore_Updated;
            _playersStore.PlayerDeleted += PlayerStore_Deleted;
        }

        private async void Load()
        {
            await _playersStore.Load();
        }

        private void PlayersStore_Loaded()
        {
            _playerViewModels.Clear();
            foreach (var player in _playersStore.Players)
            {
                AddPlayerViewModel(player);
            }
        }

        private void PlayersStore_Added(Account player)
        {
            AddPlayerViewModel(player);
        }

        private void PlayersStore_Updated(Account player)
        {
            PlayerViewModel playerViewModel = _playerViewModels.FirstOrDefault(x => x.Id == player.Id);

            if (playerViewModel != null)
            {
                playerViewModel.Update(player);
            }
        }

        private void PlayerStore_Deleted(Guid id)
        {
            PlayerViewModel playerViewModel = _playerViewModels.FirstOrDefault(x => x.Id == id);

            if (playerViewModel != null)
            {
                _playerViewModels.Remove(playerViewModel);
            }
        }

        private void AddPlayerViewModel(Account player)
        {
            PlayerViewModel itemViewModel = new PlayerViewModel(player);
            _playerViewModels.Add(itemViewModel);
        }

        public override void Dispose()
        {
            _playersStore.PlayersLoaded -= PlayersStore_Loaded;
            _playersStore.PlayerAdded -= PlayersStore_Added;
            _playersStore.PlayerUpdated -= PlayersStore_Updated;
            _playersStore.PlayerDeleted -= PlayerStore_Deleted;

            base.Dispose();
        }
    }
}
