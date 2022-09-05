using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands;
using DEDSEC.WPF.Commands.Players;
using DEDSEC.WPF.Services;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using DEDSEC.WPF.ViewModels.Games;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels.Players
{
    public class PlayerListingViewModel : ViewModelBase
    {
        public bool IsAdmin => _accountStore?.IsAdmin ?? false;

        private readonly AccountStore _accountStore;
        private readonly PlayersStore _playersStore;

        private readonly ObservableCollection<PlayerViewModel> _playerViewModels;
        public IEnumerable<PlayerViewModel> PlayerViewModels => _playerViewModels;
        public string PlayersViewModelsCountDisplay => setPlayersViewModelsCountDisplay();

        public ICommand AddPlayerCommand { get; }
        public ICommand EditPlayerCommand { get; }
        public ICommand DeletePlayerCommand { get; }

        public PlayerListingViewModel(AccountStore accountStore, 
            IAuthenticatorService authenticatorService,
            PlayersStore playersStore, 
            INavigationService addPlayerNavigationService,
            INavigationService editPlayerNavigationService)
        {
            _accountStore = accountStore;
            _playersStore = playersStore;

            _playerViewModels = new ObservableCollection<PlayerViewModel>();

            Load();
            _playersStore.PlayersLoaded += PlayersStore_Loaded;
            _playersStore.PlayerAdded += PlayersStore_Added;
            _playersStore.PlayerUpdated += PlayersStore_Updated;
            _playersStore.PlayerDeleted += PlayerStore_Deleted;

            AddPlayerCommand = new NavigateCommand(addPlayerNavigationService);
            EditPlayerCommand = new NavigateCommand(editPlayerNavigationService);
            DeletePlayerCommand = new DeletePlayerCommand(playersStore,authenticatorService);
        }

        private string setPlayersViewModelsCountDisplay()
{
            var count = _playerViewModels.Count;
            return count + " " + GrammarPlayer(count);
        }

        private string GrammarPlayer(int num)
        {
            if (num % 10 == 0)
            {
                return "игроков";
            }
            else if (num % 10 == 1 && num != 11)
            {
                return "игрок";
            }
            else if ((num >= 4 && num <= 2) || (num % 10 >= 4 && num % 10 <= 2 && num < 12 && num > 14))
            {
                return "игрока";
            }
            else
            {
                return "игроков";
            }
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
