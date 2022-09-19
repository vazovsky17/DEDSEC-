using DEDSEC.Domain.Models;
using DEDSEC.WPF.Commands.Players;
using DEDSEC.WPF.Extensions;
using DEDSEC.WPF.Services.Authenticator;
using DEDSEC.WPF.Services.Navigation;
using DEDSEC.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace DEDSEC.WPF.ViewModels.Players
{
    public class PlayerViewModel : ViewModelBase
    {
        public bool IsCurrentAccountAdmin { get; }

        public Account Player { get; private set; }

        #region Bindings
        public Guid Id => Player.Id;
        public User AccountHolder => Player.AccountHolder;
        public string Nickname => Player.SetNicknameDisplay();
        public string Name => Player.SetNameDisplay();
        public string Age => Player.SetAgeDisplay();
        public string AboutMe => Player.SetAboutMeDisplay();
        public bool IsVisited => Player?.IsVisited ?? false;
        public bool IsAdmin => AccountHolder?.IsAdmin ?? false;
        public List<Game> FavoriteGames => Player?.FavoriteGames ?? new();
        #endregion

        #region Commands
        public ICommand ShowCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
        #endregion

        public PlayerViewModel(Account player,
            PlayersStore playersStore,
            bool isCurrentAccountAdmin,
            ModalNavigationStore modalNavigationStore,
            IAuthenticatorService authenticatorService,
            AccountStore accountStore,
            INavigationService logoutNavigationService)
        {
            Player = player;
            IsCurrentAccountAdmin = isCurrentAccountAdmin;
            ShowCommand = new ShowPlayerCommand(player, modalNavigationStore);
            EditCommand = new OpenEditPlayerCommand(this, accountStore, playersStore, modalNavigationStore);
            DeleteCommand = new DeletePlayerCommand(authenticatorService, logoutNavigationService, playersStore, player);
        }

        public void Update(Account player)
        {
            Player = player;

            OnPropertyChanged(nameof(Player));
        }
    }
}
