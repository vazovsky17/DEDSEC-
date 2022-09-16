using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands;
using DEDSEC.WPF.Services;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels.Players
{
    public class PlayersScreenViewModel : ViewModelBase
    {
        private readonly IAuthenticatorService _authenticatorService;
        private readonly INavigationService _logoutNavigationService;
        private readonly ModalNavigationStore _modalStore;
        private readonly PlayersStore _playersStore;

        private readonly AccountStore _accountStore;
        public bool IsCurrentAccountAdmin => _accountStore?.IsAdmin ?? false;

        private readonly ObservableCollection<PlayerViewModel> _playerViewModels;
        public IEnumerable<PlayerViewModel> PlayerViewModels => _playerViewModels;
        public string PlayersViewModelsCountDisplay => setPlayersViewModelsCountDisplay();

        public ICommand AddPlayerCommand { get; }

        public PlayersScreenViewModel(
            IAuthenticatorService authenticatorService,
            PlayersStore playersStore,
            AccountStore accountStore,
            ModalNavigationStore modalStore,
            INavigationService addPlayerNavigationService,
            INavigationService logoutNavigationService)
        {
            _authenticatorService = authenticatorService;
            _logoutNavigationService = logoutNavigationService;
            _modalStore = modalStore;
            _playersStore = playersStore;
            _accountStore = accountStore;

            _playerViewModels = new();

            Load();
            _playersStore.PlayersLoaded += PlayersStore_Loaded;
            _playersStore.PlayerAdded += PlayersStore_Added;
            _playersStore.PlayerUpdated += PlayersStore_Updated;
            _playersStore.PlayerDeleted += PlayerStore_Deleted;

            AddPlayerCommand = new NavigateCommand(addPlayerNavigationService);
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
                _playerViewModels.Remove(playerViewModel);
                playerViewModel.Update(player);
                _playerViewModels.Add(playerViewModel);
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
            var itemViewModel = new PlayerViewModel(player, _playersStore, IsCurrentAccountAdmin, _modalStore, _authenticatorService, _logoutNavigationService);
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
