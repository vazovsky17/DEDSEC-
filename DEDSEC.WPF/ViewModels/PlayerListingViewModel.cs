using DEDSEC.Domain.Models;
using DEDSEC.WPF.Services;
using DEDSEC.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels
{
    public class PlayerListingViewModel : ViewModelBase
    {
        private readonly PlayersStore _playersStore;
        private readonly ObservableCollection<PlayerViewModel> _players;

        public IEnumerable<PlayerViewModel> Players => _players;

        public PlayerListingViewModel(PlayersStore playersStore)
        {
            _playersStore = playersStore;

            _players = new ObservableCollection<PlayerViewModel>();
            _players.Add(new PlayerViewModel(
                new Account(
                    Guid.NewGuid(),
                    new User(Guid.NewGuid(), "VAZOVSKY", "883306"),
                    "MARINA",
                    23,
                    "Android developer",
                    true,
                    new List<Game>())));

            _playersStore.PlayerAdded += OnPlayerAdded;
        }
        private void OnPlayerAdded(Account account)
        {
            _players.Add(new PlayerViewModel(account));
        }
    }
}
